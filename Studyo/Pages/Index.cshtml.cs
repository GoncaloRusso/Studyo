using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Studyo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> looger)
        {
            _logger = looger;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/");
        }
    }
}
