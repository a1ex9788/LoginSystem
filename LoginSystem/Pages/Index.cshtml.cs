using LoginSystem.Logic;
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

        private readonly LogicManager logicManager;

        public IndexModel(LogicManager logicManager)
        {
            this.logicManager = logicManager;
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
            return logicManager.UserExists(loginInformation.Username, loginInformation.Password);
        }
    }

    public class LoginInformation
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}