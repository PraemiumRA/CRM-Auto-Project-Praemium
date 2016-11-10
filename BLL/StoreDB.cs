using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BLL
{
    class StoreDB
    {
        AppConfiguration appConfig;
        string path;
        string jsonPath;
        bool isJson = false;
        bool isDB = false;

        JsonMaker jsonMaker;

        public StoreDB()
        {
            appConfig = new AppConfiguration();
            isJson = appConfig.IsStoreToJson;
            isDB = appConfig.IsStoreDataBase;
        }

        IStore storeData;
        
        public StoreDB(IStore storeData) : this()
        {
            this.storeData = storeData;
            this.path = storeData.Path;
            this.jsonPath = storeData.jsonPath;

            StoreDataFromFile();
        }

        public void StoreDataFromFile()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
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
                            SqlCommand command = new SqlCommand("spDynamicInsertOrUpdate", connection, transaction);

                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@TeamID", currentDataModel.TeamID);
                            command.Parameters.AddWithValue("@TeamName", currentDataModel.TeamName);
                            command.Parameters.AddWithValue("@MemberID", currentDataModel.MemberID);
                            command.Parameters.AddWithValue("@MemberName", currentDataModel.MemberName);
                            command.Parameters.AddWithValue("@MemberSurname", currentDataModel.MemberSurname);

                            for (int i = 0; i < currentDataModel.Projects.Length; i++)
                            {
                                command.Parameters.AddWithValue("@ProjectID", currentDataModel.Projects[i].ProjectID);
                                command.Parameters.AddWithValue("@ProjectName", currentDataModel.Projects[i].ProjectName);
                                command.Parameters.AddWithValue("@ProjectCreatedDate", currentDataModel.Projects[i].ProjectCreatedDate);
                                command.Parameters.AddWithValue("@ProjectDueDate", currentDataModel.Projects[i].ProjectDueDate);
                                command.Parameters.AddWithValue("@ProjectDescription", currentDataModel.Projects[i].ProjectDescription);

                                command.ExecuteNonQuery();
                                command.Parameters.RemoveAt("@ProjectID");
                                command.Parameters.RemoveAt("@ProjectName");
                                command.Parameters.RemoveAt("@ProjectCreatedDate");
                                command.Parameters.RemoveAt("@ProjectDueDate");
                                command.Parameters.RemoveAt("@ProjectDescription");

                            }
                            command.Dispose();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //TODO: Loging
                }
            }
        }
        
    }
}
