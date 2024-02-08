using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Studyo.Data;
using Studyo.Models;

namespace Studyo.Pages
{
    public class SubjectsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext? _context;

        public SubjectsModel(ApplicationDbContext context, ILogger<IndexModel> looger)
        {
            _context = context;
            _logger = looger;
        }

        public List<Subject> Subjects { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Perform the selection query to retrieve subjects from the database
            if (_context != null) { Subjects = await _context.Subjects.ToListAsync(); }
            else { Subjects = new List<Subject>(); }

            // You can do further processing here if needed

            // Return the page with the updated model
            return Page();
        }

        public async Task<IActionResult> OnPostSubjectAsync(string subjectName)
        {
            if (string.IsNullOrEmpty(subjectName))
            {
                return NotFound(); // Or handle appropriately if subject name is empty or not found
            }

            // Redirect to the page for the specific subject
            return RedirectToPage("/Subjects", new { subjectName = subjectName });
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Subjects");
        }
    }
}
