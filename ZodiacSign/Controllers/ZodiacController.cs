﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZodiacSign.Models;

namespace ZodiacSign.Controllers
{
    public class ZodiacController : Controller
    {
        private readonly ILogger<ZodiacController> _logger;

        public ZodiacController(ILogger<ZodiacController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Acces to index :)");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}