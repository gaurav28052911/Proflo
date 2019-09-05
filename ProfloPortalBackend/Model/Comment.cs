using MongoDB.Bson.Serialization.Attributes;

namespace ProfloPortalBackend.Model
{
    public class Comment
    {
        [BsonId]
        public string CommentID { get; set; }

        [BsonElement("authoredBy")]
        public Member authoredBy { get; set; }
        
        [BsonElement("commentText")]
        public string CommentText { get; set; }

        // Also need date and time of when the comment was created

    }
}
