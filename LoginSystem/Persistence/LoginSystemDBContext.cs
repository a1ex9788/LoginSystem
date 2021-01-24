using LoginSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginSystem.Persistence
{
    public class LoginSystemDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public LoginSystemDBContext(DbContextOptions<LoginSystemDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=BibliographicalSourcesIntegratorWarehouseDB.db");
        }
    }
}