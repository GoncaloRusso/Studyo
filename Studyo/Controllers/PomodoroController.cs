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

        [HttpPost]
        public IActionResult UpdateStudyTime(int studyTime)
        {
            pomodoro.StudyTime = studyTime;
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult UpdateRestTime(int restTime)
        {
            pomodoro.RestTime = restTime;
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult UpdateCycles(byte cycles)
        {
            pomodoro.Cycles = cycles;
            return Json(new { success = true });
        }
    }
}
