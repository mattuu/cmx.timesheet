using System;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace Cmx.Timesheet.Services.Tests
{
    [TestClass]
    public class TimesheetWorkflowServiceTests
    {
        private TimesheetWorkflowService _service;
        private Mock<ITimesheetDataStore> _timesheetStoreMock;
        private Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
            _timesheetStoreMock = _fixture.Freeze<Mock<ITimesheetDataStore>>();
            _service = new TimesheetWorkflowService(_timesheetStoreMock.Object);
        }

        [TestMethod]
        public void SubmitTimesheet_ShouldCall_UpdateTimesheet_On_ITimesheetStore_With_TimesheetStatus_Equals_Submitted()
        {
            //_timesheetStoreMock.Setup(s => s.GetTimesheetById(It.IsAny<Guid>())).Returns<Guid>(id => Task.FromResult(new TimesheetModel { Id = id }));

            _timesheetStoreMock.Setup(s => s.UpdateTimesheet(It.Is<TimesheetModel>(tm => tm.Status == TimesheetStatus.Submitted))).Verifiable();

            _service.SubmitTimesheet(_fixture.Create<int>());

            _timesheetStoreMock.VerifyAll();
        }

        [TestMethod]
        public void     ApproveTimesheet_ShouldCall_UpdateTimesheet_On_ITimesheetStore_With_TimesheetStatus_Equals_Approved()
        {
            //_timesheetStoreMock.Setup(s => s.GetTimesheetById(It.IsAny<Guid>())).Returns<Guid>(id => Task.FromResult(new TimesheetModel {Id = id}));

            _timesheetStoreMock.Setup(s => s.UpdateTimesheet(It.Is<TimesheetModel>(tm => tm.Status == TimesheetStatus.Approved))).Verifiable();

            _service.ApproveTimesheet(_fixture.Create<int>());
        
            _timesheetStoreMock.VerifyAll();
        }

        [TestMethod]
        public void RejectTimesheet_ShouldCall_UpdateTimesheet_On_ITimesheetStore_With_TimesheetStatus_Equals_Rejected()
        {
            //_timesheetStoreMock.Setup(s => s.GetTimesheetById(It.IsAny<Guid>())).Returns<Guid>(id => Task.FromResult(new TimesheetModel { Id = id }));

            _timesheetStoreMock.Setup(s => s.UpdateTimesheet(It.Is<TimesheetModel>(tm => tm.Status == TimesheetStatus.Rejected))).Verifiable();

            _service.RejectTimesheet(_fixture.Create<int>());

            _timesheetStoreMock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void SubmitTimesheet_ThrowsException_If_TimesheetStoreReturnsNull()
        {
            _timesheetStoreMock.Setup(s => s.GetTimesheetById(It.IsAny<Guid>())).Returns<Guid>(null);
            _service.SubmitTimesheet(_fixture.Create<int>());
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void ApproveTimesheet_ThrowsException_If_TimesheetStoreReturnsNull()
        {
            _timesheetStoreMock.Setup(s => s.GetTimesheetById(It.IsAny<Guid>())).Returns<Guid>(null);
            _service.ApproveTimesheet(_fixture.Create<int>());
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void RejectTimesheet_ThrowsException_If_TimesheetStoreReturnsNull()
        {
            _timesheetStoreMock.Setup(s => s.GetTimesheetById(It.IsAny<Guid>())).Returns<Guid>(null);
            _service.RejectTimesheet(_fixture.Create<int>());
        }
    }
}