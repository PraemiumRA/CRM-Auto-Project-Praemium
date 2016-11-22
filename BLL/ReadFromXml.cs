using DataModelLibrary;
using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using Logging;
namespace BLL
{
    public class ReadFromXml : IStore
    {

        public static int projectsCount;

        public string path { get; set; }
        public string jsonPath { get; set; }
        public string fileName { get; set; } 


        public ReadFromXml(string path, string jsonPath)
        {
            this.path = path;
            this.jsonPath = jsonPath;

            this.fileName = Path.GetFileName(path);//
        }

        /// <summary>
        /// Read data from Xml file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataModel> Read()
        {
            bool isWrong = false;//

            DataModel dataModel;
            XmlNode tempNode = default(XmlNode); //

            XmlDocument document = new XmlDocument();
            document.Load(path);

            XmlNode root = document.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                dataModel = new DataModel();
                if (node.Name == "Member")
                {
                    tempNode = node;
                    try
                    {
                        #region Read current Data
                        foreach (XmlNode nodeMemeber in node.ChildNodes)
                        {
                            switch (nodeMemeber.Name)
                            {
                                case "TeamID":
                                    {
                                        dataModel.TeamID = long.Parse(nodeMemeber.InnerText);
                                        break;
                                    }
                                case "TeamName":
                                    {
                                        dataModel.TeamName = nodeMemeber.InnerText;
                                        break;
                                    }
                                case "PassportID": //changed
                                    {
                                        dataModel.PassportNumber = nodeMemeber.InnerText;
                                        break;
                                    }
                                case "MemberID":
                                    {
                                        dataModel.MemberID = long.Parse(nodeMemeber.InnerText);
                                        break;
                                    }
                                case "MemberName":
                                    {
                                        dataModel.MemberName = nodeMemeber.InnerText;
                                        break;
                                    }
                                case "MemberSurname":
                                    {
                                        dataModel.MemberSurname = nodeMemeber.InnerText;
                                        break;
                                    }
                                case "Projects":
                                    {
                                        dataModel.Projects = GetProjects(root, GetProjctsId(nodeMemeber));
                                        break;
                                    }
                            }
                        }
                        #endregion
                    }
                    catch
                    {
                        isWrong = true;
                        WrongData wrongData = new WrongData(this.fileName);
                        wrongData.WrongDataFromXml(GetWrongDataMembers(tempNode), ReadWrongData(tempNode, root));

                        Logger.DoLogging(LogType.WrongData, null, "Finde wrog data and wrote ot wrong directory.");
                    }

                    if (!isWrong)
                        yield return dataModel;
                    else
                    {
                        isWrong = false;
                        continue;
                    }
                }
            }
        }

               
        /// <summary>
        /// Get all projects id from member
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<long> GetProjctsId(XmlNode node)
        {
            List<long> id = new List<long>();

            foreach (XmlNode nod in node.ChildNodes)
            {
                if (nod.Name.Equals("Project"))
                {
                    long result = 0;
                    long.TryParse(nod.Attributes["ProjectID"].InnerText, out result);

                    id.Add(result);
                }
            }

            return id;
        }

        /// <summary>
        /// Get all projects from  member
        /// </summary>
        /// <param name="root"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        private Project[] GetProjects(XmlNode root, List<long> array)
        {
            Project[] projects = new Project[root.LastChild.ChildNodes.Count];
            XmlNode projectsNode = root.LastChild;

            for (int i = 0; i < projects.Length; i++)
            {
                foreach (XmlNode node in projectsNode.ChildNodes)
                {
                    if (node.Name.Equals("Project"))
                    {
                        if (array[i] == GetProject(node).ProjectID)
                        {
                            projects[i] = GetProject(node);
                        }
                    }
                }
            }

            return projects;
        }

        /// <summary>
        /// Get one project
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Project GetProject(XmlNode node)
        {
            Project project = new Project();

            foreach (XmlNode nod in node.ChildNodes)
            {
                switch (nod.Name)
                {
                    case "ProjectID":
                        {
                            project.ProjectID = Convert.ToInt64(nod.InnerText);
                            break;
                        }
                    case "ProjectName":
                        {
                            project.ProjectName = nod.InnerText;
                            break;
                        }
                    case "ProjectCreatedDate":
                        {
                            project.ProjectCreatedDate = Convert.ToDateTime(nod.InnerText);
                            break;
                        }
                    case "ProjectDueDate":
                        {
                            project.ProjectDueDate = Convert.ToDateTime(nod.InnerText);
                            break;
                        }
                    case "ProjectDescription":
                        {
                            project.ProjectDescription = nod.InnerText;
                            break;
                        }
                }
            }
            return project;
        }

        #region Get Wrong Data
        /// <summary>
        /// Get wrong datas
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetWrongDataMembers(XmlNode node)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (XmlNode nod in node.ChildNodes)
            {
                dic.Add(nod.Name, nod.InnerXml);
            }

            return dic;
        }

        /// <summary>
        /// Get all projects from Wrong Data
        /// </summary>
        /// <param name="node"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        private Project[] ReadWrongData(XmlNode node, XmlNode root)
        {
            string line = node.InnerXml;
            Project[] projects = null;

            foreach (XmlNode nod in node.ChildNodes)
            {
                if (nod.NodeType == XmlNodeType.Element && nod.Name == "Projects")
                {
                    projects = GetProjects(root, GetProjctsId(nod));
                }

            }
            return projects;
        }
               
        #endregion
    }
}
