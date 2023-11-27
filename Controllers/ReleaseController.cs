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
            ViewData["Id"] = id;
            return View();
        }

        [HttpGet]
        public string GetReleaseById(string id)
        {
            var result = KinopoiskAPIService.GetReleaseById(id);
            result.Wait();
            return result.Result;
        }
    }
}
