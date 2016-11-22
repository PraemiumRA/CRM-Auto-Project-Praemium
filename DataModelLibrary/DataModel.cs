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
        private string passportNumber = String.Empty;
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
                catch { throw new Exception("Incorrect value."); }
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

        [XmlElement("PassportNumber")]
        public string PassportNumber
        {
            get { return passportNumber; }
            set
            {
                try
                {
                    this.passportNumber = value;
                }
                catch { throw new Exception("Incorrect value."); }
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
                catch { throw new Exception("Incorrect value."); }
            
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
                catch { throw new Exception("Incorrect value."); }
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

        public DataModel(long teamId, string teamName, long memberId, string passportID, string memberName, string membersurName, Project[] projects)
        {
            this.Projects = projects;
            this.TeamID = teamId;
            this.TeamName = teamName;
            this.MemberID = memberId;
            this.PassportNumber = passportID;
            this.MemberName = memberName;
            this.MemberSurname = membersurName;
        }
    }
}
