using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    /// <summary>
    /// Provides writing of logs in Windows Event Log.
    /// </summary>
    class WindowsEventLogger : ILogger
    {
        /// <summary>
        /// Writes logs in Windows Event Log.
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public void Log(LogType logType, Exception ex = null, string message = null)
        {
            string source = DateTime.Now.ToString();
            string logName = "Application";

            EventLog.CreateEventSource(source, logName);

            if (logType == LogType.Error)
            {
                EventLog.WriteEntry(source, ex.Message, EventLogEntryType.Error);
            }
            if (logType == LogType.Warning)
            {
                EventLog.WriteEntry(source, message, EventLogEntryType.Warning);
            }
            if (logType == LogType.Success)
            {
                EventLog.WriteEntry(source, message, EventLogEntryType.SuccessAudit);
            }
        }
    }
}
