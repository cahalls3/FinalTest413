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
                .OrderBy(x => x.Author)
                .ToList();

            return View(money);
        }

        [HttpGet]
        public IActionResult NewQuote()
        {
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
                return View();
            }
        }

        public IActionResult QuoteDetails(int quoteID)
        {
            var quote = _repo.Quotes.Single(x => x.QuoteID == quoteID);

            return View(quote);
        }

        [HttpGet]
        public IActionResult Edit(int quoteid)
        {
            var quote = _repo.Quotes.Single(x => x.QuoteID == quoteid);

            return View("NewQuote", quote);
        }

        [HttpPost]
        public IActionResult Edit(Quote q)
        {
            _repo.Update(q);

            return RedirectToAction("QuoteDetails");
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

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
