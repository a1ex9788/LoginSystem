using LoginSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginSystem.Persistence
{
    public class LoginSystemDBContext
    {
        public LoginSystemDBContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public void SaveChanges()
        {
        }
    }
}