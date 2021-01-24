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

        [BindProperty]
        public string ErrorText { get; set; }

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
            if (AreThereEmptyFields())
            {
                ErrorText = "Can not be empty fields. Please, fill all of them.";
                return null;
            }

            if (UsernameAlreadyInUse())
            {
                ErrorText = $"The username '{registerInformation.Username}' is already in use. Please, select another.";
                return null;
            }

            if (!ArePasswordsEquals())
            {
                ErrorText = "The two introduced passwords are not equal. Please, rewrite them.";
                registerInformation.Password = "";
                registerInformation.RepeatedPassword = "";
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

        private bool AreThereEmptyFields()
        {
            return registerInformation.Name == null || registerInformation.Surnames == null
                || registerInformation.Username == null || registerInformation.Password == null
                || registerInformation.RepeatedPassword == null;
        }

        private bool UsernameAlreadyInUse()
        {
            return dbContext.Users.Any(u => u.Username == registerInformation.Username);
        }

        private bool ArePasswordsEquals()
        {
            return registerInformation.Password.Equals(registerInformation.RepeatedPassword);
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