using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginSystem.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoginSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class RegisterController : ControllerBase
    {
        private readonly LogicManager logicManager;

        public RegisterController(LogicManager logicManager)
        {
            this.logicManager = logicManager;
        }

        [HttpGet]
        public bool Register(string name, string surnames, string username, string password)
        {
            return logicManager.RegisterUser(name, surnames, username, password);
        }
    }
}