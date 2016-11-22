using System;

namespace Logging
{
    interface ILogger
    {
        void Log(LogType logType, Exception ex = null, string message = null);
    }
}