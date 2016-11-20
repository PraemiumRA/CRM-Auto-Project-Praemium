using DataModelLibrary;
using System;
using System.Collections.Generic;
using System.Xml;

namespace BLL
{
    public class ReadFromXml : IStore
    {

        public string path { get; set; }
        public string jsonPath { get; set; }
        public static int projectsCount;

        public ReadFromXml(string path, string jsonPath)
        {
            this.path = path;
            this.jsonPath = jsonPath;
        }

        public IEnumerable<DataModel> Read()
        {
            DataModel dataModel;

            XmlDocument document = new XmlDocument();
            document.Load(path);

            XmlNode root = document.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                dataModel = new DataModel();
                if (node.Name == "Member")
                {
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
                    yield return dataModel;
                }
            }
        }

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
    }
}
