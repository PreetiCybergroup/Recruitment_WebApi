using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Domain.Entities
{
    public class Candidate
    {
        //[BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("DOB")]
        public string DateOfBirth { get; set; }
        [BsonElement("Mobile")]
        public string Mobile { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("ResumePath")]
        public string ResumePath { get; set; }
        //[BsonElement("Resume")]
        //public string Resume { get; set; }
        [BsonElement("TechnicalSkills")]
        public string TechnicalSkills { get; set; }
        [BsonElement("Experience")]
        public string Experience { get; set; }
        //[BsonElement("FileName")]
        //public string FileName { get; set; }

    }
}
