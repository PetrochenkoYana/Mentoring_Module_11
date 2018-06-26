using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;
using System.Configuration;

namespace MvcMusicStore.Logger
{
    public class Logger : ILogger
    {
        private readonly NLog.ILogger logger;

        public Logger()
        {
            if (ConfigurationManager.AppSettings["LoggingisOn"] == "true")
            {
                logger = LogManager.GetCurrentClassLogger();
            }
        }
        public void LogInfo(string message)
        {
            logger?.Info(message);
        }

        public void LogDebug(string message)
        {
            logger?.Debug(message);
        }

        public void LogError(ApplicationException ex, string message)
        {
            logger?.Error(ex, message);
        }
    }
}