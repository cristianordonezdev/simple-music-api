using music.Models;
namespace music.Repositories
{
    public interface IGenre
    {
        Task<List<Genre>> GetAll();

        Task<Genre?> GetGenre(Guid id);

        Task<Genre> AddGenre(Genre genre);

        Task<Genre?> UpdateGenre(Guid id, Genre genre);

        Task<bool> DeleteGenre(Guid id);
    }
}
