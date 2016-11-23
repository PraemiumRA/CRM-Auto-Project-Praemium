﻿using Logging;
using ProjectConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.BusinessDataModel
{
    public sealed class TablesData : DataEntity
    {
        AppConfiguration appConfig = AppConfiguration.GetInstance;

        public DataTable dataTableValue { get; set; }
        JsonMaker jsonMaker;
        IStore storeData;
        string path;
        string jsonPath;
        bool isJson = false;
        bool isDB = false;
        bool isWrittenDB = false;

        public TablesData()
        {
            isJson = appConfig.IsStoreToJson;
            isDB = appConfig.IsStoreDataBase;
        }
        public TablesData(IStore storeData) : this()
        {
            this.storeData = storeData;
            this.path = storeData.path;
            this.jsonPath = storeData.jsonPath;
            StoreDataFromFile();
        }

        protected override string spDelete
        {
            get { return "spDynamicDelete"; }
        }

        protected override string spInsertUpdate
        {
            get { return "spDynamicInsertOrUpdate"; }
        }

        protected override string spSelect
        {
            get { return "spDynamicSelection"; }
        }

        public override DataSet TableName
        {
            get { return TablesCreation(); }
        }


        /// <summary>
        /// Selects data from database.
        /// </summary>
        /// <param name="value">selected value</param>
        /// <param name="comboboxValue">selected type</param>
        /// <returns></returns>
        public DataTable SelectBy(object value, string comboboxValue)
        {
            if (comboboxValue == "AllTeams" || comboboxValue == "AllMembers" || comboboxValue == "AllProjects")
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@"+comboboxValue, true }
                };
                return Select(parameters);
            }
            else
            {
                try
                {
                    IdValueCheaker(value, comboboxValue);
                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@"+comboboxValue, value }
                    };
                    return Select(parameters);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    LogManager.DoLogging(LogType.Warning, ex);
                    return null;
                }
            }
        }
        public int DeleteBy(object value, string comboboxValue, ref bool wasException, string selectedValue = null)
        {
            try
            {
                if (selectedValue != null)
                {
                    Dictionary<string, object> param = new Dictionary<string, object>
                    {
                        { "@SelectedValue", selectedValue }
                    };
                    return Delete(param);
                }

                IdValueCheaker(value, comboboxValue);
                Dictionary<string, object> parameters = new Dictionary<string, object>
                 {
                     { "@"+comboboxValue, value }
                 };
                return Delete(parameters);
            }
            catch (Exception ex)
            {
                wasException = true;
                MessageBox.Show(ex.Message);
                LogManager.DoLogging(LogType.Warning, ex);
                return 0;
            }
        }

        private void IdValueCheaker(object textBoxValue, string comboBoxValue)
        {
            long idValue;
            DateTime dateTimeValue;

            if ((comboBoxValue == "TeamID" || comboBoxValue == "MemberID" || comboBoxValue == "ProjectID" || comboBoxValue == "MemberProjectID"))
            {
                if (long.TryParse(textBoxValue.ToString(), out idValue))
                {
                    if (idValue <= 0)
                    {
                        throw new ArgumentOutOfRangeException("Argument must be bigger than '0' ");
                    }
                }
                else
                {
                    throw new FormatException("Argument must be a number");
                }
            }
            else if (comboBoxValue == "ProjectCreatedDate" || comboBoxValue == "ProjectDueDate")
            {
                if (!DateTime.TryParse(textBoxValue.ToString(), out dateTimeValue))
                {
                    throw new FormatException("Argument must be Date format");
                }
            }
        }

        public int InsertBy(DataSet dataSet)
        {
            string[] spInsertParameters = new string[] { "@teamData", "@memberData", "@projectData", "@memberProjectData" };

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            for (int i = 0; i < spInsertParameters.Length; i++)
            {
                parameters.Add(spInsertParameters[i], dataSet.Tables[i]);
            }

            return Insert(parameters);
        }

        public void StoreDataFromFile()
        {
            try
            {
                DataSet dataSet = TablesCreation();

                foreach (var currentDataModel in storeData.Read())
                {
                    if (isJson)
                    {
                        jsonMaker = new JsonMaker(currentDataModel, path, jsonPath);
                    }

                    if (isDB)
                    {
                        dataSet.Tables["Team"].Rows.Add(currentDataModel.TeamID, currentDataModel.TeamName);
                        dataSet.Tables["Member"].Rows.Add(currentDataModel.MemberID, currentDataModel.TeamID, currentDataModel.PassportNumber, currentDataModel.MemberName, currentDataModel.MemberSurname);

                        for (int i = 0; i < currentDataModel.Projects.Length; i++)
                        {
                            DataRow[] foundProjects = dataSet.Tables["Project"].Select("ProjectID = '" + currentDataModel.Projects[i].ProjectID.ToString() + "'");
                            if (foundProjects.Length == 0)
                            {
                                dataSet.Tables["Project"].Rows.Add(currentDataModel.Projects[i].ProjectID, currentDataModel.Projects[i].ProjectName, currentDataModel.Projects[i].ProjectCreatedDate,
                                                      currentDataModel.Projects[i].ProjectDueDate, currentDataModel.Projects[i].ProjectDescription);
                            }
                            dataSet.Tables["MemberProject"].Rows.Add(currentDataModel.MemberID, currentDataModel.Projects[i].ProjectID);
                        }
                    }
                }

                InsertBy(dataSet);
            }
            catch (Exception ex)
            {
                LogManager.DoLogging(LogType.Error, ex, "Error in process to storing/updating data.");
                MessageBox.Show(ex.Message);
                isWrittenDB = true;
            }

            if (isJson && !jsonMaker.isWrittenJson)
            {
                LogManager.DoLogging(LogType.Success, null, "Data succesfuly stored in json format.");
                jsonMaker.isWrittenJson = true;
            }

            if (isDB && !isWrittenDB)
            {
                LogManager.DoLogging(LogType.Success, null, "Data succesfuly stored in Data Base. ");
                isWrittenDB = true;
            }
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                LogManager.DoLogging(LogType.Error, ex);
            }
        }

        private DataSet TablesCreation()
        {
            DataSet dataSet = new DataSet();

            DataTable teamTable = new DataTable("Team");
            teamTable.Columns.Add("TeamID", typeof(long));
            teamTable.Columns.Add("TeamName", typeof(string));

            DataTable memberTable = new DataTable("Member");
            memberTable.Columns.Add("MemberID", typeof(long));
            memberTable.Columns.Add("TeamID", typeof(long));
            memberTable.Columns.Add("PassportNumber", typeof(string));
            memberTable.Columns.Add("MemberName", typeof(string));
            memberTable.Columns.Add("MemberSurname", typeof(string));

            DataTable projectTable = new DataTable("Project");
            projectTable.Columns.Add("ProjectID", typeof(long));
            projectTable.Columns.Add("ProjectName", typeof(string));
            projectTable.Columns.Add("ProjectCreatedDate", typeof(DateTime));
            projectTable.Columns.Add("ProjectDueDate", typeof(DateTime));
            projectTable.Columns.Add("ProjectDescription", typeof(string));

            DataTable memberProjectTable = new DataTable("MemberProject");
            memberProjectTable.Columns.Add("MemberID", typeof(long));
            memberProjectTable.Columns.Add("ProjectID", typeof(long));

            dataSet.Tables.AddRange(new DataTable[] { teamTable, memberTable, projectTable, memberProjectTable });
            return dataSet;
        }
    }
}
