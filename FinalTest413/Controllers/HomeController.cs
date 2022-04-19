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
        private IQuoteRepository _repo { get; set; }

        public HomeController(IQuoteRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var money = _repo.Quotes
                .ToList();

            return View(money);
        }

        public IActionResult QuoteList()
        {
            var quotes = _repo.Quotes
                .OrderBy(x => x.Author)
                .ToList();

            return View(quotes);
        }

        [HttpGet]
        public IActionResult NewQuote()
        {
            //ViewBag.Teams = _repo.Teams.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult NewQuote(Quote q)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(q);

                return View("Confirmation", q);
            }
            else // if invalid
            {
                //ViewBag.Teams = _repo.Teams.ToList();

                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int quoteid)
        {
            //ViewBag.Teams = _repo.Teams.ToList();

            var quote = _repo.Quotes.Single(x => x.QuoteID == quoteid);

            return View("NewQuote", quote);
        }

        [HttpPost]
        public IActionResult Edit(Quote q)
        {
            _repo.Update(q);

            return RedirectToAction("QuoteList");
        }

        [HttpGet]
        public IActionResult Delete(int quoteid)
        {
            var quote = _repo.Quotes.Single(x => x.QuoteID == quoteid);

            return View(quote);
        }

        [HttpPost]
        public IActionResult Delete(Quote q)
        {
            _repo.Delete(q);

            return RedirectToAction("QuoteList");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
