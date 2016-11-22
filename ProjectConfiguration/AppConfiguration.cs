using System;
using System.Configuration;
using System.IO;

namespace ProjectConfiguration
{
    /// <summary>
    /// Configuration class for application settings. 
    /// </summary>
    public class AppConfiguration
    {
        private static AppConfiguration instance = null;

        /// <summary>
        /// Gets single reference of object.
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
        /// Gets percentages of machine core, which will determine the number of threads.
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
        /// Database storing switcher.
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
        /// JSON storing switcher.
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
        /// Text file logging switcher.
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
        /// Gets directory for monitoring.
        /// </summary>
        private string MonitorDirectory()
        {
            string temp = GetDefaultDirectory("Monitoring");
            try
            {
                temp = ConfigurationManager.AppSettings["MonitoringDirectory"];
                if (string.IsNullOrEmpty(temp))
                    temp = GetDefaultDirectory("Monitoring");
     
                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefaultDirectory("Monitoring");
            }

            return temp;
        }

        /// <summary>
        /// Gets directory for Json files creation.
        /// </summary>
        private string JsonDirectory()
        {
            string temp = GetDefaultDirectory("JsonDirectory");

            try
            {
                temp = ConfigurationManager.AppSettings["JsonPath"];
                if (string.IsNullOrEmpty(temp))
                    temp = GetDefaultDirectory("JsonDirectory");

                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefaultDirectory("JsonDirectory");
            }
            return temp;
        }

        /// <summary>
        /// Gets directory for writing 'log' in txt format.
        /// </summary>
        private string TxtFileDirectory()
        {
            string temp = GetDefaultDirectory("TextLogging");
            try
            {
                temp = ConfigurationManager.AppSettings["LogFileDirectory"];
                if (string.IsNullOrEmpty(temp))
                    temp = GetDefaultDirectory("TextLogging");

                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefaultDirectory("TextLogging");
            }

            return temp;
        }

        /// <summary>
        /// Gets directory for storing wrong files.
        /// </summary>
        /// <returns></returns>
        private string WrongDirectory()
        {
            string temp = GetDefaultDirectory("WrongFiles");
            try
            {
                temp = ConfigurationManager.AppSettings["WrongFilesDirectory"];

                if (string.IsNullOrEmpty(temp))
                    temp = GetDefaultDirectory("WrongFiles");

                if (!Directory.Exists(temp))
                    Directory.CreateDirectory(temp);
            }
            catch (Exception)
            {
                temp = GetDefaultDirectory("WrongFiles");
            }

            return temp;
        }

        /// <summary>
        /// Gets default directory.
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        private string GetDefaultDirectory(string directoryName)
        {
            string temp =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + directoryName;
            if (!Directory.Exists(temp))
                Directory.CreateDirectory(temp);
            return temp;
        }
    }
}
