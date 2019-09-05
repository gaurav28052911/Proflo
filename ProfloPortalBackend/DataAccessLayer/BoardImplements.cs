using ProfloPortalBackend.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.DataAccessLayer
{
    public class BoardImplements
    {
        public class BoardImplementations: IBoardInterface
        {
            private readonly DBContext context;
            public BoardImplementations(DBContext dBContext)
            {
                context = dBContext;
            }
            public void CreateBoard(Board board)
            {
                context.Boards.InsertOne(board);
            }

            public void CreateInvite(string boardId, Invitee invite)
            {
                var filter = Builders<Board>.Filter.Eq(c => c.BId, boardId);
                var update = Builders<Board>.Update.Push(c => c.BoardInvites, invite);
                context.Boards.FindOneAndUpdate(filter, update);
            }

            public void CreateMembers(string boardId, Member member)
            {
                var filter = Builders<Board>.Filter.Eq(c => c.BId, boardId);
                var update = Builders<Board>.Update.Push(c => c.BoardMembers, member);
                context.Boards.FindOneAndUpdate(filter, update);
            }

            public Board GetBoardByID(string boardId)
            {
                Board board = context.Boards.Find(n => n.BId == boardId).First();
                return board;
            }

            public ICollection<Invitee> GetBoardInvites(string boardId)
            {
                Board board = context.Boards.Find(n => n.BId == boardId).First();
                return board.BoardInvites;
            }

            public ICollection<BoardList> GetBoardLists(string boardId)
            {
                Board board = context.Boards.Find(n => n.BId == boardId).First();
                return board.Lists;
            }

            public ICollection<Member> GetBoardMembers(string boardId)
            {
                Board board = context.Boards.Find(n => n.BId == boardId).First();
                return board.BoardMembers;
            }

            public List<Board> GetBoards()
            {
                return context.Boards.Find(_ => true).ToList();
            }

            public bool RemoveBoard(string boardId)
            {
                var deletedResult = context.Boards.DeleteOne(c => c.BId == boardId);
                return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
            }

            public bool RemoveInvite(string boardId, string inviteID)
            {
                Board GetBoard = context.Boards.Find(n => n.BId == boardId).First();
                Invitee _invite = GetBoard.BoardInvites.Find(n => n.InviteId == inviteID);
                var filter = Builders<Board>.Filter.Eq(n => n.BId, boardId);
                var delete = Builders<Board>.Update.Pull(n => n.BoardInvites, _invite);
                var updatedResult = context.Boards.UpdateOneAsync(filter, delete).Result;
                return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
            }

            public bool RemoveMembers(string boardId, string mID)
            {
                Board GetBoard = context.Boards.Find(n => n.BId == boardId).First();
                Member _member = GetBoard.BoardMembers.First(n => n.MemberId == mID);
                var filter = Builders<Board>.Filter.Eq(n => n.BId, boardId);
                var delete = Builders<Board>.Update.Pull(n => n.BoardMembers, _member);
                var updatedResult = context.Boards.UpdateOneAsync(filter, delete).Result;
                return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
            }

            public bool UpdateBoard(string boardId, Board board)
            {
                var filter = Builders<Board>.Filter.Where(c => c.BId == boardId);
                var updatedResult = context.Boards.ReplaceOne(filter, board);
                return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
            }

            public bool UpdateInvite(string boardId, string inviteID, Invitee invte)
            {
                Board GetBoard = context.Boards.Find(n => n.BId == boardId).First();
                Invitee _invite = GetBoard.BoardInvites.Find(n => n.InviteId == inviteID);
                var filter = Builders<Board>.Filter.Eq(n => n.BId, boardId);
                var update = Builders<Board>.Update.Set(n => n.BoardInvites.Find(b => b.InviteId == inviteID), _invite);
                var updatedResult = context.Boards.UpdateOneAsync(filter, update).Result;
                return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
            }

            public bool UpdateMembers(string boardId, string Mid, Member member)
            {
                var filter = Builders<Board>.Filter.Eq(n => n.BId, boardId);
                var update = Builders<Board>.Update.Set(e => e.BoardMembers.Find(n => n.MemberId == Mid), member);
                var updatedResult = context.Boards.UpdateOneAsync(filter, update).Result;
                return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
            }
        }
    }
}
