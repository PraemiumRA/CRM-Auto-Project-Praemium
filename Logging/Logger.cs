using System;
using System.Text;
using ProjectConfiguration;
using System.Windows.Forms;
using System.Drawing;

namespace Logging
{
    public class Logger
    {
        #region Logging Colors
        static Color errorColor = Color.FromArgb(232, 76, 78);
        static Color warninfColor = Color.FromArgb(243, 238, 119);
        static Color wrongDataColor = Color.FromArgb(230, 134, 117);
        static Color appearanceColor = Color.FromArgb(103, 220, 103);

        #endregion
        public static DataGridView LogSource = null;
        public static Form form = null;
        public static object block = new object();


        public static void DoLogging(LogType logType, Exception ex = null, string message = null)
        {
            AppConfiguration appConfig = AppConfiguration.GetInstance;

            bool isTxt;
            ILogger log = null;

            try
            {
                isTxt = appConfig.IsStoreTxtFile;
            }
            catch
            {
                isTxt = false;
            }

            if (isTxt)
            {
                log = new TxtFileLogger();
            }
            else
            {
                log = new WindowsEventLogger();
            }

            if (LogSource != null)
            {
                form.Invoke(
                    new Action(
                        () =>
                        {
                            LogVisibleInWindow(logType, ex, message);
                        }
                        )
                        );
            }

            log.Log(logType, ex, message);
        }

        /// <summary>
        /// RealTime logging in UI
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        private static void LogVisibleInWindow(LogType logType, Exception exception = null, string message = null)
        {
            Lazy<StringBuilder> builder = new Lazy<StringBuilder>();

            lock (block)
            {
                int index = LogSource.Rows.Add();

                Color color = Color.White;
                switch (logType)
                {
                    case LogType.Error:
                        {
                            color = errorColor;
                            break;
                        }
                    case LogType.Warning:
                        {
                            color = warninfColor;
                            break;
                        }
                    case LogType.Appearance:
                        {
                            color = appearanceColor;
                            break;
                        }
                    case LogType.WrongData:
                        {
                            color = wrongDataColor;
                            break;
                        }
                    case LogType.Delete:
                        break;
                    case LogType.Success:
                        break;
                    default:
                        break;
                }
                LogSource.Rows[index].DefaultCellStyle.BackColor = color;

                LogSource.Rows[index].Cells[0].ValueType = typeof(LogType);
                LogSource.Rows[index].Cells[0].Value = logType.ToString();

                LogSource.Rows[index].Cells[1].ValueType = typeof(DateTime);
                LogSource.Rows[index].Cells[1].Value = DateTime.Now;

                LogSource.Rows[index].Cells[2].ValueType = typeof(Exception);
                if (exception != null)
                {
                    builder.Value.AppendLine("Namespace: " + exception.Source);
                    builder.Value.AppendLine("Class Name: " + exception.TargetSite.ReflectedType.Name);
                    builder.Value.AppendLine("Line: " + exception.StackTrace.Substring(exception.StackTrace.LastIndexOf(":line") + 5));
                    builder.Value.AppendLine("Discription: " + exception.Message);
                }
                LogSource.Rows[index].Cells[2].Value = builder.Value.ToString();

                LogSource.Rows[index].Cells[3].ValueType = typeof(string);
                LogSource.Rows[index].Cells[3].Value = message;
                if (index > 0)
                {
                    LogSource.Rows[index - 1].Selected = false;
                }
                    LogSource.Rows[index].Selected = true;
                LogSource.FirstDisplayedScrollingRowIndex = index;
            }

        }
    }
}
