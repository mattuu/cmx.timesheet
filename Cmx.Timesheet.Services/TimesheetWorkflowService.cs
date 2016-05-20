using System;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.Services
{
    public class TimesheetWorkflowService : ITimesheetWorkflowService
    {
        private readonly ITimesheetStore _timesheetStore;

        public TimesheetWorkflowService(ITimesheetStore timesheetStore)
        {
            if (timesheetStore == null) throw new ArgumentNullException("timesheetStore");
            _timesheetStore = timesheetStore;
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
            var timesheet = FindTimesheet(timesheetId);
            timesheet.Status = status;
            //new TimesheetUpdateModel()
            //_timesheetStore.UpdateTimesheet(timesheet);
        }

        private TimesheetModel FindTimesheet(int timesheetId)
        {
            var timesheet = _timesheetStore.GetTimesheetById(timesheetId);
            if (timesheet == null)
            {
                throw new NullReferenceException(string.Format("Timesheet not found for id {0}", timesheetId));
            }

            return timesheet;
        }
    }
}