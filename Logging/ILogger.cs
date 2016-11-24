using System;

namespace Logging
{
    /// <summary>
    /// Contract, which is providing necessary functionality for logs.
    /// </summary>
    interface ILogger
    {
        void Log(LogType logType, Exception ex = null, string message = null);
    }
}