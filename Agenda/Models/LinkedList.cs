using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Agenda.Models
{
    public class LinkedList
    {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { get; set; }
        public Node Head { get; set; }
    }
}