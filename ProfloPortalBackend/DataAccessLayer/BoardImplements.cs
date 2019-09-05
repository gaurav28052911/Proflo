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
        public class BoardImplementations :IBoardInterface
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

            public void createInvite(int boardId, invitee invite)
            {
                var filter = Builders<Board>.Filter.Eq(c => c.BId, boardId);
                var update = Builders<Board>.Update.Push(c => c.BoardInvites, invite);
                context.Boards.FindOneAndUpdate(filter, update);
            }

            public void createMembers(int boardId, Member member)
            {
                var filter = Builders<Board>.Filter.Eq(c => c.BId, boardId);
                var update = Builders<Board>.Update.Push(c => c.BoardMembers, member);
                context.Boards.FindOneAndUpdate(filter, update);
            }

            public Board GetBoardByID(int boardId)
            {
                Board board = context.Boards.Find(n => n.BId == boardId).First();
                return board;
            }

            public ICollection<invitee> getBoardInvites(int boardId)
            {
                Board board = context.Boards.Find(n => n.BId == boardId).First();
                return board.BoardInvites;
            }

            public ICollection<boardList> getBoardLists(int boardId)
            {
                Board board = context.Boards.Find(n => n.BId == boardId).First();
                return board.Lists;
            }

            public ICollection<Member> getBoardMembers(int boardId)
            {
                Board board = context.Boards.Find(n => n.BId == boardId).First();
                return board.BoardMembers;
            }

            public List<Board> GetBoards()
            {
                return context.Boards.Find(_ => true).ToList();
            }

            public bool RemoveBoard(int boardId)
            {
                var deletedResult = context.Boards.DeleteOne(c => c.BId == boardId);
                return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
            }

            public bool RemoveInvite(int boardId, int inviteID)
            {
                Board GetBoard = context.Boards.Find(n => n.BId == boardId).First();
                invitee _invite = GetBoard.BoardInvites.Find(n => n.inviteID == inviteID);
                var filter = Builders<Board>.Filter.Eq(n => n.BId, boardId);
                var delete = Builders<Board>.Update.Pull(n => n.BoardInvites, _invite);
                var updatedResult = context.Boards.UpdateOneAsync(filter, delete).Result;
                return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
            }

            public bool RemoveMembers(int boardId, int mID)
            {
                Board GetBoard = context.Boards.Find(n => n.BId == boardId).First();
                Member _member = GetBoard.BoardMembers.First(n => n.Mid == mID);
                var filter = Builders<Board>.Filter.Eq(n => n.BId, boardId);
                var delete = Builders<Board>.Update.Pull(n => n.BoardMembers, _member);
                var updatedResult = context.Boards.UpdateOneAsync(filter, delete).Result;
                return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
            }

            public bool UpdateBoard(int boardId, Board board)
            {
                var filter = Builders<Board>.Filter.Where(c => c.BId == boardId);
                var updatedResult = context.Boards.ReplaceOne(filter, board);
                return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
            }

            public bool UpdateInvite(int boardId, int inviteID, invitee invite)
            {
                Board GetBoard = context.Boards.Find(n => n.BId == boardId).First();
                invitee _invite = GetBoard.BoardInvites.Find(n => n.inviteID == inviteID);
                var filter = Builders<Board>.Filter.Eq(n => n.BId, boardId);
                var update = Builders<Board>.Update.Set(n => n.BoardInvites.Find(b => b.inviteID == inviteID), _invite);
                var updatedResult = context.Boards.UpdateOneAsync(filter, update).Result;
                return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
            }

            public bool UpdateMembers(int boardId,int Mid, Member member)
            {
                var filter = Builders<Board>.Filter.Eq(n => n.BId, boardId);
                var update = Builders<Board>.Update.Set(e => e.BoardMembers.Find(n => n.Mid == Mid), member);
                var updatedResult = context.Boards.UpdateOneAsync(filter, update).Result;
                return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
            }
        }
    }
}
