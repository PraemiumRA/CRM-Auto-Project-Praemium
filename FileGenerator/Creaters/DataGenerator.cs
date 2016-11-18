﻿using System;
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
        private List<DataModel> datas;

        public StringCollection MemberNames = new StringCollection();
        public StringCollection MemberSurnames = new StringCollection();
        public StringCollection TeamNames = new StringCollection();
        public StringCollection ProjectNames = new StringCollection();
        private List<int> ProjectIds = new List<int>();

        private int dataCount = 0;
        private int projectCount = 0;
        private DataModel dataModel;
        private List<int> randNumbers = new List<int>();
        private string defoultDataPath = @"..\..\Creaters\Resourse\defoultData.dat";
        private Random random;
        private StringBuilder builder;

        public DataGenerator(int dataCount, int projectCount)
        {
            this.dataCount = dataCount;
            this.projectCount = projectCount;
            builder = new StringBuilder();
            random = new Random();
            datas = new List<DataModel>(dataCount);
            ReadStringValues();
        }

        /// <summary>
        /// Generate Unique dates
        /// </summary>
        /// <returns></returns>
        public List<DataModel> GetData()
        {
            for (int i = 1; i <= dataCount; i++)
            {
                dataModel = new DataModel();
                dataModel.MemberID = GenerateInteger();
                dataModel.MemberName = MemberNames[random.Next(0, MemberNames.Count)];
                dataModel.MemberSurname = MemberSurnames[random.Next(0, MemberSurnames.Count)];
                dataModel.Projects = this.GenerateProjects();
                dataModel.TeamName = TeamNames[i - 1];
                dataModel.TeamID = Convert.ToInt32(dataModel.TeamName[dataModel.TeamName.Length - 1]) + random.Next(0, 1000);

                datas.Add(dataModel);
            }

            return this.datas;
        }

        /// <summary>
        /// Generate array of projects for single record
        /// </summary>
        /// <returns></returns>
        private Project[] GenerateProjects()
        {
            Project[] projects = new Project[projectCount];
            List<int> tempId = new List<int>();

            for (int i = 1; i <= projectCount; i++)
            {
                projects[i - 1] = new Project();
                projects[i - 1].ProjectCreatedDate = GenerateRandomDateTime();
                projects[i - 1].ProjectDueDate = GenerateRandomDateTime(true);
                projects[i - 1].ProjectName = ProjectNames[i - 1];
                this.Swap(ref ProjectIds);
                projects[i - 1].ProjectID = new Func<int>
                    (() =>
                            {
                                int index = 0;

                                while (tempId.Contains(ProjectIds[index]))
                                {
                                    index++;
                                }
                                tempId.Add(ProjectIds[index]);
                                return ProjectIds[index];
                            }
                    ).Invoke();

                projects[i - 1].ProjectDescription = $"Description - {projects[i - 1].ProjectID + 100}";
            }

            return projects;
        }

        /// <summary>
        /// Generate All ids for Project
        /// </summary>
        private void GenerateAllProjectId()
        {
            int uniqeId = GenerateInteger();
            int index = 0;

            for (int i = 0; i < ProjectNames.Count; i++)
            {
                index += uniqeId + i;
                ProjectIds.Add(Math.Abs(index));
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
        /// Read default data from file, or take
        /// </summary>
        private void ReadStringValues()
        {
            if (!File.Exists(defoultDataPath))
            {
                MemberNames.Add(DataSource.MemeberName.ToString());
                MemberSurnames.Add(DataSource.MemberSurname.ToString());
                TeamNames.Add(DataSource.TeamName.ToString());
                ProjectNames.Add(DataSource.ProjectName.ToString());
            }
            else
            {
                try
                {
                    using (StreamReader reader = new StreamReader(File.OpenRead(defoultDataPath)))
                    {
                        string[] values = reader.ReadLine().Split(',');
                        Swap(ref values);

                        foreach (string item in values)
                        {
                            MemberNames.Add(item);
                        }

                        values = reader.ReadLine().Split(',');
                        Swap(ref values);

                        foreach (string item in values)
                        {
                            MemberSurnames.Add(item);
                        }

                        //Get TeamNames
                        GetNames(DataSource.TeamName, TeamNames, dataCount);

                        //Get ProjectsName
                        GetNames(DataSource.ProjectName, ProjectNames, projectCount);
                        GenerateAllProjectId();
                    }
                }
                catch (FileNotFoundException fnf)
                {
                    throw new Exception("data.dat was not found.", fnf);
                }
               
            }

        }

        /// <summary>
        /// Get Projects and Teams Names
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="collection"></param>
        /// <param name="count"></param>
        private void GetNames(DataSource dataSource, StringCollection collection, int count)
        {
            int i = 0;
            do
            {
                collection.Add(dataSource.ToString() + GenerateInteger());
                i++;
            } while (i < count);
        }

        /// <summary>
        /// Swaping string 
        /// </summary>
        /// <param name="words"></param>
        private void Swap(ref string[] words)
        {
            string temp = "";
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
        /// Swaping integer
        /// </summary>
        /// <param name="words"></param>
        private void Swap(ref List<int> words)
        {
            int temp = 0;
            int index = 0;

            for (int i = 0; i < words.Count; i++)
            {
                index = random.Next(0, words.Count);
                temp = words[index];
                words[index] = words[i];
                words[i] = temp;
            }
        }

        /// <summary>
        /// Generate Unique integer number
        /// </summary>
        /// <returns></returns>
        private int GenerateInteger()
        {
            return Math.Abs(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {

        }
    }
}
