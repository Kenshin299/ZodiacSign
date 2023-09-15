using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
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
            return View();
        }

        [HttpPost]
        public IActionResult ZodiacSign(UserZodiacSignModel user)
        {
                user.ZodiacSign = CalculateZodiacSign(user.Day, user.Month);

            return View("ZodiacResult", user);
        }

        private string CalculateZodiacSign(int day, int month )
        {
            switch (month)
            {
                case 3:
                    return (day >= 21) ? "Aries ♈︎" : "Piscis ♓︎";
                case 4:                  
                    return (day <= 19) ? "Aries ♈︎" : "Tauro ♉︎";
                case 5:                 
                    return (day <= 20) ? "Tauro ♉︎" : "Geminis ♊︎";
                case 6:                  
                    return (day <= 20) ? "Geminis ♊︎" : "Cancer ♋︎";
                case 7:                  
                    return (day <= 22) ? "Cancer ♋︎" : "Leo ♌︎";
                case 8:                  
                    return (day <= 22) ? "Leo ♌︎" : "Virgo ♍︎";
                case 9:                  
                    return (day <= 22) ? "Virgo ♍︎" : "Libra ♎︎";
                case 10:                 
                    return (day <= 22) ? "Libra ♎︎" : "Ecorpio ♏︎";
                case 11:                 
                    return (day <= 21) ? "Ecorpio ♏︎" : "Sagitario ♐︎";
                case 12:                 
                    return (day <= 21) ? "Sagitario ♐︎" : "Capricornio ♑︎";
                case 1:                  
                    return (day <= 19) ? "Capricornio ♑︎" : "Acuario ♒︎";
                case 2:                  
                    return (day <= 18) ? "Acuario ♒︎" : "Piscis ♓︎";
                default:
                    return "No se sabe miop 🤷";
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}