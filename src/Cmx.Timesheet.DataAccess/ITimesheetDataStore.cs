﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.DataAccess
{
    public interface ITimesheetDataStore
    {
        IEnumerable<TimesheetModel> GetTimesheets();

        IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId);

        TimesheetModel GetTimesheetById(int timesheetId);

        TimesheetModel UpdateTimesheet(TimesheetUpdateModel timesheetUpdateModel);

        TimesheetModel InsertTimesheet(TimesheetModel timesheetModel);

        void DeleteTimesheet(int timesheetId);
    }
}
