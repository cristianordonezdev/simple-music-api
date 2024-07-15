using System.ComponentModel.DataAnnotations;

namespace music.Models.Dtos
{
    public class AddSong
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Artis max 50 characters")]
        public string Artist { get; set; }

        [Required]
        public string Album { get; set; }

        [Required]
        public Guid GenreId { get; set; }
    }
}
