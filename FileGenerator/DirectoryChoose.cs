using System;
using System.IO;
using System.Configuration;

namespace FileGenerator
{
    /// <summary>
    /// Directory choice class
    /// </summary>
    class DirectoryChoose
    {
        string fileDirectory;

        /// <summary>
        /// Get Directory for creating file
        /// </summary>
        /// <returns></returns>
        public string GetDirectoryPath()
        {
            string tempDirectory = "";
            try
            {
                tempDirectory = ConfigurationManager.AppSettings["Path"] ?? GetGenerateDirectory();
            }
            catch 
            {
                //TODO: Logging
                tempDirectory = GetGenerateDirectory();
            }

            if (!IsDirectoryExist(tempDirectory))
                tempDirectory = GetGenerateDirectory();

            return tempDirectory;
        }

        /// <summary>
        /// Generate
        /// </summary>
        /// <returns></returns>
        private string GetGenerateDirectory()
        {
            string directoryName = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);

            return directoryName;
        }
       

        /// <summary>
        /// Test choice directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsDirectoryExist(string path)
        {
            if (
                     String.IsNullOrEmpty(path) ||
                     String.IsNullOrWhiteSpace(path) ||
                     (!(new DirectoryInfo(path)).Exists)
                )
                return false;

            fileDirectory = path;
            return true;
        }



    }
}
