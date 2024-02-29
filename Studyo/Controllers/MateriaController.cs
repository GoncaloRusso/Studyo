using Microsoft.AspNetCore.Mvc;
using Studyo.Data;
using Studyo.Models;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

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
        
        public IActionResult ConteudoEscolhido (int id)
        {
            var chap = _context.Chapters.Where(c => c.Id == id).FirstOrDefault();

            if (chap == null) { return NotFound(); }

            chap.Normal = _context.Materials.Where(m => m.ChapterId == chap.Id).FirstOrDefault();

            Regex.Replace(chap.Normal.Content,@"\\r\\n|\\r|\\n", Environment.NewLine);

            ViewBag.SelectedId = id;

            return View(chap);
        }
    }
}
