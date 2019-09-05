using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.Model
{
    public class List
    {
        [BsonId]
        public string LId { get; set; }
        
        [BsonElement("listTitle")]
        public string ListTitle { get; set; }

        public int ListPosition { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        
        [BsonElement("cards")]
        public List<ListCard> Cards { get; set; }
    }
}
