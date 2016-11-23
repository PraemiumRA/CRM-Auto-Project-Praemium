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

        public DataTable Select(Dictionary<string, object> parameters)
        {
            return database.ExecuteSelect(spSelect, parameters);
        }

        public int Delete(Dictionary<string, object> parameters)
        {
            return database.ExecuteInsertUpdateDelete(spDelete, parameters);
        }

        public int Insert(Dictionary<string, object> parameters)
        {
            return database.ExecuteInsertUpdateDelete(spInsertUpdate, parameters);
        }

    }
}
