using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;
using DataModelLibrary;
using System;
using System.Windows.Forms;

namespace FileGenerator
{
    /// <summary>
    /// XML file generation class
    /// </summary>
    class XmlCreater : FileCreater
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<DataModel>));
        public XmlCreater(FileInformation fileInformation, FileType fileExtension)
            : base(fileInformation, fileExtension)
        {

        }

        object block = new object();
        /// <summary>
        /// Method, which creates a file asynchronously
        /// </summary>
        public async override void CreateAsync()
        {
            await Task.Factory.StartNew(this.Create);
        }

        /// <summary>
        /// The base method for create file
        /// </summary>
        public  void Create()
        {
            List<DataModel> dataList = base.DataList;
            string fileName = base.fileinformation.FileName;

            try
            {
                lock (block)
                {
                    using (FileStream stream = new FileStream(base.GetFullName(fileName), FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        serializer.Serialize(stream, dataList);
                    }
                }
            }
            catch (Exception exception)
            {
                //TODO: Logging
                MessageBox.Show(exception.Message);
            }

        }

    }
}
