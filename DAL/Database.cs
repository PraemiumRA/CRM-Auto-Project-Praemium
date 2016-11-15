﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logging;

namespace DAL
{
    public class Database
    {
        internal string connectionString { get; }
        public int affectedRowsCount;

        public Database(string ConnectionString)
        {
            this.connectionString = ConnectionString;
        }

        public int ExecuteInsertUpdateDelete(string spName, Dictionary<string, object> parameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand(spName, sqlConnection, transaction))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        foreach (KeyValuePair<string, object> parameter in parameters)
                        {
                            sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                        affectedRowsCount = sqlCommand.ExecuteNonQuery();

                        Logger.DoLogging(LogType.Success, null, "Data succesfuly stored in Data Base.");

                        transaction.Commit();
                    }
                }
                catch(System.Exception exception)
                {
                    transaction.Rollback();
                    Logger.DoLogging(LogType.Error, exception, "Error in process to storing data.");
                }
                return affectedRowsCount;
            }
        }

        public DataTable ExecuteSelect(string spName, Dictionary<string, object> parameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(spName, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sqlDataAdapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}
