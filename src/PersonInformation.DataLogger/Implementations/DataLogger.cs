using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonInformation.DataLogger.Interfaces;
using PersonInformation.DataLogger.Models;

namespace PersonInformation.DataLogger.Implementations
{
    public class DataLogger : IUserDataLogger
    {
        private readonly ICollection<IUserDataLogStorage> _logStorages;

        // we may consider changing argument type from ICollection to specific 'Settings' class
        // to be sure that there are not ambiguity during DI resolving
        public DataLogger(ICollection<IUserDataLogStorage> logStorages)
        {
            _logStorages = logStorages ?? new List<IUserDataLogStorage>();
        }

        public void Log(UserData data)
        {
            // automapper map UserData to LogDTO
            //UserDataLogDTO dto = null;

            //Parallel.ForEach(_logStorages, s =>
            //{
            //    s.Log(dto);
            //});
        }
    }
}
