using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.Model;

namespace Cmx.Timesheet.Services
{
    public interface ITimesheetProvider
    {
        Task<IEnumerable<TimesheetListItem>> GetTimesheetListItems();
        Task<TimesheetDetailsItem> GetTimesheetDetailsById(Guid timesheetId);
    }
}