using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Studyo.Data;
using Studyo.Models;

namespace Studyo.Controllers
{
    public class MateriaController : Controller
    {
        private readonly StudyoDbContext _context;
        private readonly UserManager<IdentityUser> _userManger;

        public MateriaController(StudyoDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManger = userManager;
        }

        public async Task<IActionResult> MateriaSelecionada(int id)
        {
            IdentityUser user = await _userManger.GetUserAsync(User);

            // Acesse a base de dados para obter a matéria pelo ID
            var materia = _context.Subjects.Where(c => c.Id == id).FirstOrDefault();
            materia.Chapters = _context.Chapters.Where(c => c.SubjectId == id).ToList();

            if (materia == null) { return NotFound(); }
            /*
                        var discUser = _context.UserSubjectss.Where(d => d.UserId == user.Id && d.DisciplinaId == id).FirstOrDefault();

                        if (discUser == null)
                        {
                            UserSubjects du = new UserSubjects();

                            du.DisciplinaId = id;

                            du.UserId = user.Id;

                            Dictionary<Chapter, bool> mc = new Dictionary<Chapter, bool>();
                            foreach (Chapter c in materia.Chapters)
                            {
                                mc.Add(c, false);
                            }
                            du.MaterialComp = mc;

                            _context.UserSubjectss.Add(du);

                        }*/



            return View(materia);
        }

        public IActionResult QuizSelecionado(int id)
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
        public IActionResult ConteudoEscolhido(int id)
        {
            // Acesse a base de dados para obter o capítulo pelo ID
            var chapter = _context.Chapters.Where(c => c.Id == id).FirstOrDefault();

            if (chapter == null) { return NotFound(); }

            return View(chapter);
        }

    }
}
