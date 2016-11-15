using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectConfiguration;

namespace Logging
{
    public class Logger
    {
        
        public static void DoLogging(LogType logType, Exception ex = null, string message = null)
        {
            AppConfiguration appConfig = new AppConfiguration();
            

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

            log.Log(logType, ex , message);
        }
    }
}
