using Microsoft.AspNetCore.Mvc;
using MangaReaderR.Services;
using MangaReaderR.Models;

namespace MangaReaderR.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        // 🔐 Login (GET)
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel { Username = "", Password = "" });
        }


        // 🔐 Login (POST)
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid && _userService.Validate(model.Username, model.Password))
            {
                if (model.RememberMe)
                {
                    Response.Cookies.Append("User", model.Username, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(7),
                        HttpOnly = true,
                        IsEssential = true
                    });
                }
                else
                {
                    HttpContext.Session.SetString("User", model.Username);
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid credentials");
            return View(model);
        }

        // 🆕 Register (GET)
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel { Username = "", Password = "" });
        }

        // 🆕 Register (POST)
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Register(model.Username, model.Password))
                {
                    HttpContext.Session.SetString("User", model.Username);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Username already exists");
            }

            return View(model);
        }

        // 🚪 Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }
    }
}