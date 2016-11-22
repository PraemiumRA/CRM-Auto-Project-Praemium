using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using DataModelLibrary;
using System.IO;

namespace FileGenerator
{
    /// <summary>
    /// Random data generator class
    /// </summary>
    class DataGenerator : IDisposable
    {
        int dataCount = 0;
        int projectCount = 0;
        private string defoultDataPath = @"..\..\Creaters\Resourse\defoultData.dat";

        private List<DataModel> allData;
        DataModel dataModel;
        public StringCollection MemberNames = new StringCollection();
        public StringCollection MemberSurnames = new StringCollection();
        Dictionary<long, string> TeamInfo = new Dictionary<long, string>();
        Dictionary<long, string> ProjectInfo = new Dictionary<long, string>();

        Random random = new Random();


        public DataGenerator(int dataCount, int projectCount)
        {
            this.dataCount = dataCount;
            this.projectCount = projectCount;
            allData = new List<DataModel>();
            ReadStringValues();
        }

        /// <summary>
        /// Generate Unique dates
        /// </summary>
        /// <returns></returns>
        public List<DataModel> GetData()
        {
            List<long> temp = new List<long>();
            List<long> tempTeamKeyList = TeamInfo.Keys.ToList<long>();

            for (int i = 1; i <= dataCount; i++)
            {
                dataModel = new DataModel();
                dataModel.TeamID = new Func<long>
                                                   (() =>
                                                   {
                                                       int index = 0;

                                                       while (temp.Contains(tempTeamKeyList[index]))
                                                       {
                                                           index++;
                                                       }
                                                       temp.Add(tempTeamKeyList[index]);
                                                       return tempTeamKeyList[index];
                                                   }
                   ).Invoke();

                dataModel.TeamName = TeamInfo[dataModel.TeamID];
                dataModel.MemberID = GenerateInteger();


                dataModel.PassportNumber = GenerateInteger().ToString();//Changed

                dataModel.MemberName = MemberNames[random.Next(0, MemberNames.Count)];
                dataModel.MemberSurname = MemberSurnames[random.Next(0, MemberSurnames.Count)];
                dataModel.Projects = this.GenerateProjects();

                allData.Add(dataModel);
            }

            return allData;
        }

        //Generate All Projects
        private Project[] GenerateProjects()
        {
            List<long> temp = new List<long>();
            Project[] projects = new Project[projectCount];
            List<long> keyList = ProjectInfo.Keys.ToList<long>();//ProjectInfo

            for (int i = 1; i <= projectCount; i++)
            {
                projects[i - 1] = new Project();
                projects[i - 1].ProjectCreatedDate = GenerateRandomDateTime();
                projects[i - 1].ProjectDueDate = GenerateRandomDateTime(true);
                keyList = Swap(keyList);

                projects[i - 1].ProjectID = new Func<long>
                                                           (() =>
                                                           {
                                                               int index = 0;

                                                               while (temp.Contains(keyList[index]))
                                                               {
                                                                   index++;
                                                               }
                                                               temp.Add(keyList[index]);
                                                               return keyList[index];
                                                           }
                   ).Invoke();

                projects[i - 1].ProjectName = ProjectInfo[projects[i - 1].ProjectID];
                projects[i - 1].ProjectDescription = $"Description - {projects[i - 1].ProjectID + 100}";
            }
            return projects;
        }

        /// <summary>
        /// Generate All information
        /// </summary>
        private void ReadStringValues()
        {
            if (!File.Exists(defoultDataPath))
            {
                MemberNames.Add(DataSource.MemeberName.ToString());
                MemberSurnames.Add(DataSource.MemberSurname.ToString());
                TeamInfo.Add(0, DataSource.TeamName.ToString());
                ProjectInfo.Add(0, DataSource.ProjectName.ToString());
            }
            else
            {
                try
                {
                    using (StreamReader reader = new StreamReader(File.OpenRead(defoultDataPath)))
                    {
                        //Get Member Name
                        string[] values = reader.ReadLine().Split(',');
                        Swap<string>(ref values);
                        foreach (string item in values)
                        {
                            MemberNames.Add(item);
                        }

                        //Get Member Surname
                        values = reader.ReadLine().Split(',');
                        Swap<string>(ref values);
                        foreach (string item in values)
                        {
                            MemberSurnames.Add(item);
                        }
                    }
                    GenerateNameAndID(DataSource.TeamName, TeamInfo, dataCount);
                    GenerateNameAndID(DataSource.ProjectName, ProjectInfo, projectCount);
                }
                catch (FileNotFoundException fnf)
                {
                    throw new Exception("data.dat was not found.", fnf);
                }
            }
        }

        /// <summary>
        /// Generate Name and Id
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="collection"></param>
        /// <param name="count"></param>
        private void GenerateNameAndID(DataSource dataType, Dictionary<long, string> collection, int count)
        {
            long uniqeId = GenerateInteger();
            long index = 0;

            for (int i = 0; i < count; i++)
            {
                index += uniqeId + i;
                collection.Add(Math.Abs(index), dataType.ToString() + Math.Abs(index));
            }
        }

        /// <summary>
        /// Generate Random DateTime
        /// </summary>
        /// <param name="Duadate"></param>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        private DateTime GenerateRandomDateTime(bool Duadate = false, int startYear = 2009, int endYear = 2011)
        {
            if (startYear > endYear)
            {
                int temp = startYear;
                endYear = startYear;
                startYear = temp;
            }

            if (Duadate)
            {
                startYear = endYear + 1;
                endYear = DateTime.Now.Year;
            }

            int year = random.Next(startYear, endYear);
            int month = random.Next(1, 13);
            int maxDay = DateTime.DaysInMonth(year, month);
            int randomDay = random.Next(1, (maxDay + 1));

            return new DateTime(year, month, randomDay);
        }

        /// <summary>
        /// Swaping list 
        /// </summary>
        /// <param name="list"></param>
        private List<long> Swap(List<long> list)
        {
            List<long> tempList = list;
            long temp = 0;
            int index = 0;

            for (int i = 0; i < tempList.Count; i++)
            {
                index = random.Next(0, tempList.Count);
                temp = tempList[index];
                tempList[index] = tempList[i];
                tempList[i] = temp;
            }

            return tempList;
        }

        /// <summary>
        /// Swaping string 
        /// </summary>
        /// <param name="words"></param>
        private void Swap<T>(ref T[] words)
        {
            T temp = default(T);
            int index = 0;

            for (int i = 0; i < words.Length; i++)
            {
                index = random.Next(0, words.Length);
                temp = words[index];
                words[index] = words[i];
                words[i] = temp;
            }
        }


        /// <summary>
        /// Generate Unique integer number
        /// </summary>
        /// <returns></returns>
        private long GenerateInteger()
        {
            return Math.Abs(BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0));
        }

        public void Dispose()
        {

        }
    }
}

