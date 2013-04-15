using System;
using System.Linq;
using System.Web.Mvc;
using GolfPool.DB;
using GolfPool.Hubs;
using GolfPool.Models;
using Microsoft.AspNet.SignalR;

namespace GolfPool.Controllers
{
    public partial class AdminController : Controller
    {
        private readonly IRepository repository;
        private readonly PlayerAdministration playerAdministration;

        public AdminController(IRepository repository, PlayerAdministration playerAdministration)
        {
            this.repository = repository;
            this.playerAdministration = playerAdministration;
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult ImportPlayers()
        {
            repository.Entities.Database.ExecuteSqlCommand("DELETE FROM Golfers");
            var players = playerAdministration.GetPlayers();
            foreach (var player in players)
            {
                if(!repository.All<Golfer>().Any(x => string.Compare(x.FullName, player.FullName, StringComparison.InvariantCultureIgnoreCase) == 0))
                    repository.Insert(player);
            }
            repository.Save();
            return RedirectToAction(MVC.Home.Players());
        }

        //TODO:make this the post method. and accept a regex.
        public virtual ActionResult ImportWorldRankings()
        {
            var players = repository.All<Golfer>().ToList();
            players = playerAdministration.GetWorldRankings(players).ToList();
            var groups = repository.All<GolferGroup>().ToList();
            foreach (var player in players)
            {
                var group = groups.Single(x => player.Rank >= x.RangeStart && player.Rank <= x.RangeEnd);
                player.GolferGroupID = group.GolferGroupID;
                repository.Update(player);
            }
            repository.Save();
            return RedirectToAction(MVC.Home.Players());
        }

        public virtual ActionResult CreateGroups()
        {
            var players = repository.All<Golfer>().OrderBy(x => x.Rank).ToList();
            var groups = repository.All<GolferGroup>().ToList();

            foreach (var player in players)
            {
                var group =groups.Single(x => player.Rank >= x.RangeStart && player.Rank <= x.RangeEnd);
                player.GolferGroupID = group.GolferGroupID;
                repository.Update(player);
            }
            repository.Save();
            return RedirectToAction(MVC.Home.Players());
        }

        public virtual ActionResult UpdateLeaderboardSource()
        {
            var leaderboardSourceVM = new LeaderboardSourceVM(PlayerAdministration.sourceURL, PlayerAdministration.activeRegex);
            return View(leaderboardSourceVM);
        }

        [HttpPost]
        public virtual ActionResult UpdateLeaderboardSource(LeaderboardSourceVM leaderboardSource)
        {
            PlayerAdministration.activeRegex = leaderboardSource.ScoreRegex;
            PlayerAdministration.sourceURL = leaderboardSource.SourceUrl;
            PlayerAdministration.UpdateScoresFromSource(true);
            return RedirectToAction(MVC.Admin.Index());
        }

        public virtual ActionResult EditPlayer(int id)
        {
            var player = repository.All<Golfer>().Single(x => x.GolferID == id);
            return View(player);
        }

        [HttpPost]
        public virtual ActionResult EditPlayer(Golfer golfer)
        {
            var groups = repository.All<GolferGroup>().ToList();
            var group = groups.Single(x => golfer.Rank >= x.RangeStart && golfer.Rank <= x.RangeEnd);
            golfer.GolferGroupID = group.GolferGroupID;
            repository.Update(golfer);
            repository.Save();

            var context = GlobalHost.ConnectionManager.GetHubContext<LeaderboardHub>();
            context.Clients.All.golferUpdated(golfer);

            return RedirectToAction(MVC.Home.Players());
        }

        public virtual ActionResult EditTeam(int id)
        {
            throw new Exception("Not implemented.");
        }

        public virtual ActionResult UpdateScores(int id)
        {
            PlayerAdministration.UpdateScoresFromSource(true);
            return RedirectToAction(MVC.Admin.Index());
        }
    }

    public class LeaderboardSourceVM
    {
        public string SourceUrl { get; set; }
        public string ScoreRegex { get; set; }

        public LeaderboardSourceVM(string sourceUrl, string scoreRegex)
        {
            SourceUrl = sourceUrl;
            ScoreRegex = scoreRegex;
        }
    }
}
