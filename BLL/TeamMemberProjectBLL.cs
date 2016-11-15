using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        AppConfiguration appConfig;
        private DataModel dataModel;
        private Database database;
        public DataTable dataTableValue { get; set; }
        JsonMaker jsonMaker;
        IStore storeData;
        object textBoxValue;
        string comboBoxValue;
        string path;
        string jsonPath;
        int idValue;
        bool isJson = false;
        bool isDB = false;

        public TeamMemberProjectBLL()
        {
            database = new Database(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            appConfig = new AppConfiguration();
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

        public TeamMemberProjectBLL(object TextBoxValue, string ComboBoxValue)
        {
            database = new Database(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            dataModel = new DataModel();
            this.comboBoxValue = ComboBoxValue;
            this.textBoxValue = TextBoxValue;
        }

        public void DeleteAsync()
        {
            try
            {
                IdValueCheaker();

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                switch (comboBoxValue)
                {
                    case "TeamID":
                        {
                            parameters.Add("@TeamID", Convert.ToInt32(textBoxValue));
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
                            parameters.Add("@MemberID", Convert.ToInt32(textBoxValue));
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
                            parameters.Add("@ProjectID", Convert.ToInt32(textBoxValue));
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
                if (database.affectedRowsCount != 0)
                    MessageBox.Show(string.Format("{0} row(s) were deleted", database.affectedRowsCount.ToString()));

                else MessageBox.Show(string.Format("'{0}' does not exist in {1} column", textBoxValue, comboBoxValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.DoLogging(LogType.Error, ex);
            }
        }
        public void SelectAsync()
        {
            try
            {
                IdValueCheaker();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                switch (comboBoxValue)
                {
                    case "TeamID":
                        {
                            parameters.Add("@TeamID", Convert.ToInt32(textBoxValue));
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "TeamName":
                        {
                            parameters.Add("@TeamName", textBoxValue);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "MemberID":
                        {
                            parameters.Add("@MemberID", Convert.ToInt32(textBoxValue));
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
                    case "ProjectID":
                        {
                            parameters.Add("@ProjectID", Convert.ToInt32(textBoxValue));
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
                    case "AllMembers":
                        {
                            parameters.Add("@All", 1);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "AllTeams":
                        {
                            parameters.Add("@All", 2);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "AllProjects":
                        {
                            parameters.Add("@All", 3);
                            dataTableValue = database.ExecuteSelect("spDynamicSelection", parameters);
                            break;
                        }
                    case "All":
                        {
                            parameters.Add("@All", 4);
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
                Logger.DoLogging(LogType.Error, ex);
            }
        }
        private void IdValueCheaker()
        {
            if ((comboBoxValue == "TeamID" || comboBoxValue == "MemberID" || comboBoxValue == "ProjectID" || comboBoxValue == "MemberProjectID"))
            {

                if (int.TryParse(textBoxValue.ToString(), out idValue))
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
        }
        public void StoreDataFromFile()
        {
            try
            {
                foreach (var currentDataModel in storeData.Read())
                {
                    if (isJson)
                    {
                        jsonMaker = new JsonMaker(currentDataModel, path, jsonPath);
                    }

                    if (isDB)
                    {
                        Dictionary<string, object> parameters = new Dictionary<string, object>();

                        parameters.Add("@TeamID", currentDataModel.TeamID);
                        parameters.Add("@TeamName", currentDataModel.TeamName);
                        parameters.Add("@MemberID", currentDataModel.MemberID);
                        parameters.Add("@MemberName", currentDataModel.MemberName);
                        parameters.Add("@MemberSurname", currentDataModel.MemberSurname);

                        for (int i = 0; i < currentDataModel.Projects.Length; i++)
                        {
                            parameters.Add("@ProjectID", currentDataModel.Projects[i].ProjectID);
                            parameters.Add("@ProjectName", currentDataModel.Projects[i].ProjectName);
                            parameters.Add("@ProjectCreatedDate", currentDataModel.Projects[i].ProjectCreatedDate);
                            parameters.Add("@ProjectDueDate", currentDataModel.Projects[i].ProjectDueDate);
                            parameters.Add("@ProjectDescription", currentDataModel.Projects[i].ProjectDescription);

                            database.ExecuteInsertUpdateDelete("spDynamicInsertOrUpdate", parameters);
                            parameters.Remove("@ProjectID");
                            parameters.Remove("@ProjectName");
                            parameters.Remove("@ProjectCreatedDate");
                            parameters.Remove("@ProjectDueDate");
                            parameters.Remove("@ProjectDescription");
                        }
                    }
                }

                File.Delete(path);

                Logger.DoLogging(LogType.Success, null, "Data succesfuly stored in Data Base.");
            }
            catch (Exception ex)
            {
                Logger.DoLogging(LogType.Error, ex, "Error in process to storing data.");
                MessageBox.Show(ex.Message);
                //TODO: Loging
            }

        }

    }
}
