using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cmx.Timesheet.DataAccess.Models
{
    public class WorkDayModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public DateTime Date { get; set; }

        [BsonElement]
        public TimeSpan StartTime { get; set; }

        [BsonElement]
        public TimeSpan EndTime { get; set; }

        [BsonElement]
        public TimeSpan BreakDuration { get; set; }
    }
}