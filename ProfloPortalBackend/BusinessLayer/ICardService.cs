using ProfloPortalBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.BusinessLayer
{
     public interface ICardService
    {
        List<Card> GetCards();
        bool UpdateCard(int cardId, Card card);
        Card GetCardByID(int cardId);
        void CreateCard(Card card);
        bool RemoveCard(int cardId);
        void createCardMembers(int cardId, Member member);
        bool UpdateCardMembers(int cardId, int memberID, Member member);
        bool RemoveMembers(int cardId, int Mid);
        void createInvite(int cardID, invitee invite);
        bool RemoveInvite(int cardId, int inviteID);
        bool UpdateInvite(int cardId, int inviteID, invitee invite);
        ICollection<invitee> getCardInvites(int cardID);
        ICollection<Member> getCardMembers(int cardID);
        //ICollection<teamBoard> getTeamBoards(int teamID);
        void createLabel(int cardID, Label label);
        bool updateLabel(int cardID, int labelID, Label label);
        bool removeLabel(int cardId, int LabelID);
        Label getLabelByID(int cardId, int LabelID);
        ICollection<Label> getCardLabels(int cardID);
        void createComments(int cardId, Comments comments);
        bool updateComments(int cardID, int commentID, Comments comments);
        bool removeComments(int cardId, int commentID);
        Comments getCommentByID(int cardId, int commentID);
        ICollection<Comments> getComments(int cardID);
        void createAttachment(int cardID, Attachement attachement);
        bool updateAttachment(int cardID, int attachmentID, Attachement attachement);
        bool removeAttachment(int cardId, int attachmentID);
        Attachement getAttachmentByID(int cardId, int attachmentID);
        ICollection<Attachement> getAttachment(int cardID);
    }
}
