
namespace music.Models
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }

        public Guid GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
