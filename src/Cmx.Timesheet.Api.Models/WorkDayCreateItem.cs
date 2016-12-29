using System;

namespace Cmx.Timesheet.Model
{
    public class WorkDayCreateItem : WorkDayUpdateItemBase
    {
        public Guid TimesheetId { get; set; }
        
    }
}