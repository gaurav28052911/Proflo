using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.Model
{
    public class ListCard
    {
        [BsonId]
        public string CId { get; set; }
        
        [BsonElement("cardTitle")]
        public string CardTitle { get; set; }
        
        [BsonElement("createdDate")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        
        [BsonElement("dueDate")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
    }
}
