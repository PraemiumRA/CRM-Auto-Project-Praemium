using System;
using System.Xml.Serialization;

namespace DataModelLibrary
{
    [XmlRoot("Project")]
    public class Project
    {
        private long projectID;
        private string projectName;
        private DateTime projectCreatedDate;
        private DateTime projectDueDate;

        [XmlAttribute]
        public long ProjectID
        {
            get
            {
                return projectID;
            }
            set
            {
                if (value <= 0)
                    throw new Exception("ProjectID is not correct.");
                else
                    projectID = value;
            }
        }

        [XmlIgnore]
        public string ProjectName
        {
            get
            {
                return projectName;
            }
            set
            {
                if (value != null)
                {
                    try
                    {
                        this.projectName = Check.TestInputStringValue(value);
                    }
                    catch { throw; }
                }
            }
        }

        [XmlIgnore]
        public DateTime ProjectCreatedDate
        {
            get
            {
                return projectCreatedDate;
            }
            set
            {
                DateTime dateTime;
                if (DateTime.TryParse(Convert.ToString(value), out dateTime))
                {
                    projectCreatedDate = value;
                }
                else
                {
                    throw new Exception("DateTime is not correct.");
                }
            }
        }

        [XmlIgnore]
        public DateTime ProjectDueDate
        {
            get
            {
                return projectDueDate;
            }
            set
            {
                DateTime dateTime;
                if ((DateTime.TryParse(Convert.ToString(value), out dateTime)))
                {
                    int result = DateTime.Compare(value, projectCreatedDate);
                    if (result > 0)
                    {
                        projectDueDate = value;
                    }
                    else
                    {
                        throw new Exception("DateTime is not correct.");
                    }
                }
                else
                {
                    throw new Exception("DateTime is not correct.");
                }
            }
        }

        [XmlIgnore]
        public string ProjectDescription { get; set; }

        public Project() { }

        public Project(long projectId, string projectName, DateTime projectcreatDate, DateTime projectdueDate, string projectDiscraption)
        {
            this.ProjectID = projectId;
            this.ProjectName = projectName;
            this.ProjectCreatedDate = projectcreatDate;
            this.ProjectDueDate = projectdueDate;
            this.ProjectDescription = ProjectDescription;
        }
    }
}
