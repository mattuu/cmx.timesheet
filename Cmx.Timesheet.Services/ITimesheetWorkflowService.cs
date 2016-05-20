namespace Cmx.Timesheet.Services
{
    public interface ITimesheetWorkflowService
    {
        void SubmitTimesheet(int timesheetId);

        void ApproveTimesheet(int timesheetId);

        void RejectTimesheet(int timesheetId);
    }
}