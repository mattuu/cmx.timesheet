using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.Api.Models;
using Cmx.Timesheet.DataAccess.Models;

namespace Cmx.Timesheet.Services
{
    public interface ITimesheetProvider
    {
        Task<IEnumerable<TimesheetListItem>> GetTimesheetListItems();

        Task<TimesheetDetailsItem> GetTimesheetDetailsById(Guid timesheetId);

        Task<TimesheetDetailsItem> CreateTimesheet(TimesheetCreateItem timesheetCreateItem);

        Task<TimesheetDetailsItem> UpdateTimesheet(Guid timesheetId, TimesheetUpdateItem timesheetUpdateItem);

        Task<TimesheetModel> GetByUserAndDate(Guid userId, DateTime dateTime);
    }
}