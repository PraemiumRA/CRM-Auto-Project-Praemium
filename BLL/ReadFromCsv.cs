using DataModelLibrary;
using System;
using System.Collections.Generic;
using System.IO;
namespace BLL
{
    public class ReadFromCsv : IStore
    {
        public string path { get; set; }
        public string jsonPath { get; set; }

        public ReadFromCsv(string path, string jsonPath)
        {
            this.path = path;
            this.jsonPath = jsonPath;
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

                    while ((line = reader.ReadLine()) != null)
                    {
                        dataModel = new DataModel();
                        listOfDivied = new List<string>();

                        foreach (string item in line.Split(';'))
                        {
                            listOfDivied.Add(item);
                        }

                        project = new Project[listOfDivied.Count - 5];

                        dataModel.TeamID = int.Parse(listOfDivied[0]);
                        dataModel.TeamName = listOfDivied[1];
                        dataModel.MemberID = int.Parse(listOfDivied[2]);
                        dataModel.MemberName = listOfDivied[3];
                        dataModel.MemberSurname = listOfDivied[4];

                        for (int i = 0; i < 5; i++)
                        {
                            listOfDivied.RemoveAt(0);
                        }

                        int index = 0;

                        while (listOfDivied.Count > 0)
                        {
                            string[] projectsMemeber = listOfDivied[0].Split(',');
                            project[index] = new Project()
                            {
                                ProjectID = int.Parse(projectsMemeber[0]),
                                ProjectName = projectsMemeber[1],
                                ProjectCreatedDate = DateTime.Parse((projectsMemeber[2])),
                                ProjectDueDate = DateTime.Parse((projectsMemeber[3])),
                                ProjectDescription = projectsMemeber[4]
                            };
                            index++;

                            listOfDivied.RemoveAt(0);
                        }
                        dataModel.Projects = project;

                        yield return dataModel;

                    }
                }

            }
        }

    }
}
