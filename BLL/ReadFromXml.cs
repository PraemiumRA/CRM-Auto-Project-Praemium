using DataModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL
{
    public class ReadFromXml : IStore
    {
        public static int projectsCount;

        public  string path;
        public string Path { get; set; }

        public ReadFromXml(string path)
        {
            this.Path = path;
        }

        public IEnumerable<DataModel> Read()
        {
            DataModel dataModel = new DataModel();

            XmlDocument document = new XmlDocument();
            document.Load(Path);

            XmlNode root = document.DocumentElement;
            XmlNodeList list = root.ChildNodes;

            foreach (XmlNode listnodes in list)
            {
                XmlNodeList dataChild = listnodes.ChildNodes;
                foreach (XmlNode node in dataChild)
                {
                    switch (node.Name)
                    {
                        case "TeamID":
                            dataModel.TeamID = Convert.ToInt32(node.InnerText);
                            break;

                        case "TeamName":
                            dataModel.TeamName = node.InnerText;
                            break;

                        case "MemberID":
                            dataModel.MemberID = int.Parse(node.InnerText);
                            break;

                        case "MemberName":
                            dataModel.MemberName = node.InnerText;
                            break;

                        case "MemberSurname":
                            dataModel.MemberSurname = node.InnerText;
                            break;

                        case "Projects":

                            projectsCount = node.ChildNodes.Count;
                            dataModel.Projects = new Project[projectsCount];

                            XmlNodeList projectsNodes = node.ChildNodes;

                            int i = 0;

                            foreach (XmlNode projNodes in projectsNodes)
                            {
                                dataModel.Projects[i] = new Project();
                                foreach (XmlNode item in projNodes)
                                {
                                    if (i < projectsCount)
                                    {
                                        switch (item.Name)
                                        {
                                            case "ProjectID":
                                                dataModel.Projects[i].ProjectID = Convert.ToInt32(item.InnerText);
                                                break;

                                            case "ProjectName":
                                                dataModel.Projects[i].ProjectName = item.InnerText;
                                                break;

                                            case "ProjectCreatedDate":
                                                dataModel.Projects[i].ProjectCreatedDate = Convert.ToDateTime(item.InnerText);
                                                break;

                                            case "ProjectDueDate":
                                                dataModel.Projects[i].ProjectDueDate = Convert.ToDateTime(item.InnerText);
                                                break;

                                            case "ProjectDescription":
                                                dataModel.Projects[i].ProjectDescription = item.InnerText;
                                                break;
                                        }
                                    }
                                }
                                i++;
                            }
                            break;
                    }

                }
                yield return dataModel;
            }
        }
    }
}
