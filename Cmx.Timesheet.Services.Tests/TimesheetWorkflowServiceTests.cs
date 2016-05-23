using System;
using Cmx.Timesheet.DomainModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace Cmx.Timesheet.Services.Tests
{
    [TestClass]
    public class TimesheetWorkflowServiceTests
    {
        private TimesheetWorkflowService _service;
        private Mock<ITimesheetStore> _timesheetStoreMock;
        private Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
            _timesheetStoreMock = _fixture.Freeze<Mock<ITimesheetStore>>();
            _service = new TimesheetWorkflowService(_timesheetStoreMock.Object);
        }

        [TestMethod]
        public void SubmitTimesheet_ShouldSet_TimesheetStatus_To_Submitted()
        {
            _timesheetStoreMock.Setup(s => s.GetTimesheetById(It.IsAny<int>())).Returns<int>(id => new TimesheetModel {Id = id});
            CheckStatusAfterAction(_fixture.Create<int>(), id => _service.SubmitTimesheet(id), TimesheetStatus.Submitted);
        }

        [TestMethod]
        public void ApproveTimesheet_ShouldSet_TimesheetStatus_To_Approved()
        {
            CheckStatusAfterAction(1, id => _service.ApproveTimesheet(id), TimesheetStatus.Approved);
        }

        [TestMethod]
        public void RejectTimesheet_ShouldSet_TimesheetStatus_To_Rejected()
        {
            CheckStatusAfterAction(1, id => _service.RejectTimesheet(id), TimesheetStatus.Rejected);
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void SubmitTimesheetThrowsExceptionIfTimesheetNotFoundInRepo()
        {
            _service.SubmitTimesheet(9999);
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void ApproveTimesheetThrowsExceptionIfTimesheetNotFoundInRepo()
        {
            _service.ApproveTimesheet(9999);
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void RejectTimesheetThrowsExceptionIfTimesheetNotFoundInRepo()
        {
            _service.RejectTimesheet(9999);
        }

        private void CheckStatusAfterAction(int id, Action<int> action, TimesheetStatus status)
        {
            action(id);
            Assert.AreEqual(status, _timesheetStoreMock.Object.GetTimesheetById(id).Status);
        }
    }
}