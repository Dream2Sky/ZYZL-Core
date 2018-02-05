using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudLinking.WebApi.Controllers
{
    public class BaseController<T> : Controller
    {
        protected ILogger<T> _logger;
        public BaseController(ILogger<T> logger)
        {
            this._logger = logger;
        }
    }
}
