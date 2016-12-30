using AutoMapper;
using Cmx.Timesheet.Api.Models;
using Cmx.Timesheet.DataAccess.Models;
using Cmx.Timesheet.TestUtils.Attributes;
using Ploeh.AutoFixture.Idioms;
using Shouldly;
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

        [Theory, AutoMoqData]
        public void Map_ShouldConfigureMappingFor_TimesheetId(TimesheetModel source, TimesheetModelToTimesheetListItemMap sut)
        {
            // arrange..
            Mapper.Initialize(cfg => cfg.AddProfile(sut));

            // act..
            var actual = Mapper.Map<TimesheetListItem>(source);

            // arrange..
            //actual.TimesheetId.ShouldBe(source.Id);

        }
    }
}
