using Cmx.Timesheet.TestUtils.AutoFixtureCustomizations;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;

namespace Cmx.Timesheet.TestUtils.Attributes
{
    public class WebApiAutoMoqDataAttribute : AutoDataAttribute
    {
        public WebApiAutoMoqDataAttribute()
        : base(new Fixture()
            .Customize(new WebApiAutoMoqCustomization()))
        {
        }
    }
}
