using LoginSystem.Models;
using LoginSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginSystem.Logic
{
    public class LogicManager
    {
        private readonly LoginSystemDBContext dbContext;

        public LogicManager(LoginSystemDBContext loginSystemDBContext)
        {
            dbContext = loginSystemDBContext;
        }

        public bool UserExists(string username, string password)
        {
            return dbContext.Users.Any(u => u.Username == username && u.Password == password);
        }

        public bool RegisterUser(string name, string surnames, string username, string password)
        {
            if (UsernameAlreadyInUse(username))
            {
                return false;
            }

            User user = new User()
            {
                Name = name,
                Surnames = surnames,
                Username = username,
                Password = password
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return true;
        }

        private bool UsernameAlreadyInUse(string username)
        {
            return dbContext.Users.Any(u => u.Username == username);
        }
    }
}