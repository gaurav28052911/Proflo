using MongoDB.Bson.Serialization.Attributes;

namespace ProfloPortalBackend.Model
{
    public class Invitee
    {
        [BsonId]
        public string InviteId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
    }
}