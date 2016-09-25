using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonInformation.DataLogger.Interfaces;
using PersonInformation.DataLogger.Models;
using NLog;

namespace PersonInformation.DataLogger.Implementations
{
    class TextDataLogStorage : IUserDataLogStorage
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void Log(UserDataLogDTO dto)
        {
            logger.Log(LogLevel.Info, $"");
        }
    }
}
