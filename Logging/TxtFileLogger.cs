using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectConfiguration;


namespace Logging
{
    class TxtFileLogger : ILogger
    {
        AppConfiguration appConfig;
        StringBuilder builder;
        string path { get; set; }

        public TxtFileLogger()
        {
            appConfig = new AppConfiguration();
            builder = new StringBuilder();
        }

        public void Log(LogType logType, Exception ex = null, string message = null)
        {

            path = appConfig.LogTextFileDirectory;

            builder.Clear();
            builder.Append(path).Append("\\").Append(DateTime.Now.Day + "-").Append(DateTime.Now.Month + "-").Append(DateTime.Now.Year).Append(".txt"); ;

            using (StreamWriter fileStream = new StreamWriter(builder.ToString(), true))
            {
                builder.Clear();

                builder.AppendLine("Time: " + DateTime.Now);
                builder.AppendLine("Operation Name: " + logType);

                if (message != null)
                {
                    builder.AppendLine("Message: " + message);
                }
                if (ex != null)
                {
                    builder.AppendLine("Namespace: " + ex.Source);
                    builder.AppendLine("Class Name: " + ex.TargetSite.ReflectedType.Name);
                    builder.AppendLine("Line: " + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(":line") + 5));
                    builder.AppendLine("Discription: " + ex.Message);

                    if (ex.InnerException != null)
                    {
                        builder.AppendLine("Inner Exception: " + ex.InnerException);
                    }
                }

                builder.AppendLine(new string('_', 50));
                fileStream.WriteLine(builder.ToString());
            }

        }

    }
}



