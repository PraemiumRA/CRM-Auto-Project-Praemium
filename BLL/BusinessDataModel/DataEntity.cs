using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessDataModel
{
    /// <summary>
    /// Transfers parameters to DAL.
    /// </summary>
    public abstract class DataEntity
    {
        public abstract DataSet TableName { get; }

        protected Database database;

        protected DataEntity()
        {
            database = new Database(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        }

        protected abstract string spSelect { get; }
        protected abstract string spInsertUpdate { get; }
        protected abstract string spDelete { get; }

        /// <summary>
        /// Selects data from database based on parameters.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable Select(Dictionary<string, object> parameters)
        {
            return database.ExecuteSelect(spSelect, parameters);
        }

        /// <summary>
        /// Deletes data from database based on parameters.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int Delete(Dictionary<string, object> parameters)
        {
            return database.ExecuteInsertUpdateDelete(spDelete, parameters);
        }

        /// <summary>
        /// Inserts/Updates data to/in databes based on parameters.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int InsertOrUpdate(Dictionary<string, object> parameters)
        {
            return database.ExecuteInsertUpdateDelete(spInsertUpdate, parameters);
        }

    }
}
