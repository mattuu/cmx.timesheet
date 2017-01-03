using System;
using Cmx.Timesheet.Api.Models;
using Cmx.Timesheet.DataAccess.Models;

namespace Cmx.Timesheet.Mappings
{
    public class TimesheetModelToTimesheetListItemMap : AutoMapperMap<TimesheetModel, TimesheetListItem>
    {
        public TimesheetModelToTimesheetListItemMap()
        {
            Map.ForMember(i => i.TimesheetId, cfg => cfg.MapFrom(m => $"{m.Id}"));
        }
    }
}