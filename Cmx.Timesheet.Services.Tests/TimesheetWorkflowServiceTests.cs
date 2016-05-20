using System;
using Cmx.Timesheet.DomainModel;
using J2BI.Holidays.ProductBrief.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmx.Timesheet.Services.Tests
{
    [TestClass]
    public class TimesheetWorkflowServiceTests
    {
        private TimesheetWorkflowService _service;
        private InMemoryTimesheetStore _timesheetStore;

        [TestInitialize]
        public void Init()
        {
            _timesheetStore = new InMemoryTimesheetStore();
            _service = new TimesheetWorkflowService(_timesheetStore);
        }

        [TestMethod]
        public void SubmitTimesheetShouldChangeTimesheetStatusToSubmitted()
        {
            CheckStatusAfterAction(1, id => _service.SubmitTimesheet(id), TimesheetStatus.Submitted);
        }

        [TestMethod]
        public void ApproveTimesheetShouldChangeTimesheetStatusToApproved()
        {
            CheckStatusAfterAction(1, id => _service.ApproveTimesheet(id), TimesheetStatus.Approved);
        }

        [TestMethod]
        public void RejectTimesheetShouldChangeTimesheetStatusToRejected()
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
            Assert.AreEqual(status, _timesheetStore.GetTimesheetById(id).Status);
        }
    }
}