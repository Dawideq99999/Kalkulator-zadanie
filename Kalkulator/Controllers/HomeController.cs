using Kalkulator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kalkulator.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Mateusz";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien dobry" : "Dobry wieczor";

            Dane[] osoby =
            {
                new Dane {Name = "Anna", Surname = "Kowalski"},
                new Dane {Name = "Jan", Surname = "Nowak"},
                new Dane {Name = "Maria", Surname = "Tytus"}
            };

            return View(osoby);
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie}, masz {DateTime.Now.Year - urodziny.Rok} lat";
            return View();
        }

        public IActionResult Calculator(Calculator kalkulator)
        {
            
            if(kalkulator.SecondNumber == 0 && kalkulator.Mark == '/')
            {
                ViewBag.wynik = "Nie mozna dzielic przez 0";
                return View();
            }
            else if (kalkulator.Mark == '+')
            {
                kalkulator.Result = kalkulator.FirstNumber + kalkulator.SecondNumber;
            }
            else if (kalkulator.Mark == '-')
            {
                kalkulator.Result = kalkulator.FirstNumber - kalkulator.SecondNumber;
            }
            else if (kalkulator.Mark == '*')
            {
                kalkulator.Result = kalkulator.FirstNumber * kalkulator.SecondNumber;
            }
            else if (kalkulator.Mark == '/')
            {
                kalkulator.Result = kalkulator.FirstNumber / kalkulator.SecondNumber;
            }
            else
            {
                ViewBag.wynik = "Brakuje jednej z liczb lub znaku dzialania";
                return View();
            }

            ViewBag.wynik = $"Wynik z dzialania {kalkulator.FirstNumber} {kalkulator.Mark} {kalkulator.SecondNumber} = {kalkulator.Result}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}