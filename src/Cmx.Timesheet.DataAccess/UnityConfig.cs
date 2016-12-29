using Microsoft.Practices.Unity;
using MongoDB.Driver;

namespace Cmx.Timesheet.DataAccess
{
    public static class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IMongoClient>(new InjectionFactory(c =>
            {
                //var settings = new MongoClientSettings();
                //settings.
                var mongoClient = new MongoClient(
                    new MongoUrl("mongodb://cmx_timesheet_full:3v*k0d'0=9z5?oS@ds135798.mlab.com:35798/cmx_timesheet"));
                
                return mongoClient;
            }));
            container.RegisterType<IMongoDatabase>(
                new InjectionFactory(c => c.Resolve<IMongoClient>().GetDatabase("cmx_timesheet")));
        }
    }
}