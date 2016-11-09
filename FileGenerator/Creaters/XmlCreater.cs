using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;
using DataModelLibrary;
using System;

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
                using (FileStream stream = new FileStream(base.GetFullName(fileName), FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    serializer.Serialize(stream, dataList);
                }
            }
            catch 
            {
                //TODO: Logging
                
            }

        }

    }
}
