using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Agenda.Models
{
    public class Node
    {
        // [BsonId]
        // [BsonRepresentation (BsonType.ObjectId)]
        // public string Id { get; set; }
        public Contato contato { get; set; }
        public Node next { get; set; }

        public Node () { }
        public Node (Contato contatoIn)
        {
            contato = contatoIn;
            next = null;
        }
    }
}