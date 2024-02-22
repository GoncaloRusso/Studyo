using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AlgoritmoChapterId()
        {
            IdentityUser user = await _userManger.GetUserAsync(User);
            List<DisciplinaUser> currentUserSubjects = _context.DisciplinaUsers.Where(d => d.UserId == user.Id).ToList();

            int idChapter;
            
            if (currentUserSubjects.Count == 0) { idChapter = -1; }
            else
            {
                List<Chapter> listChaptersOfSubject = new List<Chapter>();

                foreach(KeyValuePair<Chapter, bool> t in currentUserSubjects.OrderBy(s => s.percentagemFim()).First().MaterialComp)
                {
                    if(t.Value == false)
                    {
                        listChaptersOfSubject.Add(t.Key);
                    }
                }

                idChapter = listChaptersOfSubject.OrderBy(c => c.Id).First().Id;
            }

            if (idChapter == -1) { return NotFound(); }

            Chapter chap = _context.Chapters.Where(c => c.Id == idChapter).First();

            return View(chap);
        }
    }
}
