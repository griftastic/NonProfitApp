using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NonProfitApp.WebAPI.Controllers
{
    [Route("[controller]")]
    public class NPEntityControllers : Controller
    {
        private readonly ILogger<NPEntityControllers> _logger;

        public NPEntityControllers(ILogger<NPEntityControllers> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}