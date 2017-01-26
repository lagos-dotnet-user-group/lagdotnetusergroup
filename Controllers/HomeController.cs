using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.HomeViewModels;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;

        public HomeController(ApplicationDbContext db, IEmailSender emailSender, ILogger<HomeController> logger)
        {
            _emailSender = emailSender;
            _db = db;
            _logger = logger;

        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        [Route("contact")]
        // [HttpPost("contact")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactViewModel vm)
        {
            // TOD0 implement message service
            if (ModelState.IsValid)
            {
                var _client = Mapper.Map<Contact>(vm);
                try
                {
                    _db.Add(_client);
                   _logger.LogError("Attempting to save contact to database.");
                    await _db.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                   _logger.LogError($"Failed to save contact to database. {ex}");
                }
                var body = $"<p> Message From: {_client.Name} </p> <p> Email: {_client.Email} </p> <p> Subject: {_client.Subject} </p> <p> Message: {_client.Message}</p> <p> Date: {_client.Date}</p> <p> ID: {_client.Id}</p>";

                var emailName = "lagosdotnetusergroup";
                var email = "temilaj@hotmail.com";
                string subject = "New contact on lagosdotnetusergroup.com";
                if(_emailSender.SendEmail(email, emailName, subject, body))
                {
                    ModelState.Clear();
                    _logger.LogInformation("contact Message sent!");
                    ViewBag.Sent = "Message sent, I'll contact you shortly";
                }
                
                return View();
                
            }
            return View("index", vm);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
