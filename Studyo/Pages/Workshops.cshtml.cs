using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Studyo.Pages
{
    public class WorkshopsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public WorkshopsModel(ILogger<IndexModel> looger)
        {
            _logger = looger;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Workshops");
        }
    }
}
