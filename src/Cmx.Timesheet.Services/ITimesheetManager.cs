using System;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess.Models;

namespace Cmx.Timesheet.Services
{
    public interface ITimesheetManager
    {
        Task<TimesheetModel> Retrieve(Guid userId, DateTime effectiveDate);
    }
}