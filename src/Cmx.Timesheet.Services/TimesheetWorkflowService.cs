using System;
using Cmx.Timesheet.DataAccess;
using Cmx.Timesheet.DomainModel;

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
            var timesheet = FindTimesheet(timesheetId);

            _timesheetDataStore.UpdateTimesheet(new TimesheetUpdateModel
            {
                Id = timesheetId,
                StartDate = timesheet.StartDate,
                EndDate = timesheet.EndDate,
                WorkDays = timesheet.WorkDays,
                Status = status
            });
        }

        private TimesheetModel FindTimesheet(int timesheetId)
        {
            var timesheet = _timesheetDataStore.GetTimesheetById(timesheetId);
            if (timesheet == null)
            {
                throw new NullReferenceException(string.Format("Timesheet not found for id {0}", timesheetId));
            }

            return timesheet;
        }
    }
}