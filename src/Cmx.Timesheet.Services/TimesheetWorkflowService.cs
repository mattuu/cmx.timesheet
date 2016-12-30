using System;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DataAccess.Models;

namespace Cmx.Timesheet.Services
{
    public class TimesheetWorkflowService : ITimesheetWorkflowService
    {
        private readonly ITimesheetDataStore _timesheetDataStore;

        public TimesheetWorkflowService(ITimesheetDataStore timesheetDataStore)
        {
            if (timesheetDataStore == null) throw new ArgumentNullException("timesheetDataStore");
            _timesheetDataStore = timesheetDataStore;
        }

        public void SubmitTimesheet(int timesheetId)
        {
            ChangeStatus(timesheetId, TimesheetStatus.Submitted);
        }

        public void ApproveTimesheet(int timesheetId)
        {
            ChangeStatus(timesheetId, TimesheetStatus.Approved);
        }

        public void RejectTimesheet(int timesheetId)
        {
            ChangeStatus(timesheetId, TimesheetStatus.Rejected);
        }

        private void UpdateTimesheet(int timesheetId)
        {
            
        }

        private void ChangeStatus(int timesheetId, TimesheetStatus status)
        {
            var timesheetModel = FindTimesheet(timesheetId);
            timesheetModel.Status = status;
            _timesheetDataStore.UpdateTimesheet(timesheetModel);
        }

        private TimesheetModel FindTimesheet(int timesheetId)
        {
            var timesheet = _timesheetDataStore.GetTimesheetById(default (Guid));
            if (timesheet == null)
            {
                throw new NullReferenceException(string.Format("Timesheet not found for id {0}", timesheetId));
            }

            // TODO: change to async..
            return timesheet.Result;
        }
    }
}