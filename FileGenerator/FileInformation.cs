using System.Collections.Specialized;

namespace FileGenerator
{
    /// <summary>
    /// Information class for generate file
    /// </summary>
    class FileInformation
    {
        private int memberCount;
        private string fileName;
        private string fileDirectory;
        private int projectCount;

        public int MemberCount
        {
            get { return this.memberCount; }
            set { this.memberCount = value; }
        }
        public string FileName
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }
        public string FileDirectory
        {
            get { return this.fileDirectory; }
            set { this.fileDirectory = value; }
        }
        public int ProjectCount
        {
            get { return this.projectCount; }
            set { this.projectCount = value; }
        }

        public FileInformation()
        {

        }

        
    }
}
