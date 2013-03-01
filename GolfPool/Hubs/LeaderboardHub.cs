using System.Linq;
using GolfPool.DB;
using GolfPool.Models;
using Microsoft.AspNet.SignalR;

namespace GolfPool.Hubs
{
    public class LeaderboardHub : Hub
    {
        private readonly IRepository repository;

        public LeaderboardHub(IRepository repository)
        {
            this.repository = repository;
        }

        public void GetTeamList()
        {
            var teams = repository.All<Team>().ToArray();
            Clients.Caller.UpdateTeamList(teams);
        }
    }
}