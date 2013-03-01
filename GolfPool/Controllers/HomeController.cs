﻿using System;
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
            context.Clients.All.golferUpdated(new { GolferID = 36, Score = 20 });
            return Json(true);
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
            var random = new Random(DateTime.Now.Millisecond);

            foreach (var golfer in team.Golfers)
            {
                golfer.Score = random.Next(-10, 10);
            }
            return Json(team.Golfers, JsonRequestBehavior.AllowGet);
        }
    }
}
