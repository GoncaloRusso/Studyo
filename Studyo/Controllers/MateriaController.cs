using Microsoft.AspNetCore.Mvc;
using Studyo.Data;
using Studyo.Models;

namespace Studyo.Controllers
{
    public class MateriaController : Controller
    {
        private readonly StudyoDbContext _context;

        public MateriaController(StudyoDbContext context)
        {
            _context = context;
        }

        public IActionResult MateriaSelecionada(int id)
        {
            // Acesse a base de dados para obter a matéria pelo ID
            var materia = _context.Subjects.Where(c => c.Id == id).FirstOrDefault();
            materia.Chapters = _context.Chapters.Where(c => c.SubjectId == id).ToList();

            if (materia == null) { return NotFound(); }

            return View(materia);
        }

    }
}
