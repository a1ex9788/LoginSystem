using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginSystem.Models;
using LoginSystem.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginSystem.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterInformation registerInformation { get; set; }

        [TempData]
        public string UsernameTemp { get; set; }

        private readonly LoginSystemDBContext dbContext;

        public RegisterModel(LoginSystemDBContext loginSystemDBContext)
        {
            dbContext = loginSystemDBContext;
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }

        public IActionResult OnPostRegister()
        {
            if (UsernameAlreadyInUse())
            {
                // Error
                return null;
            }

            User user = new User()
            {
                Name = registerInformation.Name,
                Surnames = registerInformation.Surnames,
                Username = registerInformation.Username,
                Password = registerInformation.Password
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            UsernameTemp = user.Username;
            return RedirectToPage("Index");
        }

        private bool UsernameAlreadyInUse()
        {
            return dbContext.Users.Any(u => u.Username == registerInformation.Username);
        }
    }

    public class RegisterInformation
    {
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
    }
}