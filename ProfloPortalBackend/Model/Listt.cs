using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.Model
{
    public class Listt
    {
        [BsonId]
        public int LId { get; set; }
        [BsonElement("listname")]
        public string ListName { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public List<listCards> Cards { get; set; }
    }
}
