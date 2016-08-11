using System;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.Model
{
    public class TimesheetListItem : TimesheetItemBase
    {
        public Guid TimesheetId { get; set; }

        public TimesheetStatus Status { get; set; } 
    }
}