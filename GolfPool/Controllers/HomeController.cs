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

        public virtual ActionResult Index()
        {
            var teams = repository.All<Team>();
            return View(teams);
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
