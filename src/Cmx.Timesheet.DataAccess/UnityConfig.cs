using Microsoft.Practices.Unity;
using MongoDB.Driver;

namespace Cmx.Timesheet.DataAccess
{
    public static class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IMongoClient, MongoClient>();
            container.RegisterType<IMongoDatabase>(new InjectionFactory(c => c.Resolve<IMongoClient>().GetDatabase("Cmx-Timesheet")));
        }
    }
}
