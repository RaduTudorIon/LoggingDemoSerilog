using LoggingDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 62)
                    {
                        throw new Exception("This our demo exception");
                    }
                    else
                    {
                        _logger.LogInformation("The value of i is {LoopCountVariable}", i);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has occured. We caught this exception thankfully!");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("You accessed the Privacy page!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
