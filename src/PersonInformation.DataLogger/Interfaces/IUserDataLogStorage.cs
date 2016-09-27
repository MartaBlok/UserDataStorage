using PersonInformation.DataLogger.Models;

namespace PersonInformation.DataLogger.Interfaces
{
    public interface IUserDataLogStorage
    {
        void Log(UserDataLogDTO dto);
    }
}
