using System;
using System.IO;
using System.Configuration;

namespace FileGenerator
{
    /// <summary>
    /// Chooses directory.
    /// </summary>
    class DirectoryChoose
    {
        string fileDirectory;

        /// <summary>
        /// Gets Directory of created file.
        /// </summary>
        /// <returns></returns>
        public string GetDirectoryPath()
        {
            string tempDirectory = "";
            try
            {
                tempDirectory = ConfigurationManager.AppSettings["Path"] ?? GetDefaultDirectory();
            }
            catch 
            {
                tempDirectory = GetDefaultDirectory();
            }

            if (!IsDirectoryExist(tempDirectory))
                tempDirectory = GetDefaultDirectory();

            return tempDirectory;
        }

        /// <summary>
        /// Gets default directory.
        /// </summary>
        /// <returns></returns>
        private string GetDefaultDirectory()
        {
            string directoryName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GeneratedFile";

            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            return directoryName;
        }

        /// <summary>
        /// Tests directory exsists or not.
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
