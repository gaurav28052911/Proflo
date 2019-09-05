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
        public int CId { get; set; }

        [BsonElement("cardname")]
        public string cardName { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public List<Member> CardMembers { get; set; }
        public List<Label> Labels { get; set; }
        public List<Attachement> Attachements { get; set; }
        public List<Comments> Comments { get; set; }
        public List<invitee> cardInvites { get; set; }


    }
}
