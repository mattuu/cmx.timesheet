using Cmx.Timesheet.TestUtils.Attributes;

namespace Cmx.Timesheet.DataAccess.IntegrationTests.Infrastructure
{
    public class AutoMongoDbMoqDataAttribute : AutoMoqDataAttribute
    {
        public AutoMongoDbMoqDataAttribute()
        {
            Fixture.Customize(new MongoDbCustomization());
        }
    }
}