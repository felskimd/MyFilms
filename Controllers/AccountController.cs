using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyFilms.Models;
using MyFilms.Models.DbModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace MyFilms.Controllers
{
    public class AccountController : Controller
    {
        ApplicationContext db;

        public AccountController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string? returnUrl)
        {
            var form = HttpContext.Request.Form;

            string username = form["emailLogin"];
            string password = form["password"];

            User? user = db.Users.FirstOrDefault(p => (p.UserName == username || p.Email == username) && p.PasswordHash == password);
            if (user is null) return BadRequest("Пользователь не найден");
            
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return Redirect(returnUrl??"/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string? returnUrl)
        {
            var form = HttpContext.Request.Form;
            if (db.Users.Any((u) => u.UserName == form["name"] || u.Email == form["email"]))
                return BadRequest("Пользователь уже существует");
            var newUser = new User();
            newUser.UserName = form["name"];
            newUser.Email = form["email"];
            newUser.PasswordHash = form["password"];
            db.Users.Add(newUser);
            db.SaveChanges();
            return Redirect(returnUrl??"/");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}