using Microsoft.AspNetCore.Mvc;

namespace Studyo.Controllers
{
    public class WorkshopsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
