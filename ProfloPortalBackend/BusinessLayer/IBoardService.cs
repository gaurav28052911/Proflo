using ProfloPortalBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.BusinessLayer
{
     public interface IBoardService
    {
        List<Board> GetBoards();
        bool UpdateBoard(int boardId, Board board);
        Board GetBoardByID(int boardId);
        void CreateBoard(Board board);
        bool RemoveBoard(int boardId);
        void createMembers(int boardId, Member member);
        bool UpdateMembers(int boardId, int Mid, Member member);
        bool RemoveMembers(int boardId, int mID);
        void createInvite(int boardId, invitee invite);
        bool UpdateInvite(int boardId, int inviteID, invitee invite);
        ICollection<invitee> getBoardInvites(int boardId);
        ICollection<Member> getBoardMembers(int boardId);
        bool RemoveInvite(int boardId, int inviteID);
        ICollection<boardList> getBoardLists(int boardId);
    }
}
