using PersonInformation.DataLogger.Implementations;
using PersonInformation.DataLogger.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System.Collections.Generic;

namespace PersonInformation.Web.App_Start
{
    public static class DependencyConfigurator
    {
        public static Container Configure(this Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<ICollection<IUserDataLogStorage>>(() => new List<IUserDataLogStorage>
            {
                new TextDataLogStorage("log.txt"),
                new XmlDataLogStorage(),
                new DatabaseDataLogStorage()
            }, Lifestyle.Singleton);
            container.Register<IUserDataLogger, UserDataLogger>(Lifestyle.Singleton);

            container.Verify();

            return container;
        }
    }
}