using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.Model
{
    public class Card
    {
        [BsonId]
        public string CardId { get; set; }

        public string CardName { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public List<Member> Assignees { get; set; }
        public List<Label> Labels { get; set; }
        public List<Attachment> Attachements { get; set; }
        public List<Comment> Comments { get; set; }
    
    }
}
