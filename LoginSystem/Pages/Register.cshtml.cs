using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginSystem.Logic;
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
        public string errorText { get; set; }

        [TempData]
        public string usernameTemp { get; set; }

        private readonly LogicManager logicManager;

        public RegisterModel(LogicManager logicManager)
        {
            this.logicManager = logicManager;
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Index");
        }

        public IActionResult OnPostRegister()
        {
            if (AreThereEmptyFields())
            {
                errorText = "Can not be empty fields. Please, fill all of them.";
                return null;
            }

            if (!ArePasswordsEquals())
            {
                errorText = "The two introduced passwords are not equal. Please, rewrite them.";
                return null;
            }

            bool wasRegistered = logicManager.RegisterUser(registerInformation.Name, registerInformation.Surnames, registerInformation.Username, registerInformation.Password);

            if (!wasRegistered)
            {
                errorText = $"The username '{registerInformation.Username}' is already in use. Please, select another.";
                return null;
            }

            usernameTemp = registerInformation.Username;
            return RedirectToPage("Index");
        }

        private bool AreThereEmptyFields()
        {
            return registerInformation.Name == null || registerInformation.Surnames == null
                || registerInformation.Username == null || registerInformation.Password == null
                || registerInformation.RepeatedPassword == null;
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