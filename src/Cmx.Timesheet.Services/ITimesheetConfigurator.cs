using Cmx.Timesheet.DataAccess.Models.Configuration;

namespace Cmx.Timesheet.Services
{
    public interface ITimesheetConfigurator
    {
        void CreateTimesheetConfiguration(int userId, TimesheetConfigModel timesheetConfigModel);

        TimesheetConfigModel GetCurrentByUserId(int userId);
    }
}