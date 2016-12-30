using System;

namespace Cmx.Timesheet.Api.Models
{
    public class TimesheetListItem : TimesheetItemBase
    {
        public Guid TimesheetId { get; set; }

        //public TimesheetStatus Status { get; set; } 
    }
}