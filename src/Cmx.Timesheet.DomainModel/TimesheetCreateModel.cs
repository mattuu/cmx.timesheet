using System;

namespace Cmx.Timesheet.DomainModel
{
    public class TimesheetCreateModel : TimesheetModelBase
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public TimesheetStatus Status => TimesheetStatus.New;
    }
}