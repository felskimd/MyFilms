using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFilms.Models;
using MyFilms.Services;
using System.Linq;

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
            var convertedId = int.Parse(id);
            var release = KinopoiskAPIService.GetReleaseById(id);
            release.Wait();
            ViewData["Release"] = release.Result;
            var userComment = db.Comments.Where(x => x.AuthorId == db.Users.Where(y => y.UserName == HttpContext.User.Identity.Name).First().Id && x.ReleaseId == int.Parse(id)).ToList();
            var comments = db.Comments.Where(x => x.ReleaseId == convertedId).ToList();
            comments.Except(userComment).OrderBy(x => x.DownVotes - x.UpVotes).ToList();
            ViewData["UserComment"] = userComment.FirstOrDefault();
            ViewData["Comments"] = comments;
            return View();
        }
    }
}