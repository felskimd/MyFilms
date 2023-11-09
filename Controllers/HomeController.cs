using Microsoft.AspNetCore.Mvc;
using MyFilms.Models;
using MyFilms.Services;
using System.Diagnostics;

namespace MyFilms.Controllers
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
            var popular = KinopoiskAPIService.GetPopularReleases();
            var newest = KinopoiskAPIService.GetNewestReleases();
            popular.Wait();
            newest.Wait();
            ViewData["Popular"] = popular.Result;
            ViewData["Newest"] = newest.Result;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}