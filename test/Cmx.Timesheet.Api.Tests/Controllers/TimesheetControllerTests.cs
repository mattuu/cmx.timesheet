using Cmx.Timesheet.Api.Controllers;
using Cmx.Timesheet.Services;
using Moq;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace J2BI.Namespace.Template.Api.Tests.Controllers
{
    public class TimesheetControllerTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(TimesheetController).GetConstructors());
        }

        [Theory, AutoMoqData]
        public async void GetAll_ShouldCall_GetAll_On_ITimesheetDataStore(
            [Frozen] Mock<ITimesheetProvider> timesheetProviderMock, TimesheetController sut)
        {
            // act..
            await sut.GetAll();

            // assert..
            timesheetProviderMock.Verify(m => m.GetTimesheetListItems(), Times.Once());
        }
    }
}