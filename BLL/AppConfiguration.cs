using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace BLL
{
    public class AppConfiguration
    {

        private bool isStoreToJson;
        private bool isStoreDataBase;
        private int prcentOfMachineCore;
        private string watchingDirectory;
        private string jsonCreationDirectory;

        public bool IsStoreToJson
        {
            get { return isStoreToJson; }
        }
        public bool IsStoreDataBase
        {
            get { return isStoreDataBase; }
        }
        public int GetPrecntOfMachineCore
        {
            get { return this.prcentOfMachineCore; }
        }
        public string GetToMnitorDirectory
        {
            get { return this.watchingDirectory; }
        }
        public string JsonCreationDirectory
        {
            get { return this.jsonCreationDirectory; }
        }

        public AppConfiguration()
        {
            MonitorDirectory();
            PrcentOfMachineCore();
            StoreToDataBase();
            StoreToJson();
            JsonDirectory();
        }

        private void StoreToDataBase()
        {
            bool temp = false;

            try
            {
                temp = Convert.ToBoolean(ConfigurationManager.AppSettings["StorDataInDB"] ?? "true");
            }
            catch (Exception)
            {
                //TODO: Logging                
                temp = false;
            }
            this.isStoreDataBase = temp;

        }
        private void StoreToJson()
        {
            bool temp = false;
            try
            {
                temp = Convert.ToBoolean(ConfigurationManager.AppSettings["StorDataInJSON"] ?? "true");
            }
            catch (Exception)
            {
                //TODO: Logging                
                temp = false;
            }
            this.isStoreToJson = temp;
        }
        private void PrcentOfMachineCore()
        {
            int temp = 50;
            try
            {
                temp = Convert.ToInt32(ConfigurationManager.AppSettings["PrcentOfCore"]);
            }
            catch (Exception)
            {
                //TODO: Logging
                temp = 50;
            }
            this.prcentOfMachineCore = temp;
        }
        private void MonitorDirectory()
        {
            string temp = GetMonitoringDefoultDirectory();
            try
            {
                temp = ConfigurationManager.AppSettings["MonitoringDirectory"] ?? GetMonitoringDefoultDirectory();
                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetMonitoringDefoultDirectory();
            }

            this.watchingDirectory = temp;

        }
        private void JsonDirectory()
        {
            string temp = GetMonitoringDefoultDirectory();
            try
            {
                temp = ConfigurationManager.AppSettings["JsonPath"] ?? GetMonitoringDefoultDirectory();
                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetMonitoringDefoultDirectory();
            }

            this.jsonCreationDirectory = temp;
        }

        //Default
        private string GetMonitoringDefoultDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }


    }
}
