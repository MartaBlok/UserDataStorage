using AutoMapper;
using PersonInformation.DataLogger.Interfaces;
using PersonInformation.DataLogger.Models;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace PersonInformation.DataLogger.Implementations
{
    public class TextDataLogStorage : IUserDataLogStorage
    {
        private readonly Logger _logger;

        public TextDataLogStorage(string logName)
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget
            {
                FileName = "${basedir}/" + logName,
                Layout = "${message}"
            };
            config.AddTarget("log", fileTarget);
            var rule = new LoggingRule("*", LogLevel.Info, fileTarget);
            config.LoggingRules.Add(rule);
            LogManager.Configuration = config;

            _logger = LogManager.GetLogger("TextDataLogStorage");
        }

        public void Log(UserDataLogDTO user)
        {        
            _logger.Info($"{user.Name}, {user.Surname}");
        }
    }
}
