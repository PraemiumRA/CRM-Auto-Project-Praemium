using System;
using System.Collections.Generic;
using DAL;
using DataModelLibrary;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using ProjectConfiguration;
using Logging;

namespace BLL
{
    public class TeamMemberProjectBLL
    {
        AppConfiguration appConfig = AppConfiguration.GetInstance;
        private DataModel dataModel;
        private Database database;
        public DataTable dataTableValue { get; set; }
        JsonMaker jsonMaker;
        IStore storeData;
        object textBoxValue;
        string comboBoxValue;
        string path;
        string jsonPath;
        DateTime dateTimeValue;
        string selectedValue;
        long idValue;
        bool isJson = false;
        bool isDB = false;
        bool isWrittenDB = false;

        public TeamMemberProjectBLL()
        {
            database = new Database(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            isJson = appConfig.IsStoreToJson;
            isDB = appConfig.IsStoreDataBase;
        }

        public TeamMemberProjectBLL(IStore storeData) : this()
        {
            this.storeData = storeData;
            this.path = storeData.path;
            this.jsonPath = storeData.jsonPath;

            StoreDataFromFile();
        }

        public TeamMemberProjectBLL(object TextBoxValue, string ComboBoxValue, string SelectedValue = null)
        {
            database = new Database(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            dataModel = new DataModel();
            this.comboBoxValue = ComboBoxValue;
            this.textBoxValue = TextBoxValue;
            this.selectedValue = SelectedValue;
        }

        public void DeleteAsync()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                if (selectedValue != null)
                {
                    parameters.Add("@SelectedValue", selectedValue);
                    database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                }

                try
                {
                    IdValueCheaker();
                }
                catch
                {
                    return;
                }

                switch (comboBoxValue)
                {
                    case "TeamID":
                        {
                            parameters.Add("@TeamID", Convert.ToInt64(textBoxValue));
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                    case "TeamName":
                        {
                            parameters.Add("@TeamName", textBoxValue);
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                    case "MemberID":
                        {
                            parameters.Add("@MemberID", Convert.ToInt64(textBoxValue));
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                    case "PassportNumber":
                        {
                            parameters.Add("@PassportNumber", textBoxValue);
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                    case "MemberName":
                        {
                            parameters.Add("@MemberName", textBoxValue);
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                    case "MemberSurname":
                        {
                            parameters.Add("@MemberSurname", textBoxValue);
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                    case "ProjectID":
                        {
                            parameters.Add("@ProjectID", Convert.ToInt64(textBoxValue));
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                    case "ProjectName":
                        {
                            parameters.Add("@ProjectName", textBoxValue);
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                    case "ProjectCreatedDate":
                        {
                            parameters.Add("@ProjectCreatedDate", Convert.ToDateTime(textBoxValue));
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                    case "ProjectDueDate":
                        {
                            parameters.Add("@ProjectDueDate", Convert.ToDateTime(textBoxValue));
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                    case "MemberProjectID":
                        {
                            parameters.Add("@MemberProjectID", Convert.ToInt32(textBoxValue));
                            database.ExecuteInsertUpdateDelete("spDynamicDelete", parameters);
                            break;
                        }
                }
                if (database.affectedRowsCount > 0)
                    MessageBox.Show(string.Format("{0} row(s) were deleted", database.affectedRowsCount.ToString()));
                else if (string.IsNullOrEmpty(textBoxValue.ToString()))
                    MessageBox.Show("Choose the line to delete");
                else MessageBox.Show(string.Format("'{0}' does not exist in {1} column", textBoxValue, comboBoxValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LogManager.DoLogging(LogType.Error, ex);
            }
        }
        public void SelectAsync()
        {
            try
            {
                try
                {
                    IdValueCheaker();
                }
                catch
                {
                    return;
                }
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                switch (comboBoxValue)
                {
                    case "TeamName":
                        {
                            parameters.Add("@TeamName", textBoxValue);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "PassportNumber":
                        {
                            parameters.Add("@PassportNumber", textBoxValue);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "MemberName":
                        {
                            parameters.Add("@MemberName", textBoxValue);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "MemberSurname":
                        {
                            parameters.Add("@MemberSurname", textBoxValue);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "ProjectName":
                        {
                            parameters.Add("@ProjectName", textBoxValue);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "ProjectCreatedDate":
                        {
                            parameters.Add("@ProjectCreatedDate", Convert.ToDateTime(textBoxValue));
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "ProjectDueDate":
                        {
                            parameters.Add("@ProjectDueDate", Convert.ToDateTime(textBoxValue));
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "AllTeams":
                        {
                            parameters.Add("@AllTeams", true);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "AllMembers":
                        {
                            parameters.Add("@AllMembers", true);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    
                    case "AllProjects":
                        {
                            parameters.Add("@AllProjects",true);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Can't find the column");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LogManager.DoLogging(LogType.Error, ex);
            }
        }
        private void IdValueCheaker()
        {
            if ((comboBoxValue == "TeamID" || comboBoxValue == "MemberID" || comboBoxValue == "ProjectID" || comboBoxValue == "MemberProjectID"))
            {
                if (long.TryParse(textBoxValue.ToString(), out idValue))
                {
                    if (idValue <= 0)
                    {
                        MessageBox.Show("Argument must be bigger than '0'");
                        LogManager.DoLogging(LogType.Warning, null, "Argument must be bigger than '0'");
                        throw new ArgumentOutOfRangeException("Argument must be bigger than '0' ");
                    }
                }
                else
                {
                    MessageBox.Show("Argument must be a number");
                    LogManager.DoLogging(LogType.Warning, null, "Argument must be a number");
                    throw new FormatException("Argument must be a number");
                }
            }
            else if (comboBoxValue == "ProjectCreatedDate" || comboBoxValue == "ProjectDueDate")
            {
                if (!DateTime.TryParse(textBoxValue.ToString(), out dateTimeValue))
                {
                    MessageBox.Show("Argument must be Date format");
                    LogManager.DoLogging(LogType.Warning, null, "Argument must be Date format");
                    throw new FormatException("Argument must be Date format");
                }
            }
        }
        public void StoreDataFromFile()
        {
            try
            {
                DataTable teamTable = new DataTable();
                teamTable.Columns.Add("TeamID", typeof(long));
                teamTable.Columns.Add("TeamName", typeof(string));

                DataTable memberTable = new DataTable();
                memberTable.Columns.Add("MemberID", typeof(long));
                memberTable.Columns.Add("TeamID", typeof(long));
                memberTable.Columns.Add("PassportNumber", typeof(string));
                memberTable.Columns.Add("MemberName", typeof(string));
                memberTable.Columns.Add("MemberSurname", typeof(string));

                DataTable projectTable = new DataTable();
                projectTable.Columns.Add("ProjectID", typeof(long));
                projectTable.Columns.Add("ProjectName", typeof(string));
                projectTable.Columns.Add("ProjectCreatedDate", typeof(DateTime));
                projectTable.Columns.Add("ProjectDueDate", typeof(DateTime));
                projectTable.Columns.Add("ProjectDescription", typeof(string));

                DataTable memberProjectTable = new DataTable();
                memberProjectTable.Columns.Add("MemberID", typeof(long));
                memberProjectTable.Columns.Add("ProjectID", typeof(long));

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                foreach (var currentDataModel in storeData.Read())
                {
                    if (isJson)
                    {
                        jsonMaker = new JsonMaker(currentDataModel, path, jsonPath);
                    }

                    if (isDB)
                    {

                        teamTable.Rows.Add(currentDataModel.TeamID, currentDataModel.TeamName);
                        memberTable.Rows.Add(currentDataModel.MemberID, currentDataModel.TeamID,currentDataModel.PassportNumber, currentDataModel.MemberName, currentDataModel.MemberSurname);

                        for (int i = 0; i < currentDataModel.Projects.Length; i++)
                        {
                            DataRow[] foundProjects = projectTable.Select("ProjectID = '" + currentDataModel.Projects[i].ProjectID.ToString() + "'");
                            if (foundProjects.Length == 0)
                            {
                                projectTable.Rows.Add(currentDataModel.Projects[i].ProjectID, currentDataModel.Projects[i].ProjectName, currentDataModel.Projects[i].ProjectCreatedDate,
                                                      currentDataModel.Projects[i].ProjectDueDate, currentDataModel.Projects[i].ProjectDescription);
                            }
                            memberProjectTable.Rows.Add(currentDataModel.MemberID, currentDataModel.Projects[i].ProjectID);
                        }

                    }
                }

                parameters.Add("@teamData", teamTable);
                parameters.Add("@memberData", memberTable);
                parameters.Add("@projectData", projectTable);
                parameters.Add("@memberProjectData", memberProjectTable);

                database.ExecuteInsertUpdateDelete("spDynamicInsertOrUpdate", parameters);
                               
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
    }
}