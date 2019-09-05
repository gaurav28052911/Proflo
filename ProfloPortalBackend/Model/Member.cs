using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.Model
{
    public class Member
    {
        [BsonId]
        public string MemberId { get; set; }
        
        [BsonElement("memberName")]
        public string MemberName { get; set; }
        
        [BsonElement("status")]
        public string Status { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        
    }
}
