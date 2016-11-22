using DataModelLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using Logging;

namespace BLL
{
    public class ReadFromCsv : IStore
    {
        public string path { get; set; }
        public string jsonPath { get; set; }
        public string fileName { get; set; }

        public ReadFromCsv(string path, string jsonPath)
        {
            this.path = path;
            this.jsonPath = jsonPath;
            fileName = Path.GetFileName(path);
        }

        public IEnumerable<DataModel> Read()
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    List<string> listOfDivied;
                    string line = "";
                    DataModel dataModel;
                    Project[] project;
                    string currentline = string.Empty;
                    bool isWrong = false;//

                    while ((line = reader.ReadLine()) != null)
                    {
                        dataModel = new DataModel();
                         listOfDivied = new List<string>();

                        try
                        {
                            foreach (string item in line.Split(';'))
                            {
                                listOfDivied.Add(item);
                            }

                            project = new Project[listOfDivied.Count - 6];//5

                            dataModel.TeamID = long.Parse(listOfDivied[0]);
                            dataModel.TeamName = listOfDivied[1];
                            dataModel.MemberID = long.Parse(listOfDivied[2]);
                            dataModel.PassportNumber = listOfDivied[3];//changed
                            dataModel.MemberName = listOfDivied[4];
                            dataModel.MemberSurname = listOfDivied[5];

                            for (int i = 0; i < 6; i++)
                            {
                                listOfDivied.RemoveAt(0);
                            }

                            int index = 0;

                            while (listOfDivied.Count > 0)
                            {
                                string[] projectsMemeber = listOfDivied[0].Split(',');
                                project[index] = new Project()
                                {
                                    ProjectID = long.Parse(projectsMemeber[0]),
                                    ProjectName = projectsMemeber[1],
                                    ProjectCreatedDate = DateTime.Parse((projectsMemeber[2])),
                                    ProjectDueDate = DateTime.Parse((projectsMemeber[3])),
                                    ProjectDescription = projectsMemeber[4]
                                };
                                index++;

                                listOfDivied.RemoveAt(0);
                            }
                            dataModel.Projects = project;
                        }
                        catch
                        {
                            isWrong = true;
                            WrongData wrongData = new WrongData(this.fileName);
                            Logger.DoLogging(LogType.WrongData, null, "Finde wrog data and wrote ot wrong directory.");
                            wrongData.WrongDataFromCSV(line);
                        }

                        if (!isWrong)
                            yield return dataModel;
                        else
                        {
                            isWrong = false;
                            continue;
                        }

                    }
                }

            }
        }

    }
}
