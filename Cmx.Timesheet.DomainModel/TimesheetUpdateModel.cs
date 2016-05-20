using System;
using System.Collections.Generic;

namespace Cmx.Timesheet.DomainModel
{
    public class TimesheetUpdateModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<WorkDayModel> WorkDays { get; set; }
    }
}