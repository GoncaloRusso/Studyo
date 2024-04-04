using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Studyo.Data;
using Studyo.Models;
using System.Diagnostics;

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

            // if (user == null) { return NotFound(); }

            // Acesse a base de dados para obter a matéria pelo ID
            var materia = _context.Subjects.Where(c => c.Id == id).FirstOrDefault();
            materia.Chapters = _context.Chapters.Where(c => c.SubjectId == id).ToList();

            if (materia == null) { return NotFound(); }

            var discUser = _context.UsersSubjects.Where(d => d.UserId == user.Id && d.SubjetdId == id).FirstOrDefault();

            if (discUser == null)
            {
                UserCompletedChapters du = new UserCompletedChapters();

                du.SubjetdId = id;

                du.UserId = user.Id;

                Dictionary<Chapter, bool> mc = new Dictionary<Chapter, bool>();

                foreach (Chapter c in materia.Chapters)
                {
                    mc.Add(c, false);
                }
                du.CompletedChapters = mc;

                _context.UsersSubjects.Add(du);
                _context.SaveChanges();
            }

            return View(materia);
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


    }
}
