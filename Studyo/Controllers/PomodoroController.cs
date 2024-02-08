using Microsoft.AspNetCore.Mvc;
using Studyo.Models;

namespace Studyo.Controllers
{
    public class PomodoroController : Controller
    {
        private Pomodoro pomodoro;

        public PomodoroController()
        {
            pomodoro = new Pomodoro();
            pomodoro.StudyTime = 0;
            pomodoro.RestTime = 0;
            pomodoro.Cycles = 0;
        }

        public IActionResult Index()
        {
            return View(pomodoro);
        }


    }
}
