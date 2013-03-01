using System.Linq;
using System.Web.Mvc;
using GolfPool.DB;
using GolfPool.Hubs;
using GolfPool.Models;
using Microsoft.AspNet.SignalR;

namespace GolfPool.Controllers
{
    public partial class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public virtual ActionResult Standings()
        {
            var teams = repository.All<Team>();
            return View(teams);
        }

        public virtual ActionResult SimulateUpdate()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<LeaderboardHub>();
            var team = repository.All<Team>().First();
            team.TeamName = "UPDATE!!";
            context.Clients.All.teamUpdated(team);
            return RedirectToAction(MVC.Home.Standings());
        }

        public virtual ActionResult Players()
        {
            var players = repository
                .All<Player>(x => x.PlayerGroup).OrderBy(x => x.Rank)
                .ToList()
                .GroupBy(x => x.PlayerGroup.Name);
            return View(players);
        }
    }
}
