using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Agenda.Models
{
    public class Node
    {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { get; set; }
        public Contato Contato { get; set; }
        public string Before { get; set; }
        public Node Next { get; set; }

        public Node () { }
        public Node (Contato contato)
        {
            Contato = contato;
            Before = null;
            Next = null;
        }
    }
}