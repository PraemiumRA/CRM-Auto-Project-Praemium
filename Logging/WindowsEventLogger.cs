using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    class WindowsEventLogger : ILogger
    {
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

            //if (!EventLog.SourceExists(source))
            //{
                
            //}

            //EventLog.WriteEntry(source, message);
            //EventLog.WriteEntry(source, message, (EventLogEntryType)logType);
            //EventLog.WriteEntry(source, message, (EventLogEntryType)logType, 234);

        }
    }
}
