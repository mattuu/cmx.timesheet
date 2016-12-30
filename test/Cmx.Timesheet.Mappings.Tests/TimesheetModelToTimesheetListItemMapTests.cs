using Cmx.Timesheet.TestUtils.Attributes;
using Ploeh.AutoFixture.Idioms;
using Xunit;

namespace Cmx.Timesheet.Mappings.Tests
{
    public class TimesheetModelToTimesheetListItemMapTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(TimesheetModelToTimesheetListItemMap).GetConstructors());
        }
    }
}
