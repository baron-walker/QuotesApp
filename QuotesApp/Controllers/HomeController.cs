using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuotesApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private QuoteListContext context { get; set; }
        public int passThis { get; set; }
        
        // Constructor
        public HomeController(ILogger<HomeController> logger, QuoteListContext quoteListContext)
        {
            passThis = 1;

            _logger = logger;
            context = quoteListContext;
        }

        public IActionResult Index()
        {
            return View(context.Quotes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Added Code ///////////////////////

        [HttpGet]
        public IActionResult AddQuote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddQuote(QuoteItem quoteItem)
        {
            if (ModelState.IsValid)
            {
                // update Database
                context.Quotes.Add(quoteItem);
                context.SaveChanges();

            }
            ViewBag.Result = "added";
            return View("Confirmation");
        }

        // Delete a movie from the database
        [HttpPost]
        public IActionResult DeleteQuote(int quoteID)
        {
            QuoteItem q = context.Quotes.Where(q => q.QuoteID == quoteID).FirstOrDefault();
            if (ModelState.IsValid)
            {
                context.Quotes.Remove(q);
                context.SaveChanges();
            }
            ViewBag.Result = "deleted";
            return View("Confirmation");
        }

        // Update database
        [HttpGet]
        public IActionResult EditQuote(int quoteID)
        {
            QuoteItem q = context.Quotes.Where(q => q.QuoteID == quoteID).FirstOrDefault();
            return View(q);
        }

        [HttpPost]
        public IActionResult EditQuote(QuoteItem q, int quoteID)
        {
            context.Quotes.Where(q => q.QuoteID == quoteID).FirstOrDefault().Quote = q.Quote;
            context.Quotes.Where(q => q.QuoteID == quoteID).FirstOrDefault().QuoteAuthor = q.QuoteAuthor;
            context.Quotes.Where(q => q.QuoteID == quoteID).FirstOrDefault().QuoteDate = q.QuoteDate;
            context.Quotes.Where(q => q.QuoteID == quoteID).FirstOrDefault().QuoteSubject = q.QuoteSubject;
            context.Quotes.Where(q => q.QuoteID == quoteID).FirstOrDefault().QuoteCitation = q.QuoteCitation;
            context.SaveChanges();

            ViewBag.Result = "edited";
            return View("Confirmation");
        }

        public IActionResult RandomQuote()
        {
            
            Random ran = new Random();
            int num = ran.Next(0, context.Quotes.Count());

            if(passThis == 1)
            {
                ViewBag.idnum = num;
            }
            passThis = 2;

            return View(context.Quotes);
        }

    }
}
