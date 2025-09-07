using Microsoft.AspNetCore.Mvc;
using MangaReaderR.Data;

namespace MangaReaderR.Controllers
{
    public class HomeController : Controller
    {
        private readonly LocalStorage _storage;

        public HomeController(LocalStorage storage)
        {
            _storage = storage;
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("User");
            ViewBag.User = username;

            // ✅ Explore All Manga
            ViewBag.AllManga = _storage.Mangas;

            // ✅ Most Popular Manga (show all for now)
            ViewBag.PopularManga = _storage.Mangas;

            if (!string.IsNullOrEmpty(username))
            {
                var history = _storage.GetHistoryForUser(username).ToList();
                var mangaLookup = _storage.Mangas.ToDictionary(m => m.Id, m => m);

                // ✅ Reading History
                var displayHistory = history.Select(h => new
                {
                    Title = mangaLookup.ContainsKey(h.MangaId) ? mangaLookup[h.MangaId].Title : $"Unknown (ID: {h.MangaId})",
                    CoverUrl = mangaLookup.ContainsKey(h.MangaId) ? mangaLookup[h.MangaId].CoverUrl : "/images/default.jpg",
                    LastRead = h.LastRead
                });

                ViewBag.History = displayHistory;

                // ✅ Continue Reading (most recent)
                var lastRead = history.OrderByDescending(h => h.LastRead).FirstOrDefault();
                if (lastRead != null && mangaLookup.ContainsKey(lastRead.MangaId))
                {
                    ViewBag.LastReadManga = mangaLookup[lastRead.MangaId];
                }
            }

            return View();
        }
    }
}