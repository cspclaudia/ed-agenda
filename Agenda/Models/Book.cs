using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Agenda.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement ("Nome")]
        [JsonProperty ("Nome")]
        public string Nome { get; set; }

        public LinkedList<Contato> Lista { get; set; }
    }
}