using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.DataAccess
{
    public interface ITimesheetDataStore
    {
        IEnumerable<TimesheetModel> GetTimesheetsByUser(string username);


    }
}
