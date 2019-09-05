using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.Model
{
    public class Attachment
    {
        [BsonId]
        public int AttachmentId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public int Size { get; set; }
    }
}
