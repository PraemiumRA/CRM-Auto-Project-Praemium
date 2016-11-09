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
        //Fileds
        bool isStoreToJson;
        bool isStoreDataBase;
        int prcentOfMachineCore;
        string watchingDirectory;

        public AppConfiguration()
        {
            MonitorDirectory();
            PrcentOfMachineCore();
            StoreToDataBase();
            StoreToJson();
        }

        //Propertes
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

        //Methods
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
            this.isStoreDataBase= temp;
            
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
            string temp = @".\..\..\..\MonitoringDirectory\"; 
            try
            {
                temp = ConfigurationManager.AppSettings["MonitoringDirectory"] ?? GetMonitoringDirectory();
            }
            catch (Exception)
            {
                temp = GetMonitoringDirectory();
            }
            if (!Directory.Exists(temp))
                Directory.CreateDirectory(temp);

            this.watchingDirectory = temp;
            
        }
        private string GetMonitoringDirectory()
        {
            string directoryName = @".\..\..\..\..\MonitoringDirectory";

            DirectoryInfo directory = new DirectoryInfo(directoryName);
            if (!directory.Exists)
            {
                directory = Directory.CreateDirectory(directoryName);
            }
            
            return directory.FullName;
        }

      
    }
}
