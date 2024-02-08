using Microsoft.AspNetCore.Mvc;
using MyFilms.Models;
using MyFilms.Services;

namespace MyFilms.Controllers
{
    public class SearchController : Controller
    {
        ApplicationContext db;

        public SearchController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var form = HttpContext.Request.Form;
            var searchString = form["searchString"];
            var result = KinopoiskAPIService.Search(searchString);
            result.Wait();
            ViewData["Result"] = result.Result;
            //ViewData["Authenticated"] = HttpContext.User.Identity.IsAuthenticated;
            return View();
        }
    }
}
