using System;
using System.Collections.Generic;
using Cmx.Timesheet.DomainModel.Configuration;

namespace Cmx.Timesheet.DomainModel
{
    public class TimesheetModel
    {
        public TimesheetModel()
        {
            WorkDays = new HashSet<WorkDayModel>();
        }

        public int Id { get; set; }

        public TimesheetConfigModel Configuration { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime SubmittedOn { get; set; }

        public string SubmittedBy { get; set; }

        public DateTime ApprovedOn { get; set; }

        public string ApprovedBy { get; set; }

        public DateTime RejectedOn { get; set; }

        public string RejectedBy { get; set; }

        public TimesheetStatus Status { get; set; }

        public ICollection<WorkDayModel> WorkDays { get; set; }
    }
}