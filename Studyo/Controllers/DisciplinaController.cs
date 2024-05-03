using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Studyo.Data;
using Studyo.Models;

namespace Studyo.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly StudyoDbContext _context;
        private readonly UserManager<IdentityUser> _userManger;

        public DisciplinaController(StudyoDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManger = userManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);

            if (user == null) { return NotFound(); }

            var subject = _context.Subjects.Where((subject) => subject.Id == id).FirstOrDefault();

            if (subject == null) { return NotFound(); }

            subject.Chapters = [.. _context.Chapters.Where((chapter) => chapter.SubjectId == id)];

            var userSubject = _context.UserSubjects.Where((userSubject) => userSubject.SubjectId == id && userSubject.UserId == user.Id).FirstOrDefault();

            userSubject ??= EnrollUserToSubject(user.Id, id);

            userSubject.UserChapters =
            [
                .. _context.UserChapters.Where((userChapter) => userChapter.UserId == user.Id && subject.Chapters.Contains(userChapter.Chapter)),
            ];

            return View(userSubject);
        }

        public IActionResult Quiz(int id)
        {
            var quiz = _context.Quizzes.Where(q => q.ChapterId == id).FirstOrDefault();
            if (quiz == null) { return NotFound(); }

            quiz.Chapter = _context.Chapters.Where(c => c.Id == quiz.ChapterId).First();

            quiz.QuizQuestions = _context.QuizQuestions.Where(qq => qq.QuizId == quiz.Id).ToList();
            if (quiz.QuizQuestions.IsNullOrEmpty()) { return NotFound(); }

            foreach (QuizQuestion qq in quiz.QuizQuestions)
            {
                qq.Answers = _context.QuizQuestionAnswers.Where(qqa => qqa.QuizQuestionId == qq.Id).ToList();
                Shuffle(qq.Answers);
            }

            return View(quiz);
        }


        public IActionResult Content(int id)
        {
            var chapter = _context.Chapters.Where(c => c.Id == id).FirstOrDefault();

            if (chapter == null)
            {
                return NotFound();
            }

            return View(chapter);
        }

        public IActionResult AnkiCards() { return View(); }

        public async Task<IActionResult> QuizResult(int chapterId, int score)
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);

            if (user == null) { return NotFound(); }

            var userChapter = _context.UserChapters.Where((userChapter) => userChapter.ChapterId == chapterId && userChapter.UserId == user.Id).FirstOrDefault();

            if (userChapter == null)
            {
                userChapter = new UserChapter
                {
                    UserId = user.Id,
                    ChapterId = chapterId,
                    CurrentScore = score,
                    BestGrade = score
                };

                _context.UserChapters.Add(userChapter);
            }

            else
            {
                userChapter.CurrentScore = score;
                userChapter.BestGrade = (score > userChapter.BestGrade) ? score : userChapter.BestGrade;
            }

            userChapter.Chapter = _context.Chapters.Where((chapter) => chapter.Id == chapterId).FirstOrDefault();
            if (userChapter.Chapter == null) { return NotFound(); }

            _context.SaveChanges();

            return View(userChapter);
        }

        private UserSubject EnrollUserToSubject(string userId, int subjectId)
        {
            UserSubject userSubject = new UserSubject
            {
                UserId = userId,
                SubjectId = subjectId
            };

            _context.UserSubjects.Add(userSubject);
            _context.SaveChanges();

            return userSubject;
        }


        private static void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        //[HttpPost("/Disciplina/GetQuizzesResult")]
        //public async Task<IActionResult> GetQuizzesResult(int subjectId)
        //{
        //    IdentityUser? user = await _userManger.GetUserAsync(User);

        //    if (user == null) { return Json(new { }); }



        //    return Json();
        //}

    }
}
