using System.IO;
using System.Text;
using System.Collections.Generic;
using DataModelLibrary;
using System;
using System.Windows.Forms;

namespace FileGenerator
{
    /// <summary>
    /// Base abstract class for file generation.
    /// </summary>
    abstract class FileCreater
    {
        protected FileType fileExtension;
        protected FileInformation fileinformation;
        protected List<DataModel> DataList;

        private StringBuilder pathBuilder;
        private FileInfo fileInfo;
        private FileStream stream;
        private StreamWriter writer;
        private DataGenerator dataGenerator;
        protected FileNameGiver taker;


        public FileCreater(FileInformation fileinformation, FileType fileExtension)
        {
            this.fileinformation = fileinformation;
            this.fileExtension = fileExtension;

            GenerateData();
        }

        /// <summary>
        /// Gets full name for new generating file.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected string GetFullName(string name)
        {
            pathBuilder = new StringBuilder(this.fileinformation.FileDirectory);
            pathBuilder.Append(@"\");
            pathBuilder.Append(name);
            pathBuilder.Append('.');
            pathBuilder.Append(this.fileExtension.ToString().ToLower());

            return pathBuilder.ToString();
        }

        /// <summary>
        /// The method of asynchronous generation.
        /// </summary>
        public abstract void CreateAsync();


        /// <summary>
        /// The basic method of data generation.
        /// </summary>
        private void GenerateData()
        {
            try {
                using (DataGenerator dataGenerator = new DataGenerator(fileinformation.MemberCount, fileinformation.ProjectCount))
                {
                    this.DataList = dataGenerator.GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
