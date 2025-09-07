using System.Threading;

namespace MangaReaderR.Services
{
    public class FileLockProvider
    {
        private readonly SemaphoreSlim _lock = new(1, 1);
        public void Enter() => _lock.Wait();
        public void Exit() => _lock.Release();
    }
}