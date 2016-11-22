using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectConfiguration;
using System.IO;
using System.Xml.Serialization;
using DataModelLibrary;
using System.Xml;

namespace BLL
{
    /// <summary>
    ///Handles wrong data.
    /// </summary>
    class WrongData
    {
        Lazy<StringBuilder> WrongFileDirectory = new Lazy<StringBuilder>();
        public string fileName = string.Empty;
        XmlSerializer serialize = new XmlSerializer(typeof(DataModel));

        public WrongData(string fileName)
        {
            this.fileName = fileName;
            WrongFileDirectory.Value.Append(AppConfiguration.GetInstance.WrongFilesDirectory).Append(@"\Wrong-").Append(fileName);
        }

        /// <summary>
        /// Writes wrong data in the other file from CSV file.
        /// </summary>
        /// <param name="innerXml"></param>
        /// <param name="projects"></param>
        public void WrongDataFromCSV(string data)
        {
            using (FileStream stream = new FileStream(WrongFileDirectory.Value.ToString(), FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(data);
                }
            }

        }

        /// <summary>
        /// Writes wrong data in the other file from XML file.
        /// </summary>
        /// <param name="innerXml"></param>
        /// <param name="projects"></param>
        public void WrongDataFromXml(Dictionary<string, string> innerXml, Project[] projects)
        {
            using (FileStream stream = new FileStream(WrongFileDirectory.Value.ToString(), FileMode.Append, FileAccess.Write))
            {
                using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.Unicode) { Formatting = Formatting.Indented, IndentChar = '\t', Indentation = 1, QuoteChar = '\'' })
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Recorsds");
                    writer.WriteStartElement("Memeber");
                    foreach (var item in innerXml.Keys)
                    {
                        if (item.Equals("Projects"))
                        {
                            writer.WriteStartElement(item);
                            List<string> projectID = GetProjectID(innerXml[item]);
                            foreach (string id in projectID)
                            {
                                writer.WriteStartElement("Project");
                                writer.WriteStartAttribute("ID");
                                writer.WriteString(id);
                                writer.WriteEndAttribute();
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                        }

                        if (!item.Equals("Projects"))
                        {
                            writer.WriteStartElement(item);

                            if (string.IsNullOrEmpty(innerXml[item]))
                                writer.WriteString(" ");
                            else
                                writer.WriteString(innerXml[item]);

                            writer.WriteEndElement();
                        }
                        else
                            continue;
                    }

                    writer.WriteEndElement();

                    #region Write Project

                    writer.WriteStartElement("Projects");
                    for (int i = 0; i < projects.Length; i++)
                    {
                        writer.WriteStartElement("Project");

                        writer.WriteStartElement("ProjectID");
                        writer.WriteString(projects[i].ProjectID.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("ProjectName");
                        writer.WriteString(projects[i].ProjectName.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("ProjectCreatedDate");
                        writer.WriteString(projects[i].ProjectCreatedDate.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("ProjectDueDate");
                        writer.WriteString(projects[i].ProjectDueDate.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("ProjectDescription");
                        writer.WriteString(projects[i].ProjectDueDate.ToString());
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    #endregion

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }

        }

        /// <summary>
        /// Gets wrong projectID.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private List<string> GetProjectID(string line)
        {
            List<string> list = new List<string>();
            string[] lines = line.Split(new string[] { $"<Project ProjectID=", " />" }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                if (!string.IsNullOrEmpty(lines[i]))
                    list.Add(lines[i].TrimStart('\"').TrimEnd('\"'));
            }

            return list;
        }

    }
}
