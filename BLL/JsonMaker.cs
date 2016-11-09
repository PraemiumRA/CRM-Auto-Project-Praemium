﻿using DataModelLibrary;
using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace BLL
{
    public class JsonMaker
    {
        DataModel dataModel;
        string filePath;
        string newFilePath;
        string defaultPath;

        public JsonMaker(DataModel DataModel, string FilePath)
        {
            this.dataModel = DataModel;
            this.filePath = FilePath;
            JsonFromatMaker();
        }

        public void JsonFromatMaker()
        {
            try
            {
                if (dataModel == null)
                {
                    throw new NullReferenceException();
                }
            }
            catch (NullReferenceException ex)
            {
                throw;
            }

            StringBuilder builder = new StringBuilder();

            builder.AppendLine("{");

            WriteTeamAndMemberData(builder);


            if (dataModel.Projects.Length > 1)
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
            else if (dataModel.Projects.Length == 1)
            {
                builder.Insert(builder.Length - 1, ",");
                builder.AppendLine();
                WriteProjectData(builder, dataModel.Projects[0]);
            }

            builder.AppendLine("}");


            JsonFileWriter(builder);
            Console.WriteLine($"Data was successfully written in {filePath}");
        }

        private StringBuilder WriteTeamAndMemberData(StringBuilder builder)
        {
            builder.AppendLine($"  \"{nameof(dataModel.TeamID)}\" : {dataModel.TeamID},");
            builder.AppendLine($"  \"{nameof(dataModel.TeamName)}\" : \"{dataModel.TeamName}\",");

            builder.AppendLine($"  \"{nameof(dataModel.MemberID)}\" : {dataModel.MemberID},");
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
            defaultPath = @".\Json Files";
            if (!Directory.Exists(defaultPath))
                Directory.CreateDirectory(defaultPath);

            try
            {
                newFilePath = string.IsNullOrEmpty(ConfigurationManager.AppSettings["JsonPath"]) ? defaultPath : ConfigurationManager.AppSettings["JsonPath"];
                if (!Directory.Exists(newFilePath))
                    newFilePath = defaultPath;
            }
            catch (ConfigurationErrorsException ex)
            {
                throw;
            }

            filePath = Path.ChangeExtension(Path.GetFileName(filePath), "Json");


            using (StreamWriter write = new StreamWriter(newFilePath + "\\" + filePath, true))
            {
                write.WriteLine(builder);
                write.Write(write.NewLine);
            }

        }
    }
}
