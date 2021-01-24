using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LoginSystem.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Username { get; set; }

        public void OnGet()
        {
        }
    }
}