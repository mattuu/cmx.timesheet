using System;
using System.Collections.Generic;

namespace Cmx.Timesheet.DomainModel
{
    public abstract class TimesheetModelBase
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<WorkDayModel> WorkDays { get; set; }
    }
}