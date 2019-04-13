using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCore30WebApplication.Models;
using ASPNETCore30WebApplication.Demos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ASPNETCore30WebApplication.Infrastructure;

namespace ASPNETCore30WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRing ring;
        private readonly IOnce match;

        public HomeController(IRing ring, IOnce match)
        {
            this.ring = ring;
            this.match = match;
        }

        public IActionResult Index([FromServices] IOnce otherMatch)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
