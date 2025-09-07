using Microsoft.AspNetCore.Mvc;
using MangaReaderR.Services;
using MangaReaderR.Models;
using MangaReaderR.Data;


namespace MangaReaderR.Controllers
{
    public class MangaController : Controller
    {
        private readonly MangaService _mangaService;
        private readonly LocalStorage _storage;

        public MangaController(MangaService mangaService, LocalStorage storage)
        {
            _mangaService = mangaService;
            _storage = storage;
        }

        // 📚 Show all manga
        public IActionResult Index()
        {
            var mangas = _mangaService.GetAll();
            return View(mangas);
        }

        // 📖 Read a specific manga
        public IActionResult Read(int id)
        {
            var manga = _mangaService.GetAll().FirstOrDefault(m => m.Id == id);
            if (manga == null || string.IsNullOrEmpty(manga.FolderName))
                return NotFound();

            // 🧠 Track reading history
            var username = HttpContext.Session.GetString("User") ?? Request.Cookies["User"];
            if (!string.IsNullOrEmpty(username))
            {
                _storage.AddHistory(new ReadingHistory
                {
                    Username = username,
                    MangaId = manga.Id,
                    LastRead = DateTime.Now
                });
            }

            // 📂 Load chapter images from wwwroot/manga/{FolderName}
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "manga", manga.FolderName);
            if (Directory.Exists(folderPath))
            {
                var imageFiles = Directory.GetFiles(folderPath, "*.jpg")
                                          .Select(Path.GetFileName)
                                          .OrderBy(name => name)
                                          .ToList();

                ViewBag.Pages = imageFiles;
            }
            else
            {
                ViewBag.Pages = new List<string>();
            }

            return View(manga);
        }
    }
}