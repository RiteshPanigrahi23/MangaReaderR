using MangaReaderR.Data;

namespace MangaReaderR.Services
{
    public class UserService
    {
        private readonly LocalStorage _storage;
        private readonly FileLockProvider _lock;

        public UserService(LocalStorage storage, FileLockProvider lockProvider)
        {
            _storage = storage;
            _lock = lockProvider;
        }

        public bool Validate(string username, string password)
        {
            return _storage.ValidateUser(username, password);
        }

        public bool Register(string username, string password)
        {
            if (_storage.UserExists(username))
                return false;

            _storage.CreateUser(username, password);
            return true;
        }
    }
}