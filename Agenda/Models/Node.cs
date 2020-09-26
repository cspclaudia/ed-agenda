using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Agenda.Models
{
    public class Node
    {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { get; set; }
        public Contato Contato { get; set; }
        public Node Next { get; set; }

        public Node () { }
        public Node (Contato contato)
        {
            Contato = contato;
            Next = null;
        }
    }
}