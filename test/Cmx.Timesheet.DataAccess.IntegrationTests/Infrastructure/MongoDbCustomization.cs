using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Ploeh.AutoFixture;

namespace Cmx.Timesheet.DataAccess.IntegrationTests.Infrastructure
{
    public class MongoDbCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<BsonObjectId>(cc => cc.FromFactory(() => BsonObjectId.Create(fixture.Create<int>())));
            fixture.Customize<ObjectId>(cc => cc.FromFactory(ObjectId.GenerateNewId));

            fixture.Customize<IMongoDatabase>(cc => cc.FromFactory(() =>
            {
                var mongoClient = new MongoClient(
                    new MongoUrl("mongodb://cmx_timesheet_full:3v*k0d'0=9z5?oS@ds135798.mlab.com:35798/cmx_timesheet"));

                var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
                ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);

                return mongoClient.GetDatabase("cmx_timesheet");
            }));
        }
    }
}