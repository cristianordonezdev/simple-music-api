using System.ComponentModel.DataAnnotations;

namespace music.Models.Dtos
{
    public class AddGenre
    {
        [Required]
        public string Name { get; set; }
    }
}
