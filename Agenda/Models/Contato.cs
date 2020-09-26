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

        [BsonElement ("Email")]
        [JsonProperty ("Email")]
        public string Email { get; set; }

        [BsonElement ("Telefone")]
        [JsonProperty ("Telefone")]
        public string Telefone { get; set; }
    }
}