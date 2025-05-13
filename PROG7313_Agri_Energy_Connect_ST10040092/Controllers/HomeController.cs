using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PROG7313_Agri_Energy_Connect_ST10040092.Models;

namespace PROG7313_Agri_Energy_Connect_ST10040092.Controllers
{
    public class HomeController : Controller
    {
        // Injected logger for diagnostics or custom logging
        private readonly ILogger<HomeController> _logger;
        // Constructor to inject the ILogger service
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // GET: Home page
        public IActionResult Index()
        {
            // Renders the default Index view (e.g., welcome message or dashboard)
            return View();
        }
        // GET: Privacy policy page
        public IActionResult Privacy()
        {
            // Renders the static Privacy view
            return View();
        }
        // GET: Error page (automatically used by ASP.NET Core error handling)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Returns a view populated with error details
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
