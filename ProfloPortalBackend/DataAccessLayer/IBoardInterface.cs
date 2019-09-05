using ProfloPortalBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.DataAccessLayer
{
     public interface IBoardInterface
    {
        List<Board> GetBoards();
        bool UpdateBoard(string boardId, Board board);
        Board GetBoardByID(string boardId);
        void CreateBoard(Board board);
        bool RemoveBoard(string boardId);
        void CreateMembers(string boardId, Member member);
        bool UpdateMembers(string boardId, string memberId, Member member);
        bool RemoveMembers(string boardId, string memberId);
        void CreateInvite(string boardId, Invitee invite);
        bool UpdateInvite(string boardId, string inviteId, Invitee invite);
        ICollection<Invitee> GetBoardInvites(string boardId);
        ICollection<Member> GetBoardMembers(string boardId);
        bool RemoveInvite(string boardId, string inviteId);
        ICollection<BoardList> GetBoardLists(string boardId);
    }
}
