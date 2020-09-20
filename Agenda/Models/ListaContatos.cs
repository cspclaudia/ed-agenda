using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Agenda.Models
{
    public class ListaContatos
    {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string Id { get; set; }

        public List<Contato> Lista { get; set; }
    }
}