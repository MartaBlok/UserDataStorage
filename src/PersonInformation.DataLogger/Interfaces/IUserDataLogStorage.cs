using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonInformation.DataLogger.Models;

namespace PersonInformation.DataLogger.Interfaces
{
    public interface IUserDataLogStorage
    {
        void Log(UserDataLogDTO dto);
    }
}
