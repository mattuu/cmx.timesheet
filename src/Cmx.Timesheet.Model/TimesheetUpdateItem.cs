using System;

namespace Cmx.Timesheet.Model
{
    public class TimesheetUpdateItem : TimesheetCreateItem
    {
        public Guid TimesheetId { get; set; }
    }
}