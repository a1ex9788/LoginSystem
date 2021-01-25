using LoginSystem.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<LoginController> logger;
        private readonly LogicManager logicManager;

        public LoginController(LogicManager logicManager, ILogger<LoginController> logger)
        {
            this.logger = logger;
            this.logicManager = logicManager;
        }

        [HttpGet("{username}/{password}")]
        public bool Login(string username, string password)
        {
            logger.LogInformation($"Request received: username={username}, password={password}");

            return logicManager.UserExists(username, password);
        }
    }
}