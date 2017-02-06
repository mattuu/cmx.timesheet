using MongoDB.Bson;
using Ploeh.AutoFixture;

namespace Cmx.Timesheet.TestUtils.Customizations
{
    public class ObjectIdCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<ObjectId>(boid => boid.FromFactory(() => new ObjectId(new byte[12])));
        }
    }
}