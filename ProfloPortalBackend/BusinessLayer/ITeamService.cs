using ProfloPortalBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.BusinessLayer
{
     public interface ITeamService
    {
        List<Team> GetTeams();
        bool UpdateTeam(int teamId, Team team);
        Team GetTeamByID(int teamID);
        void CreateTeam(Team team);
        bool RemoveTeam(int teamId);
        void createMembers(int teamId, Member member);
        bool UpdateMembers(int teamId, int mid, Member member);
        bool RemoveMembers(int teamID, int mID);
        void createInvite(int teamID, invitee invite);
        bool UpdateInvite(int teamId, int inviteID, invitee invite);
        ICollection<invitee> getTeamInvites(int teamID);
        ICollection<Member> getTeamMembers(int teamID);
        bool RemoveInvite(int teamId, int inviteID);


        ICollection<teamBoard> getTeamBoards(int teamID);
    }
}
