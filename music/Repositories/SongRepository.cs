using music.Models;
using music.Data;
using Microsoft.EntityFrameworkCore;

namespace music.Repositories
{
    public class SongRepository : ISong
    {
        private readonly MusicDBContext _context;

        public SongRepository(MusicDBContext context)
        {
            _context = context;
        }

        public async Task<List<Song>> GetAll()
        {
            return await _context.Songs.Include("Genre").ToListAsync();
        }

        public async Task<Song?> GetSong(Guid id)
        {   
            var song = await _context.Songs.Include("Genre").FirstOrDefaultAsync(i => i.Id == id);
            if (song == null)
            {
                return null;
            }   
            return song;
        }

        public async Task<Song> AddSong(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<Song?> UpdateSong(Guid id, Song song)
        {
            var main_song = await GetSong(id);
            if (main_song != null)
            {
                main_song.Title = song.Title;
                main_song.Artist = song.Artist;
                main_song.GenreId = song.GenreId;
                main_song.Album = song.Album;

                await _context.SaveChangesAsync();
                return main_song;
            } else
            {
                return null;
            }
        }

        public async Task<bool> DeleteSong(Guid id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return false;
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

