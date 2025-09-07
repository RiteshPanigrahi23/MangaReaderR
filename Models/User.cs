namespace MangaReaderR.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = "/images/default-profile.jpg";
        public string Bio { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}