using Microsoft.AspNetCore.Mvc;
using Studyo.Models;

namespace Studyo.Controllers
{
    /// <summary>
    /// Class responsable for managing the requests towards the Pomodoro tool, with functions to load the page and set parameters
    /// 
    /// </summary>
    public class PomodoroController : Controller
    {
        private Pomodoro pomodoro;

        /// <summary>
        /// Constructor. Initializes and sets default values for a Pomodoro object.
        /// </summary>
        public PomodoroController()
        {
            pomodoro = new Pomodoro();
            pomodoro.StudyTime = 0;
            pomodoro.RestTime = 0;
            pomodoro.Cycles = 0;
        }

        /// <summary>
        /// Index function. Calls the View to load Pomodoro Page, providing it with said object.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(pomodoro);
        }

        /// <summary>
        /// Post Request function to set studyTime
        /// </summary>
        /// <param name="studyTime"> new time in minutes</param>
        /// <returns> return JSONResult response as successful action</returns>
        [HttpPost]
        public IActionResult UpdateStudyTime(int studyTime)
        {
            pomodoro.StudyTime = studyTime;
            return Json(new { success = true });
        }

        /// <summary>
        /// Post Request function to set restTime
        /// </summary>
        /// <param name="restTime">new time in minutes</param>
        /// <returns>return JSONResult response as successful action</returns>
        [HttpPost]
        public IActionResult UpdateRestTime(int restTime)
        {
            pomodoro.RestTime = restTime;
            return Json(new { success = true });
        }

        /// <summary>
        /// Post Request function to set number of cycles
        /// </summary>
        /// <param name="cycles">new cycle number</param>
        /// <returns>return JSONResult response as successful action</returns>
        [HttpPost]
        public IActionResult UpdateCycles(byte cycles)
        {
            pomodoro.Cycles = cycles;
            return Json(new { success = true });
        }
    }
}
