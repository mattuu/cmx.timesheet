using Cmx.Timesheet.TestUtils.Customizations;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit2;

namespace Cmx.Timesheet.TestUtils.Attributes
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(new Fixture())
        {
            Fixture.Customize(new AutoMoqCustomization())
                   .Customize(new ObjectIdCustomization())
                   .Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}