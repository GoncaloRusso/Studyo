using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Studyo.Data;
using Studyo.Models;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Studyo.Controllers
{
    public class MateriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MateriaSelecionada(int id)
        {
            // Acesse a base de dados para obter a matéria pelo ID
            var materia = _context.Subjects.Include(m => m.Chapters).FirstOrDefault(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        [HttpPost]
        public IActionResult AdicionarTodasAsMateriasEChapters()
        {
            // Lista de nomes das matérias
            var nomesDasMaterias = new List<string>
    {
        "Antropologia",
        "Aplicações Matemáticas B",
        "Biologia",
        "Ciência Política",
        "Clássicos da Literatura",
        "Desenho A",
        "Direito",
        "Economia A",
        "Economia C",
        "Filosofia A",
        "Filosofia B",
        "Física",
        "Geografia A",
        "Geografia C",
        "Geometria Descritiva A",
        "Grego",
        "História A",
        "História B",
        "História da Cultura e das Artes",
        "Língua Estrangeira I",
        "Língua Estrangeira II",
        "Língua Estrangeira III",
        "Latim A",
        "Latim B",
        "Literatura Portugesa",
        "Literatura de Língua Portuguesa",
        "Materiais e Tecnologias",
        "Matemática A",
        "Matemática Aplicada Às Ciências Sociais",
        "Oficina de Artes",
        "Oficina de Multimédia B",
        "Português",
        "Psicologia B",
        "Química",
        "Sociologia"
        // Adicione mais nomes conforme necessário
    };
            foreach (var nomeDaMateria in nomesDasMaterias)
            {
                // Crie uma nova instância da matéria
                var materia = new Subject
                {
                    Name = nomeDaMateria,
                    Chapters = new List<Chapter>()
                };

                // Crie um novo capítulo
                var chapter = new Chapter
                {
                    Name = "Capitulo 1",
                    // Preencha as outras propriedades do capítulo conforme necessário
                };

                // Adicione o capítulo à lista de capítulos da matéria
                materia.Chapters.Add(chapter);

                // Adicione a matéria ao DbSet
                _context.Subjects.Add(materia);
            }

            // Salve as alterações no contexto
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
