using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfloPortalBackend.Model;
using MongoDB.Driver;

namespace ProfloPortalBackend.DataAccessLayer
{
    public class CardImplements : ICardInterface
    {
        private readonly DBContext context;
        public CardImplements(DBContext dBContext)
        {
            context = dBContext;
        }
        public void createAttachment(int cardID,Attachement attachement)
        {
            var filter = Builders<Card>.Filter.Eq(c => c.CId, cardID);
            var update = Builders<Card>.Update.Push(c => c.Attachements,attachement);
            context.Cards.FindOneAndUpdate(filter, update);
        }

        public void CreateCard(Card card)
        {
            context.Cards.InsertOne(card);
        }

        public void createCardMembers(int cardId, Member member)
        {
            var filter = Builders<Card>.Filter.Eq(c => c.CId, cardId);
            var update = Builders<Card>.Update.Push(c => c.CardMembers, member);
            context.Cards.FindOneAndUpdate(filter, update);
        }

        public void createComments(int cardId,Comments comments)
        {
            var filter = Builders<Card>.Filter.Eq(c => c.CId, cardId);
            var update = Builders<Card>.Update.Push(c => c.Comments, comments);
            context.Cards.FindOneAndUpdate(filter, update);
        }

        public void createInvite(int cardID, invitee invite)
        {
            var filter = Builders<Card>.Filter.Eq(c => c.CId, cardID);
            var update = Builders<Card>.Update.Push(c => c.cardInvites, invite);
            context.Cards.FindOneAndUpdate(filter, update);
        }

        public void createLabel(int cardID,Label label)
        {
            var filter = Builders<Card>.Filter.Eq(c => c.CId, cardID);
            var update = Builders<Card>.Update.Push(c => c.Labels, label);
            context.Cards.FindOneAndUpdate(filter, update);
        }

        public ICollection<Attachement> getAttachment(int cardID)
        {
            Card card = context.Cards.Find(n => n.CId == cardID).First();
            return card.Attachements;
        }

        public Attachement getAttachmentByID(int cardId, int attachmentID)
        {
            Card card = context.Cards.Find(n => n.CId == cardId).First();
            Attachement attachement = card.Attachements.Find(n => n.AttachementId == attachmentID);
            return attachement;
        }

        public Card GetCardByID(int cardId)
        {
            Card card = context.Cards.Find(n => n.CId == cardId).First();
            return card;
        }

        public ICollection<invitee> getCardInvites(int cardID)
        {
            Card card = context.Cards.Find(n => n.CId == cardID).First();
            return card.cardInvites;
        }

        public ICollection<Label> getCardLabels(int cardID)
        {
            Card card = context.Cards.Find(n => n.CId == cardID).First();
            return card.Labels;
        }

        public ICollection<Member> getCardMembers(int cardID)
        {
            Card card = context.Cards.Find(n => n.CId == cardID).First();
            return card.CardMembers;
        }

        public List<Card> GetCards()
        {
            return context.Cards.Find(_ => true).ToList();
        }

        public Comments getCommentByID(int cardId, int commentID)
        {
            Card card = context.Cards.Find(n => n.CId == cardId).First();
            Comments comments = card.Comments.Find(n => n.commentID == commentID);
            return comments;
        }

        public ICollection<Comments> getComments(int cardID)
        {
            Card card = context.Cards.Find(n => n.CId == cardID).First();
            return card.Comments;
        }

        public Label getLabelByID(int cardId, int LabelID)
        {
            Card card = context.Cards.Find(n => n.CId == cardId).First();
            Label label = card.Labels.First(n => n.labId == LabelID);
            return label;
        }

