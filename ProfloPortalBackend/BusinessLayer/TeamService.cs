using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfloPortalBackend.DataAccessLayer;
using ProfloPortalBackend.Model;

namespace ProfloPortalBackend.BusinessLayer
{
    public class TeamService : ITeamService
    {
        public readonly ITeamInterface IteamInterface;
        public TeamService(ITeamInterface teamInterface)
        {
            IteamInterface = teamInterface;
        }
        public void createInvite(int teamID, invitee invite)
        {
            throw new NotImplementedException();
        }

        public void createMembers(int teamId, Member member)
        {
            throw new NotImplementedException();
        }

        public void CreateTeam(Team team)
        {
            var result = IteamInterface.GetTeamByID(team.teamID);
            if (result==null)
            {
                if(team.teamBoards==null)
                {
                    team.teamBoards = new List<teamBoard>();
                }
                else if(team.teamMembers==null)
                {
                    team.teamMembers = new List<Member>();
                }
                else if(team.teamInvites==null)
                {
                    team.teamInvites = new List<invitee>();
                }
                IteamInterface.CreateTeam(team);
            }
            else
            {
                //throw new TeamAlraedyExistsException("The Team Already Exists in Database ")
            }
        }

        public ICollection<teamBoard> getTeamBoards(int teamID)
        {
            throw new NotImplementedException();
        }

        public Team GetTeamByID(int teamID)
        {
            throw new NotImplementedException();
        }

        public ICollection<invitee> getTeamInvites(int teamID)
        {
            throw new NotImplementedException();
        }

        public ICollection<Member> getTeamMembers(int teamID)
        {
            throw new NotImplementedException();
        }

        public List<Team> GetTeams()
        {
            throw new NotImplementedException();
        }

        public bool RemoveInvite(int teamId, int inviteID)
        {
            throw new NotImplementedException();
        }

        public bool RemoveMembers(int teamID, int mID)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInvite(int teamId, int inviteID, invitee invite)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMembers(int teamId, int mid, Member member)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTeam(int teamId, Team team)
        {
            throw new NotImplementedException();
        }
    }
}
