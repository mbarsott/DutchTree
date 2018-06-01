using System;
using System.Linq;
using DutchTree.Data;
using DutchTree.Services;
using DutchTree.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DutchTree.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;
        private readonly IDutchRepository repository;

        public AppController(IMailService mailService, IDutchRepository repository)
        {
            this.mailService = mailService;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            // throw new InvalidOperationException("Bad Things Happen");
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            //ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                mailService.SendMessage("mbarsott@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}\n" + $"{model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
                // Send the email
            }
            else
            {
                // Show the errors
            }
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            //var results = context.Products
            //    .OrderBy(p => p.Category)
            //    .ToList();

            //var results = from p in repository.Products
            //              orderby p.Category
            //              select p;

            var results = repository.GetAllProducts();

            return View(results);
        }
    }
}
