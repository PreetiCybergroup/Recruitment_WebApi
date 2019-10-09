using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Recruitment.Domain.Entities
{
    public class Candidate
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("UserName")]
        public string UserName { get; set; }
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
        [BsonElement("TechnicalSkills")]
        public string TechnicalSkills { get; set; }
        [BsonElement("Experience")]
        public string Experience { get; set; }
        [BsonElement("Keyword")]
        public string Keyword { get; set; }
        [BsonIgnore]
        public string Resume_base64 { get; set; }
    }
}
