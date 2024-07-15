using Microsoft.EntityFrameworkCore;
using music.Models;

namespace music.Data
{
    public class MusicDBContext : DbContext
    {
        public MusicDBContext(DbContextOptions<MusicDBContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().ToTable("Song");
            modelBuilder.Entity<Genre>().ToTable("Genre");
        }
    }
}
