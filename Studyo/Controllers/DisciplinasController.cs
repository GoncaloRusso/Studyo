using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Studyo.Data;
using Studyo.Models;

namespace Studyo.Controllers
{
    [Authorize]
    public class DisciplinasController : Controller
    {
        private readonly StudyoDbContext _context;
        private readonly UserManager<IdentityUser> _userManger;

        public DisciplinasController(StudyoDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManger = userManager;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            // GET THE USER
            IdentityUser? user = await _userManger.GetUserAsync(User);

            if (user == null) { return NotFound(); }

            // GET THE SUBJECTS
            var subjects = await _context.Subjects.ToListAsync();

            if (subjects == null) { return NotFound(); }


            // GET THE USER SUBJECTS
            var userSubjects = await _context.UserSubjects.Where((userSubjects) => userSubjects.UserId == user.Id).ToListAsync();


            if (userSubjects != null)
            {
                // FOR EACH USER SUBJECT AND IF THE SUBJECT IS NOT NULL WE CALCULATE THE NUMBER OF COMPLETED CHAPTERS
                foreach (var userSubject in userSubjects)
                {
                    if (userSubject != null)
                    {
                        userSubject.UserChapters = await _context.UserChapters.Where((userChapter) => userChapter.UserId == user.Id &&
                            userChapter.Chapter.SubjectId == userSubject.SubjectId).ToListAsync();

                        userSubject.NumberOfCompletedChapters = 0;

                        foreach (var userChapter in userSubject.UserChapters)
                        {
                            if (userChapter.BestGrade >= 75)
                            {
                                userSubject.NumberOfCompletedChapters++;
                            }
                        }
                    }
                }
            }

            if (searchString.IsNullOrEmpty())
            {
                return View(subjects);
            }

            else
            {
                return View(subjects.Where((subjects) => subjects.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList());
            }



        }

        [HttpGet("/Disciplinas/GetSubjects")]
        public async Task<IActionResult> GetSubjects()
        {
            var subjects = await _context.Subjects.ToListAsync();

            return Json(subjects);
        }


        [HttpGet("/Disciplinas/GetEnrolledSubjects")]
        public async Task<IActionResult> GetEnrolledSubjects()
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);

            if (user == null) { return Json(new { }); }

            var enrolledSubjects = await _context.UserSubjects.Where((userSubject) => userSubject.UserId == user.Id).ToListAsync();

            foreach (var userSubject in enrolledSubjects)
            {
                userSubject.UserChapters = await _context.UserChapters.Where((userChapter) => userChapter.UserId == user.Id && userChapter.Chapter.SubjectId == userSubject.SubjectId).ToListAsync();
            }

            var temp = enrolledSubjects.Select((subject) => new
            {
                // Include mapped properties
                subject.UserId,
                subject.SubjectId,

                // Include not mapped properties
                completedChapters = subject.UserChapters.Where((userChapter) => userChapter.BestGrade >= 75).ToList().Count,
            });

            return Json(temp);
        }

        public async Task<IActionResult> AdvisedStudy()
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);

            if (user == null) { return NotFound(); }

            var userSubjects = await _context.UserSubjects.Where((userSubject) => userSubject.UserId == user.Id).ToListAsync();

            if (userSubjects.IsNullOrEmpty())
            {
                // Display a warning message
                TempData["WarningMessage"] = "The user is not enrolled to any subject";
                return RedirectToAction("Index", "Disciplinas");
            }

            List<object> arr2 = new List<object>();

            foreach (var userSubject in userSubjects)
            {
                userSubject.Subject = _context.Subjects.Where((subject) => subject.Id == userSubject.SubjectId).FirstOrDefault();

                if (userSubject.Subject == null) { continue; }

                userSubject.UserChapters = await _context.UserChapters.Where((userChapter) => userChapter.UserId == user.Id && userChapter.Chapter.SubjectId == userSubject.SubjectId).ToListAsync();

                userSubject.Completion = (float)userSubject.UserChapters.Where((userChapter) => userChapter.BestGrade >= 75).Count() / userSubject.Subject.NumberOfChapters;
            }

            var LessCompleted = userSubjects.OrderBy((userSubject) => userSubject.Completion).First();

            LessCompleted.Subject.Chapters = _context.Chapters.Where((chapter) => chapter.SubjectId == LessCompleted.SubjectId).ToList();

            UserChapter worseResult = new UserChapter { BestGrade = 10000 };

            foreach (var chapter in LessCompleted.Subject.Chapters)
            {
                var tmp = _context.UserChapters.Where((userChapter) => userChapter.UserId == user.Id && userChapter.ChapterId == chapter.Id).FirstOrDefault();

                if (tmp != null)
                {
                    worseResult = (tmp.BestGrade < worseResult.BestGrade) ? tmp : worseResult;
                }

                else
                {
                    worseResult = new UserChapter { ChapterId = chapter.Id };
                    break;
                }
            }

            return RedirectToAction("Content", "Disciplina", new { id = worseResult.ChapterId });
        }
    }
}
