using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudLinking.WebApi.Controllers
{
    [Route("api/test/[controller]/[action]")]
    public class Auth2Controller : BaseController<Auth2Controller>
    {
        public Auth2Controller(ILogger<Auth2Controller> logger) : base(logger)
        {
            
        }

        [HttpGet]
        public IActionResult Test() {
            _logger.LogInformation("test core");
            return Ok();
        }
    }
}
