using System.Collections.Generic;
using Cmx.Timesheet.DomainModel;
using Cmx.Timesheet.DomainModel.Configuration;

namespace Cmx.Timesheet.Services
{
    public interface ITimesheetStore
    {
        IEnumerable<TimesheetModel> GetTimesheets();

        IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId);

        TimesheetModel GetTimesheetById(int timesheetId);

        TimesheetModel UpdateTimesheet(TimesheetUpdateModel timesheetUpdateModel);

        TimesheetModel InsertTimesheet(TimesheetModel timesheetModel);

        void DeleteTimesheet(int timesheetId);
    }
}