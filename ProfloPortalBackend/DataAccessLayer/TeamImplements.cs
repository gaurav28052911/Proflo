using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfloPortalBackend.Model;
using MongoDB.Driver;

namespace ProfloPortalBackend.DataAccessLayer
{
    public class TeamImplements : ITeamInterface
    {
        private readonly DBContext context;
        public TeamImplements(DBContext dBContext)
        {
            context = dBContext;
        }

        public void createInvite(int teamID,invitee invite)
        {
            var filter = Builders<Team>.Filter.Eq(c => c.teamID, teamID);
            var update = Builders<Team>.Update.Push(c => c.teamInvites, invite);
            context.Teams.FindOneAndUpdate(filter, update);
        }

        public void createMembers(int teamID,Member member)
        {
            var filter = Builders<Team>.Filter.Eq(c => c.teamID, teamID);
            var update = Builders<Team>.Update.Push(c => c.teamMembers,member );
            context.Teams.FindOneAndUpdate(filter, update);
        }

        public void CreateTeam(Team team)
        {
            context.Teams.InsertOne(team);
        }

        public void CreateTeamBoard(int teamID, Board board)
        {
            teamBoard teamBoard = new teamBoard();
            teamBoard.BId = board.BId;
            teamBoard.BoardName = board.BoardName;
            teamBoard.Description = board.Description;
            var filter = Builders<Team>.Filter.Eq(c => c.teamID, teamID);
            var update = Builders<Team>.Update.Push(c => c.teamBoards, teamBoard);
            context.Teams.FindOneAndUpdate(filter, update);
        }

        public ICollection<teamBoard> getTeamBoards(int teamID)
        {
            //teamBoard teamBoard = context.Teams.Find(n => n.teamID == teamID).First();
            Team team = context.Teams.Find(n => n.teamID == teamID).First();
            return team.teamBoards;
        }

        

        public Team GetTeamByID(int teamID)
        {
            Team team = context.Teams.Find(n => n.teamID == teamID).First();
            return team;
        }

       

        public ICollection<invitee> getTeamInvites(int teamID)
        {
            Team team = context.Teams.Find(n => n.teamID == teamID).First();
            return team.teamInvites;
        }


        public ICollection<Member> getTeamMembers(int teamID)
        {
            Team team = context.Teams.Find(n => n.teamID == teamID).First();
            return team.teamMembers;
        }

        public List<Team> GetTeams()
        {
            return context.Teams.Find(_ => true).ToList();
        }

        public bool RemoveInvite(int teamId,int inviteID)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamId).First();
            invitee _invite = GetTeam.teamInvites.Find(n => n.inviteID == inviteID);
            var filter = Builders<Team>.Filter.Eq(n => n.teamID, teamId);
            var delete = Builders<Team>.Update.Pull(n => n.teamInvites, _invite);
            var updatedResult = context.Teams.UpdateOneAsync(filter, delete).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool RemoveMembers(int teamID,int mID)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamID).First();
            Member _member = GetTeam.teamMembers.First(n => n.Mid== mID);
            var filter = Builders<Team>.Filter.Eq(n => n.teamID, teamID);
            var delete = Builders<Team>.Update.Pull(n => n.teamMembers, _member);
            var updatedResult=context.Teams.UpdateOneAsync(filter, delete).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool RemoveTeam(int teamID)
        {
            var deletedResult = context.Teams.DeleteOne(c => c.teamID == teamID);
            return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
        }

        public bool UpdateInvite(int teamId,int inviteID, invitee invite)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamId).First();
            invitee _invite = GetTeam.teamInvites.Find(n => n.inviteID == inviteID);
            var filter = Builders<Team>.Filter.Eq(n => n.teamID, teamId);
            var update = Builders<Team>.Update.Set(n => n.teamInvites.Find(b=>b.inviteID==inviteID),_invite);
            var updatedResult = context.Teams.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool UpdateMembers(int teamId,int mid, Member member)
        {
            //Team GetTeam = context.Teams.Find(n => n.teamID == teamId).First();
            //Member _member = GetTeam.teamMembers.First(n => n.Mid ==mid );
            //var filter = Builders<Team>.Filter.Eq(n => n.teamID, teamId);
            //var delete = Builders<Team>.Update.Pull(n => n.teamMembers, _member);
            //context.Teams.FindOneAndUpdate(filter, delete);
            var filter = Builders<Team>.Filter.Eq(n => n.teamID, teamId);
            var update = Builders<Team>.Update.Set(e => e.teamMembers.Find(n => n.Mid == mid), member);
            var updatedResult = context.Teams.UpdateOneAsync(filter, update).Result;
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        

        public bool UpdateTeam(int teamId, Team team)
        {
            var filter = Builders<Team>.Filter.Where(c => c.teamID == teamId);
            var updatedResult = context.Teams.ReplaceOne(filter, team);
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        
    }
}
