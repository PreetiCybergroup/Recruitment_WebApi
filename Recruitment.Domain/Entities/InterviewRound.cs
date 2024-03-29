﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Domain.Entities
{
   public class InterviewRound
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("InterviewRoundId")]
        public string InterviewRoundTypeId { get; set; }

        [BsonElement("InterviewProcessId")]
        public string InterviewProcessId { get; set; }

        [BsonElement("Interviewer")]
        public string Interviewer { get; set; }

        [BsonElement("FeedbackId")]
        public string FeedbackId { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

    }
}
