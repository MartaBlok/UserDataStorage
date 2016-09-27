using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public void Log(UserData user)
        {
            var configMapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserData, UserDataLogDTO>();
            });

            IMapper mapper = configMapper.CreateMapper();
            
            var userDto = mapper.Map<UserData, UserDataLogDTO>(user);
            
            // Step 1. Create configuration object 
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            var fileTarget = new FileTarget();
            config.AddTarget("log", fileTarget);

            // Step 3. Set target properties 
            fileTarget.FileName = "${basedir}/log.txt";
            fileTarget.Layout = "${message}";

            // Step 4. Define rules
            var rule = new LoggingRule("*", LogLevel.Info, fileTarget);
            config.LoggingRules.Add(rule);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;
            
            _logger = LogManager.GetLogger("TextDataLogStorage");
            _logger.Info($"{userDto.Name}, {userDto.Surname}");
        }
    }
}
