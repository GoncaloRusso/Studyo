using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studyo.Data;
using Studyo.Models;
using System.Security.Claims;

namespace Studyo.Controllers
{
    public class DisciplinaController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManger;

        public DisciplinaController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManger = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<int> AlgoritmoChapterId()
        {
            IdentityUser user = await _userManger.GetUserAsync(User);
            List<DisciplinaUser> currentUserSubjects = _context.DisciplinaUsers.Where(d => d.UserId == user.Id).ToList();

            if (currentUserSubjects.Count == 0)
            {
                return -1;
            }
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

                return listChaptersOfSubject.OrderBy(c => c.Id).First().Id;
            }
        }


    }
}
