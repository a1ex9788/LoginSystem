using LoginSystem.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace LoginSystem.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public LoginInformation loginInformation { get; set; }

        [BindProperty]
        public string errorText { get; set; }

        [BindProperty]
        public string correctLoginText { get; set; }

        [TempData]
        public string usernameTemp { get; set; }

        private readonly LoginSystemDBContext dbContext;

        public IndexModel(LoginSystemDBContext loginSystemDBContext)
        {
            dbContext = loginSystemDBContext;
        }

        public void OnPost() // Login
        {
            if (!UserExists())
            {
                errorText = "The user or the password is incorrect.";
                return;
            }

            correctLoginText = "The login was completed successfully!";
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