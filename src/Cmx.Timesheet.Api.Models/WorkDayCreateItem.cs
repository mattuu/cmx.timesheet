using System;

namespace Cmx.Timesheet.Api.Models
{
    public class WorkDayCreateItem : WorkDayUpdateItemBase
    {
        public Guid TimesheetId { get; set; }
        
    }
}