using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.Model
{
    public class Team
    {
        [BsonId]
        public string TeamId;
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("description")]
        public string Description { get; set; }
        
        [BsonElement("boards")]
        public List<TeamBoard> TeamBoards { get; set; }
        
        [BsonElement("members")]
        public List<Member> TeamMembers { get; set; }
        
        // [BsonElement("invites")]
        // public List<Invitee> TeamInvites { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
