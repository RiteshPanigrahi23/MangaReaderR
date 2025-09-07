using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MangaReaderR.Models;
using MangaReaderR.Services;

namespace MangaReaderR.Data
{
    public class LocalStorage
    {
        private readonly FileLockProvider _lock;
        private readonly List<User> _users = new();
        private readonly List<Manga> _mangas = new();
        private readonly List<ReadingHistory> _history = new();

        private readonly string _userFilePath = "App_Data/users.json";

        public LocalStorage(FileLockProvider lockProvider)
        {
            _lock = lockProvider;
            LoadUsers();

            _mangas.AddRange(new[]
 {
    new Manga { Id = 1, Title = "Cheonhwa Archive's Young Master", CoverUrl = "/images/Cheonhwa-Archive's-Young-Master.jpg", FolderName = "archives", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 2, Title = "Legend of an Asura", CoverUrl = "/images/Legend-of-an-Asura-The-Poison-Dragon.jpg", FolderName = "asura", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 3, Title = "The Beginning After the End", CoverUrl = "/images/the-beginning-after-the-end.jpg", FolderName = "beginning", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 4, Title = "Bleach", CoverUrl = "/images/Bleach.jpg", FolderName = "Bleach", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 5, Title = "Return of the Blossoming Blade", CoverUrl = "/images/return-of-the-Blossoming-Blade.jpg", FolderName = "blossoming blade", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 6, Title = "Chronicles of the Demon Faction", CoverUrl = "/images/chronicles-of-the-demon-faction.jpg", FolderName = "Chronicles", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 7, Title = "Heavenly Demon Reborn", CoverUrl = "/images/Heavenly-Demon-Reborn.jpg", FolderName = "demon", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 8, Title = "Dou Luo Da Lu", CoverUrl = "/images/Dou-Luo-Da-Lu.jpg", FolderName = "dou", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 9, Title = "Log into the Future", CoverUrl = "/images/Log-into-the-Future.jpg", FolderName = "future", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 10, Title = "Gosu", CoverUrl = "/images/Gosu.jpg", FolderName = "Gosu", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 11, Title = "Solo Leveling", CoverUrl = "/images/Solo-Leveling.jpg", FolderName = "leveling", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 12, Title = "Login Murim", CoverUrl = "/images/Login Murim.jpg", FolderName = "murim", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 13, Title = "Nano Machine", CoverUrl = "/images/nano-machine.jpg", FolderName = "nano-chap", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 14, Title = "Noblesse", CoverUrl = "/images/Noblesse.jpg", FolderName = "Noblesse", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 15, Title = "Omniscient Reader's Viewpoint", CoverUrl = "/images/Omniscient-Reader's-Viewpoint.jpg", FolderName = "orv", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 16, Title = "One Piece", CoverUrl = "/images/one-piece.jpg", FolderName = "piece", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 17, Title = "Top-Tier Providence", CoverUrl = "/images/Top-Tier-Providence.jpg", FolderName = "providence", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 18, Title = "The Heavenly Demon Wants a Quiet Life", CoverUrl = "/images/The-Heavenly-Demon-Wants-a-Quiet-Life.jpg", FolderName = "quiet", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 19, Title = "Heavenly Demon Reborn", CoverUrl = "/images/Heavenly-Demon-Reborn.jpg", FolderName = "reborn", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 20, Title = "Rooftop Sword Master", CoverUrl = "/images/Rooftop-Sword-Master.jpg", FolderName = "rooftop", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 21, Title = "Legend of Sayu", CoverUrl = "/images/Legend-of-Sayu.jpg", FolderName = "sayu", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 22, Title = "Absolute Sword Sense", CoverUrl = "/images/absolute-sword-sense.jpg", FolderName = "sense", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 23, Title = "SSS-Class Revival Hunter", CoverUrl = "/images/sss-class-revival-hunter.jpg", FolderName = "Sss", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 24, Title = "Best Teacher Baek", CoverUrl = "/images/best-teacher-baek.jpg", FolderName = "teacher", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 25, Title = "Above ten thousand People", CoverUrl = "/images/above-ten-thousand-people.jpg", FolderName = "thousand", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 26, Title = "Attack on Titan", CoverUrl = "/images/attack-on-titan.jpg", FolderName = "Titan", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 27, Title = "Vagabond", CoverUrl = "/images/Vagabond.jpg", FolderName = "vagabond", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } },
    new Manga { Id = 28, Title = "Volcanic Age", CoverUrl = "/images/Volcanic-Age.jpg", FolderName = "volcanic", ChapterImages = new List<string> { "1.jpg", "2.jpg", "3.jpg", "4.jpg" } }
});
        }

        public IEnumerable<User> Users => _users;
        public IEnumerable<Manga> Mangas => _mangas;

        private void LoadUsers()
        {
            try
            {
                if (File.Exists(_userFilePath))
                {
                    var json = File.ReadAllText(_userFilePath);
                    var loaded = JsonSerializer.Deserialize<List<User>>(json);
                    if (loaded != null)
                    {
                        _users.AddRange(loaded);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading users: {ex.Message}");
            }
        }

        public void SaveUsers()
        {
            try
            {
                var json = JsonSerializer.Serialize(_users);
                Directory.CreateDirectory(Path.GetDirectoryName(_userFilePath)!);
                File.WriteAllText(_userFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving users: {ex.Message}");
            }
        }

        public bool ValidateUser(string username, string password)
        {
            _lock.Enter();
            var valid = _users.Any(u => u.Username == username && u.Password == password);
            _lock.Exit();
            return valid;
        }

        public bool UserExists(string username)
        {
            _lock.Enter();
            var exists = _users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            _lock.Exit();
            return exists;
        }

        public void CreateUser(string username, string password)
        {
            _lock.Enter();
            _users.Add(new User { Username = username, Password = password });
            SaveUsers();
            _lock.Exit();
        }

        public void AddManga(Manga m)
        {
            _lock.Enter();
            _mangas.Add(m);
            _lock.Exit();
        }

        public void AddHistory(ReadingHistory h)
        {
            _lock.Enter();
            _history.Add(h);
            _lock.Exit();
        }

        public IEnumerable<ReadingHistory> GetHistoryForUser(string username)
        {
            _lock.Enter();
            var result = _history.Where(h => h.Username == username).ToList();
            _lock.Exit();
            return result;
        }
    }

    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = "/images/default-profile.jpg";
        public string Bio { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class ReadingHistory
    {
        public string Username { get; set; } = string.Empty;
        public int MangaId { get; set; }
        public DateTime LastRead { get; set; }
    }
}