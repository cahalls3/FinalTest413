using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalTest413.Models;

namespace FinalTest413.Controllers
{
    public class HomeController : Controller
    {
        private IBowlingLeagueRepository _repo { get; set; }

        public HomeController(IBowlingLeagueRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var money = _repo.Bowlers
                .ToList();

            return View(money);
        }

        public IActionResult BowlerList()
        {
            var bowlers = _repo.Bowlers
                .OrderBy(x => x.BowlerID)
                .ToList();

            return View(bowlers);
        }

        [HttpGet]
        public IActionResult NewBowler()
        {
            ViewBag.Teams = _repo.Teams.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult NewBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(b);

                return View("Confirmation", b);
            }
            else // if invalid
            {
                ViewBag.Teams = _repo.Teams.ToList();

                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = _repo.Teams.ToList();

            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("NewBowler", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.Update(b);

            return RedirectToAction("BowlerList");
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _repo.Delete(b);

            return RedirectToAction("BowlerList");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
