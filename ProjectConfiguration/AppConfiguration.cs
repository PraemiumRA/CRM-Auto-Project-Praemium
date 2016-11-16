using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace ProjectConfiguration
{
    public class AppConfiguration
    {
        private StringBuilder builder = new StringBuilder();

        private bool isStoreToJson;
        private bool isStoreDataBase;
        private bool isLogTxtFile;
        private string watchingDirectory;
        private string jsonCreationDirectory;
        private string txtFileCreationDirectory;

        private int prcentOfMachineCore;

        public bool IsStoreTxtFile
        {
            get { return isLogTxtFile; }
        }
        public string LogTextFileDirectory
        {
            get { return txtFileCreationDirectory; }
        }
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
            StoreToTxtFile();
            TxtFileDirectory();
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
        private void StoreToTxtFile()
        {
            bool temp = false;

            try
            {
                temp = Convert.ToBoolean(ConfigurationManager.AppSettings["LogInTxtFile"] ?? "true");
            }
            catch (Exception)
            {
                //TODO: Logging                
                temp = false;
            }
            this.isLogTxtFile = temp;

        }

        /// <summary>
        /// Get directory for monitoring
        /// </summary>
        private void MonitorDirectory()
        {
            string temp = GetDefoultDirectory("Monitoring");
            try
            {
                temp = ConfigurationManager.AppSettings["MonitoringDirectory"];
                if (string.IsNullOrEmpty(temp))
                    temp = GetDefoultDirectory("Monitoring");
     
                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefoultDirectory("Monitoring");
            }

            this.watchingDirectory = temp;
        }

        /// <summary>
        /// Get directory for writing Json files
        /// </summary>
        private void JsonDirectory()
        {
            string temp = GetDefoultDirectory("JsonDirectory");

            try
            {
                temp = ConfigurationManager.AppSettings["JsonPath"];
                if (string.IsNullOrEmpty(temp))
                    temp = GetDefoultDirectory("JsonDirectory");

                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefoultDirectory("JsonDirectory");
            }


            this.jsonCreationDirectory = temp;
        }

        /// <summary>
        /// Get directory for writing 'log' in txt format
        /// </summary>
        private void TxtFileDirectory()
        {
            string temp = GetDefoultDirectory("TextLogging");
            try
            {
                temp = ConfigurationManager.AppSettings["LogFileDirectory"];
                if (string.IsNullOrEmpty(temp))
                    temp = GetDefoultDirectory("TextLogging");

                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefoultDirectory("TextLogging");
            }

            this.txtFileCreationDirectory = temp;
        }


        /// <summary>
        /// Get default directory
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        private string GetDefoultDirectory(string directoryName)
        {
            string temp =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + directoryName;
            if (!Directory.Exists(temp))
                Directory.CreateDirectory(temp);
            return temp;
        }
    }
}
