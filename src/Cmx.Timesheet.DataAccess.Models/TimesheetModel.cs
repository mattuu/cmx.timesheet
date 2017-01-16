using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cmx.Timesheet.DataAccess.Models
{
    public class TimesheetModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public DateTime StartDate { get; set; }

        [BsonElement]
        public DateTime EndDate { get; set; }

        [BsonElement]
        public TimesheetStatus Status { get; set; }

        [BsonElement]
        public decimal TotalHours { get; set; }

        [BsonElement]
        public Guid ConfigurationId { get; set; }

        [BsonElement]
        public DateTime CreatedOn { get; set; }

        [BsonElement]
        public string CreatedBy { get; set; }

        [BsonElement]
        public DateTime? SubmittedOn { get; set; }

        [BsonElement]
        public string SubmittedBy { get; set; }

        [BsonElement]
        public DateTime? ApprovedOn { get; set; }

        [BsonElement]
        public string ApprovedBy { get; set; }

        [BsonElement]
        public DateTime? RejectedOn { get; set; }

        [BsonElement]
        public string RejectedBy { get; set; }

    }
}