        public bool removeAttachment(int cardId, int attachmentID)
        {
            Card card = context.Cards.Find(n => n.CId == cardId).First();
            Attachement attachement = card.Attachements.Find(n => n.AttachementId == attachmentID);
            var filter = Builders<Card>.Filter.Eq(n => n.CId, cardId);
            var update = Builders<Card>.Update.Pull(e => e.Attachements, attachement);
            var updatedResult = context.Cards.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool RemoveCard(int cardId)
        {
            var deletedResult = context.Cards.DeleteOne(n => n.CId == cardId);
            return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
        }

        public bool removeComments(int cardId, int commentID)
        {
            Card card = context.Cards.Find(n => n.CId == cardId).First();
            Comments comments = card.Comments.Find(n => n.commentID == commentID);
            var filter = Builders<Card>.Filter.Eq(n => n.CId, cardId);
            var update = Builders<Card>.Update.Pull(e => e.Comments,comments);
            var updatedResult = context.Cards.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool RemoveInvite(int cardId, int inviteID)
        {
            Card card = context.Cards.Find(n => n.CId == cardId).First();
            invitee invitee = card.cardInvites.Find(n => n.inviteID == inviteID );
            var filter = Builders<Card>.Filter.Eq(n => n.CId, cardId);
            var update = Builders<Card>.Update.Pull(e => e.cardInvites,invitee);
            var updatedResult = context.Cards.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool removeLabel(int cardId, int LabelID)
        {
            Card card = context.Cards.Find(n => n.CId == cardId).First();
            Label label = card.Labels.Find(n => n.labId == LabelID);
            var filter = Builders<Card>.Filter.Eq(n => n.CId, cardId);
            var update = Builders<Card>.Update.Pull(e => e.Labels,label);
            var updatedResult = context.Cards.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool RemoveMembers(int cardId, int Mid)
        {
            Card card = context.Cards.Find(n => n.CId == cardId).First();
            Member member = card.CardMembers.Find(n => n.Mid == Mid);
            var filter = Builders<Card>.Filter.Eq(n => n.CId, cardId);
            var update = Builders<Card>.Update.Pull(e => e.CardMembers,member);
            var updatedResult = context.Cards.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool updateAttachment(int cardID, int attachmentID, Attachement attachement)
        {
            //Card card = context.Cards.Find(n => n.CId == cardID).First();
            //Attachement attachement1 = card.Attachements.First(n => n.AttachementId == attachement.AttachementId);
            var filter = Builders<Card>.Filter.Eq(n => n.CId, cardID);
            var update = Builders<Card>.Update.Set(e => e.Attachements.Find(n=>n.AttachementId==attachmentID), attachement);
            var result = context.Cards.UpdateOneAsync(filter, update).Result;
            return result.IsAcknowledged && result.ModifiedCount > 0;
            
        }

        public bool UpdateCard(int cardId, Card card)
        {
            var filter = Builders<Card>.Filter.Where(c => c.CId == cardId);
            var updatedResult = context.Cards.ReplaceOne(filter, card);
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool UpdateCardMembers(int cardId,int memberID, Member member)
        {
            var filter = Builders<Card>.Filter.Eq(n => n.CId, cardId);
            var update = Builders<Card>.Update.Set(e => e.CardMembers.Find(n=>n.Mid==memberID), member);
            var updatedResult = context.Cards.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;

        }

        public bool  updateComments(int cardID, int commentID, Comments comments)
        {
            var filter = Builders<Card>.Filter.Eq(n => n.CId, cardID);
            var update = Builders<Card>.Update.Set(e => e.Comments.Find(n => n.commentID == commentID), comments);
            var updatedResult = context.Cards.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;

        }

        public bool UpdateInvite(int cardId, int inviteID, invitee invite)
        {
            var filter = Builders<Card>.Filter.Eq(n => n.CId, cardId);
            var update = Builders<Card>.Update.Set(e => e.cardInvites.Find(n => n.inviteID == inviteID), invite);
            var updatedResult = context.Cards.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool updateLabel(int cardID,int labelID, Label label)
        {
            var filter = Builders<Card>.Filter.Eq(n => n.CId, cardID);
            var update = Builders<Card>.Update.Set(e => e.Labels.Find(n => n.labId == labelID), label);
            var updatedResult = context.Cards.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }
    }
}
