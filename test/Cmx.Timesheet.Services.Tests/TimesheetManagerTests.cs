using System;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess.Models;
using Cmx.Timesheet.TestUtils.Attributes;
using Moq;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Cmx.Timesheet.Services.Tests
{
    public class TimesheetManagerTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowExceptionWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(TimesheetManager).GetConstructors());
        }

        [Theory, AutoMoqData]
        public async Task Retrieve_ShouldCall_GetByUserAndDate_On_ITimesheetProvider_WithCorrectArgs([Frozen] Mock<ITimesheetProvider> timesheetProviderMock,
                                                                                                     DateTime effectiveDate,
                                                                                                     Guid userId,
                                                                                                     TimesheetModel model,
                                                                                                     TimesheetManager sut)
        {
            // act..
            await sut.Retrieve(userId, effectiveDate);

            // assert..
            timesheetProviderMock.Verify(m => m.GetByUserAndDate(It.Is<Guid>(id => id == userId), It.Is<DateTime>(dt => dt == effectiveDate)), Times.Once);
        }
    }
}