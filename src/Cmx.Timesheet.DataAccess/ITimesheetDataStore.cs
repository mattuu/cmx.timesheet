﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cmx.Timesheet.DomainModel;

namespace Cmx.Timesheet.DataAccess
{
    public interface ITimesheetDataStore
    {
        Task<IEnumerable<TimesheetModel>> GetTimesheets();

        IEnumerable<TimesheetModel> GetTimesheetsByUser(int ownerId);

        Task<TimesheetModel> GetTimesheetById(Guid timesheetId);

        Task<bool> UpdateTimesheetStatus(TimesheetModel model);

        Task<TimesheetModel> CreateTimesheet(TimesheetModel timesheetModel);

        void DeleteTimesheet(int timesheetId);
    }
}
