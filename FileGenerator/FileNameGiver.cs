using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace FileGenerator
{
    class FileNameGiver
    {
        public List<FileSyntax> fileList = new List<FileSyntax>();
        private string fileDirectory;
        private bool isWork = false;

        public FileNameGiver()
        {

        }
        public FileNameGiver(string fileDirectory)
        {
            this.fileDirectory = fileDirectory;
        }

        /// <summary>
        /// Get the file name for create
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public string GetFileName(FileType fileType)
        {
            string nameFromConfig = GetFileNameFromAppConfig().ToLower();
            int index = 0;
            do
            {
                index = 0;
                foreach (FileSyntax file in fileList)
                {
                    if (file.name.Equals(nameFromConfig) || file.name.Equals(nameFromConfig.ToLower()))
                    {
                        if (file.extension.Equals('.' + fileType.ToString().ToLower()))
                        {
                            index = CalculateMaxIndex(file) + 1;
                            break;
                        }
                    }
                }
            } while (File.Exists(fileDirectory + nameFromConfig + index));
                        
            return nameFromConfig + index;
        }

        /// <summary>
        /// Calculate maximum index for the new generate file
        /// </summary>
        /// <param name="fileSyntax"></param>
        /// <returns></returns>
        private int CalculateMaxIndex(FileSyntax fileSyntax)
        {
            List<int> numbers = new List<int>();

            foreach (FileSyntax file in fileList)
            {
                if (file.name.Equals(fileSyntax.name))
                {
                    numbers.Add(file.id);
                }
            }

            return numbers.Max();
        }

        /// <summary>
        /// Check file name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string CheckName(string name)
        {
            StringBuilder builder = new StringBuilder(name.Trim());

            if ((name.Length >= 5) && (name.LastIndexOf('.') == (name.Length - 4)))
            {
                string subString = name.Substring(name.Length - 3, 3);
                if (subString == "csv" || subString == "xml")
                {
                    subString = builder.ToString().Substring(0, name.Length - 3);
                    builder.Clear();
                    builder.Append(subString);
                }
            }

            return string.Concat(builder.ToString().Split(new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' }));
        }

        private string GetFileNameFromAppConfig()
        {
            string temp = "";
            try
            {
                temp = ConfigurationManager.AppSettings["FileName"] ?? "file";
            }
            catch (ConfigurationErrorsException configError)
            {
                //TODO: logging Key Not Found
            }
            catch (Exception exception)
            {
                //TODO: Logging 
            }
            return temp;
        }

        /// <summary>
        /// Get all file names from directory
        /// </summary>
        public void GetAllFilesInDirectory()
        {
            if (isWork) RemoveNotExistFilesFromList();

            DirectoryInfo directory = new DirectoryInfo(this.fileDirectory);
           // if(!directory.Exists)  //TODO: 
                
            FileInfo[] files = directory.GetFiles();
            if (files.Length == 0) return;

            FileSyntax syntax;

            int index = 0;
            string temp = "";

            foreach (FileInfo file in files)
            {
                if (file.Extension == ".csv" || file.Extension == ".xml")
                {
                    temp = "";
                    index = file.Name.LastIndexOf('.');
                    if (index == -1) break;

                    for (int i = index - 1; i >= 0; i--)
                    {
                        if (char.IsNumber(file.Name[i]))
                        {
                            temp += file.Name[i];
                        }
                        else
                        {
                            break;
                        }
                    }

                    syntax = new FileSyntax();
                    syntax.extension = file.Extension;
                    syntax.id = (!string.IsNullOrEmpty(temp)) ? (int.Parse(new string(temp.ToCharArray().Reverse().ToArray()))) : -1;
                    syntax.name = file.Name.Substring(0, index - temp.Length);

                    fileList.Add(syntax);
                }
            }
            isWork = true;
        }

        /// <summary>
        /// Remove file name from list, if the file not exists
        /// </summary>
        private void RemoveNotExistFilesFromList()
        {
            StringBuilder strBuilder = new StringBuilder();

            foreach (FileSyntax file in fileList)
            {
                strBuilder.Append(fileDirectory);
                strBuilder.Append('\\');

                strBuilder.Append(file.name);
                strBuilder.Append(file.id);
                strBuilder.Append('.');
                strBuilder.Append(file.extension);

                if (!File.Exists(strBuilder.ToString()))
                {
                    fileList.Remove(file);
                }
            }
        }


    }
}
