﻿using DataModelLibrary;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using Logging;

namespace BLL
{
    public class JsonMaker
    {
        DataModel dataModel;
        string filePath;
        string defaultPath;
        string jsonPath;
        static object locker = new object();
        public bool isWrittenJson = false;

        public JsonMaker(DataModel dataModel, string filePath, string jsonPath)
        {
            this.dataModel = dataModel;
            this.filePath = filePath;
            this.jsonPath = jsonPath;

            JsonFromatMaker();
        }

        public void JsonFromatMaker()
        {
            if (dataModel == null)
            {
                return;
            }
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            WriteTeamAndMemberData(builder);

            if (dataModel.Projects.Length > 0)
            {
                builder.Insert(builder.Length - 1, ",");
                builder.AppendLine();
                builder.AppendLine($"  \"{nameof(dataModel.Projects)}\" :");
                builder.AppendLine("[");

                for (int i = 0; i < dataModel.Projects.Length; i++)
                {
                    builder.AppendLine("{");
                    WriteProjectData(builder, dataModel.Projects[i]);

                    if (dataModel.Projects.Length - i != 1)
                        builder.AppendLine("},");
                    else
                        builder.AppendLine("}");

                }
                builder.AppendLine("]");
            }

            builder.AppendLine("}");

            JsonFileWriter(builder);
        }

        private StringBuilder WriteTeamAndMemberData(StringBuilder builder)
        {
            builder.AppendLine($"  \"{nameof(dataModel.TeamID)}\" : {dataModel.TeamID},");
            builder.AppendLine($"  \"{nameof(dataModel.TeamName)}\" : \"{dataModel.TeamName}\",");
            builder.AppendLine($"  \"{nameof(dataModel.MemberID)}\" : {dataModel.MemberID},");
            builder.AppendLine($"  \"{nameof(dataModel.PassportNumber)}\" : {dataModel.PassportNumber},");//Changed

            builder.AppendLine($"  \"{nameof(dataModel.MemberName)}\" : \"{dataModel.MemberName}\",");
            builder.AppendLine($"  \"{nameof(dataModel.MemberSurname)}\" : \"{dataModel.MemberSurname}\"");

            return builder;
        }

        private StringBuilder WriteProjectData(StringBuilder builder, Project projects)
        {
            builder.AppendLine($"  \"{nameof(Project.ProjectID)}\" : {projects.ProjectID},");
            builder.AppendLine($"  \"{nameof(Project.ProjectName)}\" : \"{projects.ProjectName}\",");
            builder.AppendLine($"  \"{nameof(Project.ProjectCreatedDate)}\" : \"{projects.ProjectCreatedDate}\",");
            builder.AppendLine($"  \"{nameof(Project.ProjectDueDate)}\" : \"{projects.ProjectDueDate}\",");
            builder.AppendLine($"  \"{nameof(Project.ProjectDescription)}\" : \"{projects.ProjectDescription}\"");

            return builder;
        }

        private void JsonFileWriter(StringBuilder builder)
        {
            defaultPath = jsonPath;
            if (!Directory.Exists(defaultPath))
                Directory.CreateDirectory(defaultPath);


            filePath = Path.ChangeExtension(Path.GetFileName(filePath), "Json");
            lock (locker)
            {
                try
                {
                    using (StreamWriter write = new StreamWriter(defaultPath + "\\" + filePath, true))
                    {
                        write.WriteLine(builder);
                        write.Write(write.NewLine);
                    }
                }
                catch (Exception exception)
                {
                    Logger.DoLogging(LogType.Error, exception, "Error in process to storing in json format.");
                    isWrittenJson = true;
                }
            }
        }
    }
}
