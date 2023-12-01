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
            int password = form["password"].GetHashCode();

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
        public async Task<IActionResult> Register(string? returnUrl)
        {
            //Добавить проверку email
            var form = HttpContext.Request.Form;
            var newUser = new User();
            newUser.UserName = form["login"];
            newUser.Email = form["email"];
            newUser.PasswordHash = form["password"].GetHashCode();
            if (db.Users.Any((u) => u.UserName == newUser.UserName || u.Email == newUser.Email))
                return BadRequest("Пользователь уже существует");
            db.Users.Add(newUser);
            db.SaveChanges();
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, newUser.UserName) };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return Redirect(returnUrl??"/");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}