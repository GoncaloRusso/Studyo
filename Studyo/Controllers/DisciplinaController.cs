using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

            // Acesse a base de dados para obter a matéria pelo ID
            var materia = _context.Subjects.Where(c => c.Id == id).FirstOrDefault();
            materia.Chapters = _context.Chapters.Where(c => c.SubjectId == id).ToList();

            /*var dbUser = _context.Users.Where(u => u.Id == user.Id).FirstOrDefault();
            if(dbUser == null)
            {
                return View(_context.Subjects.Where(c => c.Id == 35).FirstOrDefault());
            }

            if (materia == null) { return NotFound(); }
            var discUser = _context.UsersSubjects.Where(d => d.UserId == user.Id && d.SubjetdId == id).FirstOrDefault();

            if (discUser == null)
            {
                UserSubjects du = new UserSubjects();

                du.SubjetdId = id;

                du.UserId = user.Id;

                Dictionary<Chapter, bool> mc = new Dictionary<Chapter, bool>();
                foreach (Chapter c in materia.Chapters)
                {
                    mc.Add(c, false);
                }
                du.CompletedChapters = mc;

                _context.UsersSubjects.Add(du);

            }

            var discUser2 = _context.UsersSubjects.Where(d => d.UserId == user.Id && d.SubjetdId == id).FirstOrDefault();

            if (discUser2 == null) { return NotFound(); }*/

            if (materia == null) { return NotFound(); }

            return View(materia);
        }

        public IActionResult Quizz(int id)
        {
            var quizz = _context.Quizzes.Where(q => q.ChapterId == id).FirstOrDefault();
            if (quizz == null) { return NotFound(); }

            quizz.QuizQuestions = _context.QuizQuestions.Where(qq => qq.QuizId == quizz.Id).ToList();
            if (quizz.QuizQuestions.IsNullOrEmpty()) { return NotFound(); }

            foreach( QuizQuestion qq in quizz.QuizQuestions)
            {
                qq.Answers = _context.QuizQuestionAnswers.Where(qqa => qqa.QuizQuestionId == qq.Id).ToList();
            }

            return View(quizz);
        }

        [HttpPost]
        public IActionResult Content(int id)
        {
            // Acesse a base de dados para obter o capítulo pelo ID
            var chapter = _context.Chapters.Where(c => c.Id == id).FirstOrDefault();

            if (chapter == null) { return NotFound(); }

            return View(chapter);
        }
    }
}
