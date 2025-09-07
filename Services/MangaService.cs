using System.Collections.Generic;
using MangaReaderR.Data;
using MangaReaderR.Models;

namespace MangaReaderR.Services
{
    public class MangaService
    {
        private readonly LocalStorage _storage;
        private readonly FileLockProvider _lock;

        public MangaService(LocalStorage storage, FileLockProvider lockProvider)
        {
            _storage = storage;
            _lock = lockProvider;
        }

        public IEnumerable<Manga> GetAll() => _storage.Mangas;

        public void Add(Manga m)
        {
            _lock.Enter();
            _storage.AddManga(m);
            _lock.Exit();
        }
    }
}