using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Recruitment.Domain.Entities
{
    public class Feeback
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }
    }
}