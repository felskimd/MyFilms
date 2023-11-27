using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyFilms.Models;
using MyFilms.Models.DbModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

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
        public async Task<IActionResult> Login(string? returnUrl)
        {
            var form = HttpContext.Request.Form;

            string username = form["username"];
            string password = form["password"];

            User? user = db.Users.FirstOrDefault(p => (p.Name == username || p.Email == username) && p.PasswordHash == password);
            if (user is null) return Unauthorized();
            
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Name) };
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
            if (db.Users.Any((u) => u.Name == form["name"] || u.Email == form["email"]))
                return BadRequest("Пользователь уже существует");
            var newUser = new User();
            newUser.Name = form["name"];
            newUser.Email = form["email"];
            newUser.PasswordHash = form["password"];
            db.Users.Add(newUser);
            db.SaveChanges();
            return Redirect(returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}