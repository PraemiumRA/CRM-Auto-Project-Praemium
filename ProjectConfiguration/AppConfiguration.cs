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
        private void MonitorDirectory()
        {
            string temp = GetDefoultDirectoryForMonitoring();
            try
            {
                temp = ConfigurationManager.AppSettings["MonitoringDirectory"] ?? GetDefoultDirectoryForMonitoring();
                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefoultDirectoryForMonitoring();
            }

            this.watchingDirectory = temp;
        }
        private void JsonDirectory()
        {
            string temp = GetDefoultDirectoryForJson();

            try
            {
                temp = ConfigurationManager.AppSettings["JsonPath"] ?? GetDefoultDirectoryForJson();
                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefoultDirectoryForJson();
            }


            this.jsonCreationDirectory = temp;
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
        private void TxtFileDirectory()
        {
            string temp = GetDefoultDirectoryForTxtFile();

            try
            {
                temp = ConfigurationManager.AppSettings["LogFileDirectory"] ?? GetDefoultDirectoryForTxtFile();
                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefoultDirectoryForTxtFile();
            }

            this.txtFileCreationDirectory = temp;
        }

        /// <summary>
        /// Get default Txt directory
        /// </summary>
        /// <returns></returns>
        private string GetDefoultDirectoryForTxtFile()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\LoggingTXT";
        }

        /// <summary>
        /// Get default Monitoring directory
        /// </summary>
        /// <returns></returns>
        private string GetDefoultDirectoryForMonitoring()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Monitoring";
        }

        /// <summary>
        /// Get default Json directory
        /// </summary>
        /// <returns></returns>
        private string GetDefoultDirectoryForJson()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\JsonDirectory";
        }

    }
}
