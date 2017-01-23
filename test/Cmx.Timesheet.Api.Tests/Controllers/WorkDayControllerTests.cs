using System.Threading.Tasks;
using System.Web.Http.Results;
using Cmx.Timesheet.Api.Controllers;
using Cmx.Timesheet.Api.Models;
using Cmx.Timesheet.Services;
using Cmx.Timesheet.TestUtils.Attributes;
using Moq;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Shouldly;
using Xunit;

namespace J2BI.Namespace.Template.Api.Tests.Controllers
{
    public class WorkDayControllerTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(WorkDayController).GetConstructors());
        }

        [Theory, WebApiAutoMoqData]
        public async Task SubmitWorkDay_ShouldCall_Submit_On_IWorkDaySubmitService_WithCorrectArgs(
            [Frozen] Mock<IWorkDaySubmitService> workDaySubmitServiceMock,
            WorkDaySubmitItem item,
            WorkDayController sut)
        {
            // act..
            await sut.SubmitWorkDay(item);

            // assert..
            workDaySubmitServiceMock.Verify(m => m.Submit(It.Is<WorkDaySubmitItem>(i => i == item)), Times.Once());
        }

        [Theory, WebApiAutoMoqData]
        public async Task SubmitWorkDay_ShouldReturnHttpStatusOk_WhenSubmitOnIWorkDaySubmitServiceReturnsSuccessfull(
            [Frozen] Mock<IWorkDaySubmitService> workDaySubmitServiceMock,
            WorkDaySubmitItem submitItem,
            WorkDayDetailItem detailItem,
            WorkDayController sut)
        {
            // arrange..
            workDaySubmitServiceMock.Setup(m => m.Submit(submitItem)).Returns(Task.FromResult(detailItem));

            // act..
            var actual = await sut.SubmitWorkDay(submitItem);

            // assert..
            actual.ShouldBeOfType<OkNegotiatedContentResult<WorkDayDetailItem>>();
        }

        [Theory, WebApiAutoMoqData]
        public async Task SubmitWorkDay_ShouldReturnCorrectResult_WhenSubmitOnIWorkDaySubmitServiceReturnsSuccessfull(
            [Frozen] Mock<IWorkDaySubmitService> workDaySubmitServiceMock,
            WorkDaySubmitItem submitItem,
            WorkDayDetailItem detailItem,
            WorkDayController sut)
        {
            // arrange..
            workDaySubmitServiceMock.Setup(m => m.Submit(submitItem)).Returns(Task.FromResult(detailItem));

            // act..
            var actual = await sut.SubmitWorkDay(submitItem);

            // assert..
            ((OkNegotiatedContentResult<WorkDayDetailItem>) actual).Content.ShouldBe(detailItem);
        }
    }
}