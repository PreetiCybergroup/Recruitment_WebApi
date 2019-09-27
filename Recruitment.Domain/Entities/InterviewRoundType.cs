using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Recruitment.Domain.Entities
{
    public class InterviewRoundType
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("RoundType")]
        public string RoundType { get; set; }
    }
}