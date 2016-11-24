using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;
using DataModelLibrary;
using System;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace FileGenerator
{
    /// <summary>
    /// XML file generation class.
    /// </summary>
    class XmlCreater : FileCreater
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Records)); //new XmlSerializer(typeof(List<DataModel>));
        public XmlCreater(FileInformation fileInformation, FileType fileExtension)
            : base(fileInformation, fileExtension)
        {

        }

        object block = new object();

        /// <summary>
        /// Method, which creates a file asynchronously.
        /// </summary>
        public async override void CreateAsync()
        {
            await Task.Factory.StartNew(this.Create);
        }

        /// <summary>
        /// Creates new file.
        /// </summary>
        public void Create()
        {
            string fileName = base.fileinformation.FileName;
            Records modifie = new Records(base.DataList);

            try
            {
                lock (block)
                {
                    using (FileStream stream = new FileStream(base.GetFullName(fileName), FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        serializer.Serialize(stream, modifie);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

    }

    /// <summary>
    /// Type for serialization.
    /// </summary>

    [Serializable]
    public class Records
    {
        [XmlElement("Member")]
        public List<DataModel> Memebers;

        [XmlArray("Projects")]
        [XmlArrayItem("Project")]
        public List<MProject> Projects = new List<MProject>();

        public Records() { }

        public Records(List<DataModel> dataModel)
        {
            this.Memebers = dataModel;
            CopyProjects(this.Memebers);
        }


        /// <summary>
        /// Copies projects from member list to new project list which will be serialized.
        /// </summary>
        /// <param name="memebers"></param>
        private void CopyProjects(List<DataModel> memebers)
        {
            foreach (DataModel item in memebers)
            {
                MProject[] mprojects = GetMProjects(item);

                for (int i = 0; i < mprojects.Length; i++)
                {
                    if (!isContain(mprojects[i]))
                        Projects.Add(mprojects[i]);
                }
            }
        }

        /// <summary>
        /// Checks duplicates of project.
        /// </summary>
        /// <param name="mProject"></param>
        /// <returns></returns>
        private bool isContain(MProject mProject)
        {
            for (int i = 0; i < Projects.Count; i++)
            {
                if(Projects[i].ProjectID == mProject.ProjectID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets and returns serializable projects.
        /// </summary>
        /// <param name="dataModel"></param>
        /// <returns></returns>
        private MProject[] GetMProjects(DataModel dataModel)
        {
            MProject[] mProjects = new MProject[dataModel.Projects.Length];
            for (int i = 0; i < mProjects.Length; i++)
            {
                mProjects[i] = new MProject()
                {
                    ProjectID = dataModel.Projects[i].ProjectID,
                    ProjectName = dataModel.Projects[i].ProjectName,
                    ProjectCreatedDate = dataModel.Projects[i].ProjectCreatedDate,
                    ProjectDueDate = dataModel.Projects[i].ProjectDueDate,
                    ProjectDescription = dataModel.Projects[i].ProjectDescription
                };
            }

            return mProjects;
        }

        /// <summary>
        /// Equivalent class of DataModel.Project class.
        /// </summary>
        public class MProject
        {
            public long ProjectID { get; set; }
            public string ProjectName { get; set; }
            public DateTime ProjectCreatedDate { get; set; }
            public DateTime ProjectDueDate { get; set; }
            public string ProjectDescription { get; set; }

            public MProject() { }           
        }      
    }
}
