using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmx.Timesheet.DataAccess.Models;

namespace Cmx.Timesheet.Services
{
    public class TimesheetManager : ITimesheetManager
    {
        private readonly ITimesheetProvider _timesheetProvider;

        public TimesheetManager(ITimesheetProvider timesheetProvider)
        {
            if (timesheetProvider == null) throw new ArgumentNullException(nameof(timesheetProvider));
            _timesheetProvider = timesheetProvider;
        }

        public Task<TimesheetModel> Retrieve(Guid userId, DateTime effectiveDate)
        {
            var model = _timesheetProvider.GetByUserAndDate(userId, effectiveDate);

            return model;
        }
    }
}
