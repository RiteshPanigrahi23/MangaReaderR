using Microsoft.AspNetCore.Mvc;
using MangaReaderR.Data;
using MangaReaderR.Models;

namespace MangaReaderR.Controllers
{
    public class ProfileController : Controller
    {
        private readonly LocalStorage _storage;

        public ProfileController(LocalStorage storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var username = HttpContext.Session.GetString("User") ?? Request.Cookies["User"];
            if (string.IsNullOrEmpty(username)) return RedirectToAction("Login", "Account");

            var user = _storage.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return RedirectToAction("Login", "Account");

            var model = new EditProfileViewModel
            {
                ProfilePictureUrl = user.ProfilePictureUrl,
                Bio = user.Bio,
                Description = user.Description
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditProfileViewModel model)
        {
            var username = HttpContext.Session.GetString("User") ?? Request.Cookies["User"];
            if (string.IsNullOrEmpty(username)) return RedirectToAction("Login", "Account");

            var user = _storage.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                user.ProfilePictureUrl = model.ProfilePictureUrl;
                user.Bio = model.Bio;
                user.Description = model.Description;
                _storage.SaveUsers(); // persist changes
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}