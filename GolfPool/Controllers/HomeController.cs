using System;
using System.Linq;
using System.Web.Mvc;
using GolfPool.DB;
using GolfPool.Models;

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

            // Stop Caching in IE
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

            // Stop Caching in Firefox
            Response.Cache.SetNoStore();
            var teams = repository.All<Team>();
            return View(teams);
        }

        public virtual ActionResult Players()
        {
            var players = repository
                .All<Golfer>(x => x.GolferGroup).OrderBy(x => x.Rank)
                .ToList()
                .GroupBy(x => x.GolferGroup.Name);
            return View(players);
        }

        public virtual JsonResult TeamGolfers(int id)
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
            return Json(team.Golfers, JsonRequestBehavior.AllowGet);
        }
    }
}
