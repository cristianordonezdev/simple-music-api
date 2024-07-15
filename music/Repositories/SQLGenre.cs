using Microsoft.EntityFrameworkCore;
using music.Data;
using music.Models;

namespace music.Repositories
{
    public class SQLGenre : IGenre
    {
        private readonly MusicDBContext _context;
        public SQLGenre(MusicDBContext context)
        {
            this._context = context;
        }
        public async Task<Genre> AddGenre(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<bool> DeleteGenre(Guid id)
        {
            var genre = await GetGenre(id);
            if  (genre == null)
            {
                return false;
            }
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Genre>> GetAll()
        {
            var genres = await _context.Genres.ToListAsync();
            return genres;
        }

        public async Task<Genre?> GetGenre(Guid id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return null;
            }
            return genre;
        }

        public async Task<Genre?> UpdateGenre(Guid id, Genre genre)
        {
            var genreDomain = await GetGenre(id);
            if (genre == null) {
                return null;
            } else
            genreDomain.Name = genre.Name;
            await _context.SaveChangesAsync();
            return genreDomain;
        }
    }
}
