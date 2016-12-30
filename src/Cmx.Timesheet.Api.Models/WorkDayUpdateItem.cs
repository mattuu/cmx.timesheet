using System;

namespace Cmx.Timesheet.Api.Models
{
    public class WorkDayUpdateItem : WorkDayUpdateItemBase
    {
        public Guid WorkDayId { get; set; }
    }
}