using System;

namespace FileGenerator
{
    /// <summary>
    /// Choose file type for generate
    /// </summary>
    class ChooseFileType
    {
        FileCreater fileCreate;

        public ChooseFileType()
        {

        }

        /// <summary>
        /// Generation the file with choice type
        /// </summary>
        /// <param name="filetype"></param>
        /// <param name="fileinformation"></param>
        /// <returns></returns>
        public bool GenerateTheFile(FileType filetype, FileInformation fileinformation)
        {
            FileType tempType = filetype;

            switch (filetype)
            {
                case FileType.Xml:
                    {
                        tempType = FileType.Xml;
                        fileCreate = new XmlCreater(fileinformation, FileType.Xml);
                        break;
                    }
                case FileType.Csv:
                    {
                        tempType = FileType.Csv;
                        fileCreate = new CsvCreater(fileinformation, FileType.Csv);
                        break;
                    }
            }

            fileCreate.CreateAsync();
            return true;
        }



    }
}
