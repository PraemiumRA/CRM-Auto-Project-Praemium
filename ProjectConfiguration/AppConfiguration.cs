using System;
using System.Configuration;
using System.IO;

namespace ProjectConfiguration
{
    /// <summary>
    /// Configuration class for application settings 
    /// </summary>
    public class AppConfiguration
    {
        private static AppConfiguration instance = null;

        /// <summary>
        /// Get Single instance of object
        /// </summary>
        public static AppConfiguration GetInstance
        {
            get
            {
                return instance ?? new AppConfiguration();
            }
        }

        public int GetPrecntOfMachineCore
        {
            get { return PrcentOfMachineCore(); }
        }
        public bool IsStoreTxtFile
        {
            get { return StoreToTxtFile(); }
        }
        public bool IsStoreToJson
        {
            get { return StoreToJson(); }
        }
        public bool IsStoreDataBase
        {
            get { return StoreToDataBase(); }
        }
        public string LogTextFileDirectory
        {
            get { return TxtFileDirectory(); }
        }
        public string GetToMnitorDirectory
        {
            get { return MonitorDirectory(); }
        }
        public string JsonCreationDirectory
        {
            get { return JsonDirectory(); }
        }
        public string WrongFilesDirectory
        {
            get { return WrongDirectory(); }
        }

        private AppConfiguration() { }

        /// <summary>
        /// Get percentages of machine core, which will determine the number of threads.
        /// </summary>
        /// <returns></returns>
        private int PrcentOfMachineCore()
        {
            int temp = 50;
            try
            {
                temp = Convert.ToInt32(ConfigurationManager.AppSettings["PrcentOfCore"]);
            }
            catch (Exception)
            {
                temp = 50;
            }

            return temp;
        }

        /// <summary>
        /// Switch data to database.
        /// </summary>
        /// <returns></returns>
        private bool StoreToDataBase()
        {
            bool temp = false;

            try
            {
                temp = Convert.ToBoolean(ConfigurationManager.AppSettings["StorDataInDB"]);
            }
            catch (Exception)
            {              
                temp = false;
            }
            return temp;
        }

        /// <summary>
        /// Switch data to json file.
        /// </summary>
        /// <returns></returns>
        private bool StoreToJson()
        {
            bool temp = false;
            try
            {
                temp = Convert.ToBoolean(ConfigurationManager.AppSettings["StorDataInJSON"]);
            }
            catch
            {               
                temp = false;
            }

            return temp;
        }

        /// <summary>
        /// Switch logging to text file.
        /// </summary>
        /// <returns></returns>
        private bool StoreToTxtFile()
        {
            bool temp = false;
            try
            {
                temp = Convert.ToBoolean(ConfigurationManager.AppSettings["LogInTxtFile"]);
            }
            catch (Exception)
            {          
                temp = false;
            }

            return temp;
        } 

        /// <summary>
        /// Get directory for monitoring
        /// </summary>
        private string MonitorDirectory()
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

            return temp;
        }

        /// <summary>
        /// Get directory for writing Json files
        /// </summary>
        private string JsonDirectory()
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
            return temp;
        }

        /// <summary>
        /// Get directory for writing 'log' in txt format
        /// </summary>
        private string TxtFileDirectory()
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

            return temp;
        }

        /// <summary>
        /// Get Directory for Wrong Files
        /// </summary>
        /// <returns></returns>
        private string WrongDirectory()
        {
            string temp = GetDefoultDirectory("WrongFiles");
            try
            {
                temp = ConfigurationManager.AppSettings["WrongFilesDirectory"];

                if (string.IsNullOrEmpty(temp))
                    temp = GetDefoultDirectory("WrongFiles");

                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefoultDirectory("WrongFiles");
            }

            return temp;
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
