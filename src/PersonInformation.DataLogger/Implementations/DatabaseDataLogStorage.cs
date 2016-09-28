using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using LiteDB.Platform;
using PersonInformation.DataLogger.Interfaces;
using PersonInformation.DataLogger.Models;

namespace PersonInformation.DataLogger.Implementations
{
    public class DatabaseDataLogStorage : IUserDataLogStorage
    {
        public DatabaseDataLogStorage()
        {
            LitePlatform.Initialize(new LitePlatformFullDotNet());
        }
        public void Log(UserDataLogDTO user)
        {
            using (var db = new LiteDatabase(@"LogStorage.db"))
            {
                var usersData = db.GetCollection<UserDataLogDTO>("users");
                usersData.Insert(user);
            }
        }
    }
}
