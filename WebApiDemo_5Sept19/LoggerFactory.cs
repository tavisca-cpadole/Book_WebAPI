using System;
using System.Collections.Generic;

namespace WebApiDemo_5Sept19
{
    public static class LoggerFactory
    {
        private static Dictionary<string, Func<ILog>> _loggingSystem = new Dictionary<string, Func<ILog>>()
        {
            { "json",()=>new JsonFileLogger()},
        };

        public static ILog GetLoggingSystem(string logType)
        {
            if (_loggingSystem.TryGetValue(logType, out Func<ILog> log) == false)
                return null;
            return log();
        }
    }


}
