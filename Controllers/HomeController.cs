using Microsoft.AspNetCore.Mvc;
using Batch_Advisory.Models;
using System.Diagnostics;
using Batch_Advisory.Services;
using Batch_Advisory.Data;
using Microsoft.EntityFrameworkCore;

namespace Batch_Advisory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Batch_AdvisoryContext _context;

        public HomeController(ILogger<HomeController> logger, Batch_AdvisoryContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var availableCourses = _context.AvailableCourses.FromSqlRaw<AvailableCourse>("AvailableCourses").ToList();           
            return View(availableCourses);
        }
        
        public IActionResult ProcessLogin(string Src,string Password)
        {
                
            SecurityService ss = new SecurityService();

            if (!ss.IsValid(Src, Password))
            {
                //ModelState.AddModelError("LoginFailed", "Invalid SRC or Password");
                return View("LoginFail");
            }

            return RedirectToAction("EligibleCourses", "Students", new { @id = Src });
        }

        public IActionResult ProcessAdvisorLogin(int Id, string Password)
        {

            SecurityService ss = new SecurityService();

            if (!ss.IsValidAdvisor(Id, Password))
            {
                //ModelState.AddModelError("LoginFailed", "Invalid SRC or Password");
                return View("LoginFail");
            }

            return RedirectToAction("Dashboard", "Advisors", new { @id = Id });
        }

        public IActionResult AdvisorLogin()
        {
            return View();
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
    }
}