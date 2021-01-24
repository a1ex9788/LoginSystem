using LoginSystem.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace LoginSystem.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public LoginInformation loginInformation { get; set; }

        [TempData]
        public string UsernameTemp { get; set; }

        private readonly LoginSystemDBContext dbContext;

        public IndexModel(LoginSystemDBContext loginSystemDBContext)
        {
            dbContext = loginSystemDBContext;
        }

        public void OnPost() // Login
        {
            if (!UserExists())
            {
                // Error
                return;
            }

            // OK
        }

        private bool UserExists()
        {
            return dbContext.Users.Any(u => u.Username == loginInformation.Username && u.Password == loginInformation.Password);
        }
    }

    public class LoginInformation
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}