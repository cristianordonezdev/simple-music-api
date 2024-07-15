
using music.Models;

namespace music.Repositories
{
    public interface ISong
    {
        Task<List<Song>> GetAll();

        Task<Song>? GetSong(Guid id);

        Task<Song> AddSong(Song song);

        Task<Song?> UpdateSong(Guid id, Song song);

        Task<bool> DeleteSong(Guid id);
    }
}
