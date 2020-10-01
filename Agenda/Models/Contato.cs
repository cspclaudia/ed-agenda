using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Agenda.Models
{
    public class Contato
    {
        // [BsonId]
        // [BsonRepresentation (BsonType.ObjectId)]
        // public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}