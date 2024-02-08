using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Studyo.Pages
{
    public class SubjectModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly string _name;

        public SubjectModel(string name, ILogger<IndexModel> looger)
        {
            _name = name;
            _logger = looger;
        }

        public string GetName() { return _name; }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Subjects/" + _name);
        }
    }
}
