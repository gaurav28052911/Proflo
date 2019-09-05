using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.Model
{
    public class Board
    {
        [BsonId]
        public string BId { get; set; }
        [BsonElement("boardname")]
        public string BoardName { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        public List<Member> BoardMembers { get; set; }
        public List<Invitee> BoardInvites { get; set; }
        public List<BoardList> Lists { get; set; }

    }
}
