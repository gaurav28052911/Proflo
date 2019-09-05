using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.Model
{
    public class TeamBoard
    {
        [BsonId]
        public string BoardId { get; set; }
        [BsonElement("boardName")]
        public string BoardName { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
    }
}
