using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;

namespace TunaPiano
{
    public class TunaPianoDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Song_Genre> Song_Genres { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                   .HasMany(g => g.Genres)
                   .WithMany(s => s.Songs)
                   .UsingEntity(sg => sg.ToTable("SongGenre"));

            // Seed data for artists
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, ArtistName = "Hideki Naganuma", Age = 51, Bio = "Japanese Funk Doctor" },
                new Artist { ArtistId = 2, ArtistName = "Daft Punk", Age = 30, Bio = "French Robots" },
                new Artist { ArtistId = 3, ArtistName = "Static-X", Age = 30, Bio = "Wayne took a Wisconsin Death Trip" }
            );

            // Seed data for songs
            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, SongName = "Humming the Bassline (D.S.Remix)", ArtistId = 1, AlbumName = "Jet Set Radio Future O.S.T.", Length = "4:18" },
                new Song { SongId = 2, SongName = "One More Time", ArtistId = 2, AlbumName = "Discovery", Length = "5:20" },
                new Song { SongId = 3, SongName = "Stay Alive", ArtistId = 3, AlbumName = "Project Restoration Vol. 2", Length = "3:55" }
            );

            // Seed data for genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Description = "J-POP" },
                new Genre { GenreId = 2, Description = "Rock" },
                new Genre { GenreId = 3, Description = "Metal" }
            );

            // Seed data for song-genre associations
            modelBuilder.Entity<Song_Genre>().HasData(
                new Song_Genre { Song_GenreId = 1, SongId = 1, GenreId = 1 },
                new Song_Genre { Song_GenreId = 2, SongId = 2, GenreId = 1 },
                new Song_Genre { Song_GenreId = 3, SongId = 3, GenreId = 2 }
            );
        }


    }