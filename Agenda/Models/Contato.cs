using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Agenda.Models
{
    public class Contato
    {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement ("Nome")]
        [JsonProperty ("Nome")]
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}