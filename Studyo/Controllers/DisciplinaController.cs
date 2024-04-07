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
        /*
        public async Task<IActionResult> Index(int id)
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);

            // Acesse a base de dados para obter a matéria pelo ID
            var materia = _context.Subjects.Where(c => c.Id == id).FirstOrDefault();

            if (materia == null) { return NotFound(); }

            materia.Chapters = _context.Chapters.Where(c => c.SubjectId == id).ToList();

            return View(materia);
        }

    */

        public async Task<IActionResult> Index(int id, string searchString)
        {
            IdentityUser? user = await _userManger.GetUserAsync(User);

            var materia = _context.Subjects.Where(c => c.Id == id).FirstOrDefault();
            if (materia == null) { return NotFound(); }

            materia.Chapters = _context.Chapters.Where(c => c.SubjectId == id).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                materia.Chapters = materia.Chapters.Where(c => c.Name.Contains(searchString)).ToList();
            }

            ViewBag.CurrentFilter = searchString;

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

        public IActionResult Content(int id)
        {
            // Acesse a base de dados para obter o capítulo pelo ID
            var chapter = _context.Chapters.Where(c => c.Id == id).FirstOrDefault();

            if (chapter == null) {
                return NotFound(); }

            return View(chapter);
        }
    }
}
