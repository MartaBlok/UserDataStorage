using PersonInformation.DataLogger.Models;

namespace PersonInformation.DataLogger.Interfaces
{
    public interface IUserDataLogger
    {
        void Log(UserData data);
    }
}
