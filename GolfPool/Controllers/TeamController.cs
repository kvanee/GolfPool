﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GolfPool.DB;
using GolfPool.Helpers;
using GolfPool.Hubs;
using GolfPool.Models;

namespace GolfPool.Controllers
{
    public partial class TeamController : Controller
    {
        private readonly IRepository repository;

        public TeamController(IRepository repository)
        {
            this.repository = repository;
        }

        public virtual ActionResult Index()
        {
            var teamVM = new TeamVM();
            GetVMData(teamVM);

            return View(teamVM);
        }

        private void GetVMData(TeamVM teamVM)
        {
            var players = repository.All<Golfer>().ToList();
            teamVM.Group1PlayerOptions = players
                .Where(x => x.GolferGroupID == GolferGroup.Group1ID)
                .CreateSelectList(x => x.GolferID, x => x.FullName);

            teamVM.Group2PlayerOptions = players
                .Where(x => x.GolferGroupID == GolferGroup.Group2ID)
                .CreateSelectList(x => x.GolferID, x => x.FullName);

            teamVM.Group3PlayerOptions = players
                .Where(x => x.GolferGroupID == GolferGroup.Group3ID)
                .CreateSelectList(x => x.GolferID, x => x.FullName);

            teamVM.Group4PlayerOptions = players
                .Where(x => x.GolferGroupID == GolferGroup.Group4ID)
                .CreateSelectList(x => x.GolferID, x => x.FullName);

            teamVM.Group5PlayerOptions = players
                .Where(x => x.GolferGroupID == GolferGroup.Group5ID)
                .CreateSelectList(x => x.GolferID, x => x.FullName);

            teamVM.Group6PlayerOptions = players
                .Where(x => x.GolferGroupID == GolferGroup.Group6ID)
                .CreateSelectList(x => x.GolferID, x => x.FullName);
            teamVM.Group7PlayerOptions = players
                .Where(x => x.GolferGroupID == GolferGroup.Group7ID)
                .CreateSelectList(x => x.GolferID, x => x.FullName);
            teamVM.Group8PlayerOptions = players
                .Where(x => x.GolferGroupID == GolferGroup.Group8ID)
                .CreateSelectList(x => x.GolferID, x => x.FullName);
            teamVM.Group9PlayerOptions = players
                .Where(x => x.GolferGroupID == GolferGroup.Group9ID)
                .CreateSelectList(x => x.GolferID, x => x.FullName);
            teamVM.Group10PlayerOptions = players
                .Where(x => x.GolferGroupID == GolferGroup.Group10ID)
                .CreateSelectList(x => x.GolferID, x => x.FullName);
        }

        [HttpPost]
        public virtual ActionResult Index(TeamVM team)
        {
            if(repository.All<Team>().Any(x => x.TeamName == team.TeamName))
                ModelState.AddModelError("TeamName", "This team name is taken.");
            if (ModelState.IsValid)
            {
                repository.Insert((Team)team);
                repository.Save();
                LeaderboardHub.UpdateTeamList();
                return RedirectToAction(MVC.Home.Standings());
            }

            GetVMData(team);
            return View(team);
        }
    }

    public class TeamVM : Team
    {
        public IEnumerable<SelectListItem> Group1PlayerOptions { get; set; }

        public IEnumerable<SelectListItem> Group2PlayerOptions { get; set; }

        public IEnumerable<SelectListItem> Group3PlayerOptions { get; set; }

        public IEnumerable<SelectListItem> Group4PlayerOptions { get; set; }

        public IEnumerable<SelectListItem> Group5PlayerOptions { get; set; }

        public IEnumerable<SelectListItem> Group6PlayerOptions { get; set; }

        public IEnumerable<SelectListItem> Group7PlayerOptions { get; set; }

        public IEnumerable<SelectListItem> Group8PlayerOptions { get; set; }

        public IEnumerable<SelectListItem> Group9PlayerOptions { get; set; }

        public IEnumerable<SelectListItem> Group10PlayerOptions { get; set; }
    }
}
