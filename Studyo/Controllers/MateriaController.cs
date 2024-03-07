using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                        var discUser = _context.DisciplinaUsers.Where(d => d.UserId == user.Id && d.DisciplinaId == id).FirstOrDefault();

                        if (discUser == null)
                        {
                            DisciplinaUser du = new DisciplinaUser();

                            du.DisciplinaId = id;

                            du.UserId = user.Id;

                            Dictionary<Chapter, bool> mc = new Dictionary<Chapter, bool>();
                            foreach (Chapter c in materia.Chapters)
                            {
                                mc.Add(c, false);
                            }
                            du.MaterialComp = mc;

                            _context.DisciplinaUsers.Add(du);

                        }*/



            return View(materia);
        }
        public IActionResult QuizSelecionado()
        {
            return View();
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
