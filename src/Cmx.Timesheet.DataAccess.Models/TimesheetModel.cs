using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace Cmx.Timesheet.DataAccess.Models
{
    public class TimesheetModel
    {
        [BsonId]
        public BsonObjectId Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TimesheetStatus Status { get; set; }

        public decimal TotalHours { get; set; }

        public Guid ConfigurationId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? SubmittedOn { get; set; }

        public string SubmittedBy { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public string ApprovedBy { get; set; }

        public DateTime? RejectedOn { get; set; }

        public string RejectedBy { get; set; }

    }
}