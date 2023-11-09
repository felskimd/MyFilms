using Microsoft.AspNetCore.Mvc;
using MyFilms.Services;

namespace MyFilms.Controllers
{
    public class ReleaseController : Controller
    {
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
