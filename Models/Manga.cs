namespace MangaReaderR.Models
{
    public class Manga
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string CoverUrl { get; set; } = string.Empty;

        // Folder name inside wwwroot/manga/ (e.g. "asura", "archives")
        public string FolderName { get; set; } = string.Empty;

        // List of image filenames for chapter pages (e.g. ["1.jpg", "2.jpg", "3.jpg", "4.jpg"])
        public List<string> ChapterImages { get; set; } = new();
    }
}