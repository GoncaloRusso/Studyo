using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Studyo.Pages.Shared
{
    public class ErrorModel : PageModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet()
        {
        }
    }
}
