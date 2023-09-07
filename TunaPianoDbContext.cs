using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;

namespace TunaPiano
{
    public class TunaPianoDbContext : DbContext
    {
        public DbSet<artist>? artist { get; set; }
        public DbSet<genere>? genere { get; set; }
        public DbSet<song>? songs { get; set; }
        public DbSet<song_genere>? song_genere { get; set; }


        public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<artist>().HasData(new artist[]
            {
            new artist { Id = 1, name = "Carol Quackenbush", age = 24, bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum" }
            });

            modelBuilder.Entity<genere>().HasData(new genere[]
            {
            new genere { Id = 1, description = "Rockabilly" }
            });

            modelBuilder.Entity<song>().HasData(new song[]
            {
            new song { Id = 1, title = "Jesus hold my beer", artist_Id = 1, album = "The South shall rock again!", length = 201 }
            });

            modelBuilder.Entity<song_genere>().HasData(new song_genere[]
            {
            new song_genere { Id = 1, song_Id = 1, genere_Id = 1 }
            });
        }
    }
}