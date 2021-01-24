using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginSystem.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public LoginInformation loginInformation { get; set; }

        [TempData]
        public string Username { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }

        public IActionResult OnPostRegister()
        {
            Username = loginInformation.Username;
            return RedirectToPage("Index");
        }
    }

    public class LoginInformation
    {
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
    }
}