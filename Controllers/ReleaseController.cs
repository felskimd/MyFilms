using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFilms.Models;
using MyFilms.Services;

namespace MyFilms.Controllers
{
    public class ReleaseController : Controller
    {
        ApplicationContext db;

        public ReleaseController(ApplicationContext db) 
        { 
            this.db = db;
        }

        [Authorize]
        public IActionResult Index(string id)
        {
            var release = KinopoiskAPIService.GetReleaseById(id);
            release.Wait();
            ViewData["Release"] = release.Result;
            return View();
        }
    }
}