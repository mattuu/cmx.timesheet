using MongoDB.Bson.Serialization.Conventions;

namespace Cmx.Timesheet.DataAccess
{
    public static class MongoDbConfig
    {
        public static void Register()
        {
            ConventionRegistry.Register("camel case",
                new ConventionPack {new CamelCaseElementNameConvention()},
                t => t.FullName.StartsWith("Cmx.Timesheet.DataAccess."));
        }
    }
}