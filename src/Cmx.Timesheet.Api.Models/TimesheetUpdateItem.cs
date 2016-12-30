using System;

namespace Cmx.Timesheet.Api.Models
{
    public class TimesheetUpdateItem : TimesheetCreateItem
    {
        public Guid TimesheetId { get; set; }
    }
}