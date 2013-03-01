﻿using System;
using System.Linq;
using System.Web.Mvc;
using GolfPool.DB;
using GolfPool.Models;

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

            foreach (var player in players)
            {
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
            return RedirectToAction(MVC.Home.Players());
        }

        public virtual ActionResult EditTeam(int id)
        {
            throw new Exception("Not implemented.");
        }
    }
}
