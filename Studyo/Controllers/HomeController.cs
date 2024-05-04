using Microsoft.AspNetCore.Mvc;
using Studyo.Models;
using System.Diagnostics;

namespace Studyo.Controllers
{
    /// <summary>
    /// Class responsable for managing the requests towards the Home Page of the site.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Calls the View for the Home Page of the site
        /// </summary>
        /// <returns>Returns said Page</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Work in Progress!
        /// </summary>
        /// <returns>View for Workshop Page</returns>
        public IActionResult Workshops()
        {
            return View();
        }

        /// <summary>
        /// Function in case of error
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
