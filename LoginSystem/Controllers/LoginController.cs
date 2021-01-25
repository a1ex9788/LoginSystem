using LoginSystem.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LogicManager logicManager;

        public LoginController(LogicManager logicManager)
        {
            this.logicManager = logicManager;
        }

        [HttpGet]
        public bool Login(string username, string password)
        {
            return logicManager.UserExists(username, password);
        }
    }
}