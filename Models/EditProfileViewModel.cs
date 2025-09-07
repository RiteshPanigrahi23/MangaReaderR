using System.ComponentModel.DataAnnotations;

namespace MangaReaderR.Models
{
    public class EditProfileViewModel
    {
        [Required]
        public string ProfilePictureUrl { get; set; } = string.Empty;

        [Required]
        public string Bio { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}