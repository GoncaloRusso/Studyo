using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studyo.Data;

namespace Studyo.Controllers
{
    public class DisciplinasController : Controller
    {
        private readonly StudyoDbContext _context;
        private readonly UserManager<IdentityUser> _userManger;

        public DisciplinasController(StudyoDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManger = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);

            if (user == null) { return NotFound(); }

            var subjects = await _context.Subjects.ToListAsync();

            if (subjects == null || !subjects.Any()) { return NotFound(); }

            var userSubjects = await _context.UserSubjects.Where((userSubjects) => userSubjects.UserId == user.Id).ToListAsync();

            if (userSubjects != null)
            {
                foreach (var subject in userSubjects)
                {
                    if (subject != null)
                    {
                        //TODO
                        subject.UserChapters = await _context.UserChapters.ToListAsync();
                        subject.NumberOfCompletedChapters = 0;

                        foreach (var chapter in subject.UserChapters)
                        {
                            if (chapter.BestGrade >= 75)
                            {
                                subject.NumberOfCompletedChapters++;
                            }
                        }
                    }

                }
            }

            return View(subjects);
        }

        [HttpGet("/Disciplinas/GetEnrolledSubjects")]
        public async Task<IActionResult> GetEnrolledSubjects()
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);

            if (user == null) { return Json(new { }); }

            var enrolledSubjects = await _context.UserSubjects.Where((userSubject) => userSubject.UserId == user.Id).ToListAsync();

            var temp = enrolledSubjects.Select((subject) => new
            {
                // Include mapped properties
                subject.UserId,
                subject.SubjectId,

                // Include not mapped properties
                completedChapters = subject.NumberOfCompletedChapters,
            });

            return Json(temp);
        }


        [Authorize]
        public async Task<IActionResult> AlgoritmoChapterId()
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);
            //List<UserCompletedChapters> currentUserSubjects = _context.UsersSubjects.Where(d => d.UserId == user.Id).ToList();

            //int idChapter;

            //if (currentUserSubjects.Count == 0) { idChapter = -1; }
            //else
            //{
            //    List<Chapter> listChaptersOfSubject = new List<Chapter>();

            //    foreach (KeyValuePair<Chapter, bool> t in currentUserSubjects.OrderBy(s => s.calculateCompletion()).First().CompletedChapters)
            //    {
            //        if (t.Value == false)
            //        {
            //            listChaptersOfSubject.Add(t.Key);
            //        }
            //    }

            //    idChapter = listChaptersOfSubject.OrderBy(c => c.Id).First().Id;
            //}

            //if (idChapter == -1) { return NotFound(); }

            //Chapter chap = _context.Chapters.Where(c => c.Id == idChapter).First();

            return View();
        }
    }
}
