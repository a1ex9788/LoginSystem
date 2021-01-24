using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginSystem.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}