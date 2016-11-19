using System;
using System.Xml.Serialization;

namespace DataModelLibrary
{
    /// <summary>
    /// Model of generating data
    /// </summary>
    [Serializable]
    [XmlRoot("Data")]
    public class DataModel
    {
        private long teamID;
        private string teamName = String.Empty;
        private long memberID;
        private string memberName = String.Empty;
        private string memberSurname = String.Empty;
        private Project[] projects = null;

        [XmlElement("TeamID")]
        public long TeamID
        {
            get
            {
                return teamID;
            }

            set
            {
                if (value <= 0)
                    throw new Exception("TeamID is not correct.");
                else
                    teamID = value;

            }
        }

        [XmlElement("TeamName")]
        public string TeamName
        {
            get { return teamName; }
            set
            {
                try
                {
                    this.teamName = Check.TestInputStringValue(value);
                }
                catch { throw; }
            }
        }

        [XmlElement("MemberID")]
        public long MemberID
        {
            get
            {
                return memberID;
            }

            set
            {
                if (value <= 0)
                    throw new Exception("MemberID is not correct.");
                else
                    memberID = value;
            }
        }

        [XmlElement("MemberName")]
        public string MemberName
        {
            get { return memberName; }
            set
            {
                try
                {
                    this.memberName = Check.TestInputStringValue(value);
                }
                catch { throw; }
            }
        }

        [XmlElement("MemberSurname")]
        public string MemberSurname
        {
            get { return memberSurname; }
            set
            {
                try
                {
                    this.memberSurname = Check.TestInputStringValue(value);
                }
                catch { throw; }
            }
        }

        [XmlArray("Projects")]
        public Project[] Projects
        {
            get { return projects; }
            set
            {
                if (value != null)
                    projects = value;
            }
        }

        public DataModel() { }

        public DataModel(long teamId, string teamName, long memberId, string memberName, string membersurName, Project[] projects)
        {
            this.Projects = projects;
            this.TeamID = teamId;
            this.TeamName = teamName;
            this.MemberID = memberId;
            this.MemberName = memberName;
            this.MemberSurname = membersurName;
        }


    }
}
