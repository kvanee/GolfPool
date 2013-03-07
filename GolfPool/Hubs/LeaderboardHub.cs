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
            var teams = repository.All<Team>().ToArray().OrderBy(x => x.Overall()).ToArray();
            Clients.Caller.InitTeamList(teams);
        }

        public void GetGolferScores(int id)
        {
            var team = repository.All<Team>(
                x => x.Group1Golfer,
                x => x.Group2Golfer,
                x => x.Group3Golfer,
                x => x.Group4Golfer,
                x => x.Group5Golfer,
                x => x.Group6Golfer,
                x => x.Group7Golfer,
                x => x.Group8Golfer).Single(x => x.TeamID == id);
            Clients.Caller.InitGolfers(team.Golfers);
        }

        public static void UpdateScore(Golfer golfer)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<LeaderboardHub>();
            context.Clients.All.golferUpdated(golfer);
        }
    }
}