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
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> logger;
        private readonly LogicManager logicManager;

        public RegisterController(LogicManager logicManager, ILogger<RegisterController> logger)
        {
            this.logger = logger;
            this.logicManager = logicManager;
        }

        [HttpGet("{name}/{surnames}/{username}/{password}")]
        public bool Register(string name, string surnames, string username, string password)
        {
            logger.LogInformation($"Request received: name={name}, surnames={surnames}, username={username}, password={password}");

            return logicManager.RegisterUser(name, surnames, username, password);
        }
    }
}