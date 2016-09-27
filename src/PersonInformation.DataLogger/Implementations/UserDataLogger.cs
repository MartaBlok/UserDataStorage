using System.Collections.Generic;
using PersonInformation.DataLogger.Interfaces;
using PersonInformation.DataLogger.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace PersonInformation.DataLogger.Implementations
{
    public class UserDataLogger : IUserDataLogger
    {
        private readonly ICollection<IUserDataLogStorage> _logStorages;

        // we may consider changing argument type from ICollection to specific 'Settings' class
        // to be sure that there are not ambiguity during DI resolving
        public UserDataLogger(ICollection<IUserDataLogStorage> logStorages)
        {
            _logStorages = logStorages ?? new List<IUserDataLogStorage>();
            mapper = MapperCfg.CreateMapper();
        }

        private static readonly MapperConfiguration MapperCfg = new MapperConfiguration(cfg => {
            cfg.CreateMap<UserData, UserDataLogDTO>();
        });

        private readonly IMapper mapper;

        public void Log(UserData data)
        {
            var dto = mapper.Map<UserDataLogDTO>(data);
            Parallel.ForEach(_logStorages, s =>
            {
                s.Log(dto);
            });
        }
    }
}
