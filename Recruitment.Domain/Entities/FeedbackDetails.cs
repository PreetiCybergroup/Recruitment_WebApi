using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Domain.Entities
{
  public class FeedbackDetails
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("InterviewProcessId")]
        public InterviewProcess InterviewProcess { get; set; }

        [BsonElement("TechnicalSkills")]
        public string TechnicalSkills { get; set; }

        [BsonElement("NonTechnicalSkills")]
        public string NonTechnicalSkills { get; set; }

        [BsonElement("Comments")]
        public string Comments { get; set; }

        [BsonElement("AreaOfConcern")]
        public string AreaOfConcern { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; }

    }
}
