using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFilms.Models;
using System.Diagnostics;

namespace MyFilms.Controllers
{
    public class MyPageController : Controller
    {
        public ActionResult Index()
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
