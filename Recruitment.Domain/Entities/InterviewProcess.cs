using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Domain.Entities
{
  public class InterviewProcess
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("CandidateId")]
        public string CandidateId { get; set; }

        [BsonElement("FeedbackStatus")]
        public string FeedbackStatus { get; set; }

        [BsonElement("StartDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("EndDate")]
        public DateTime EndDate { get; set; }




    }
}
