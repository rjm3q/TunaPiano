using TunaPiano.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using TunaPiano;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<TunaPianoDbContext>(builder.Configuration["TunaPianoDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

                                   // SONGS

// Create a Song
app.MapPost("/api/songs", async (TunaPianoDbContext db, Song song) =>
{
    db.Songs.Add(song);
    await db.SaveChangesAsync();
    return Results.Created($"/api/songs/{song.SongId}", song);
});

// Delete a Song
app.MapDelete("/api/songs/{id}", async (TunaPianoDbContext db, int id) =>
{
    var song = await db.Songs.FindAsync(id);
    if (song == null)
    {
        return Results.NotFound();
    }

    db.Songs.Remove(song);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Update a Song
app.MapPut("/api/songs/{id}", async (TunaPianoDbContext db, int id, Song song) =>
{
    if (id != song.SongId)
    {
        return Results.BadRequest();
    }

    db.Entry(song).State = EntityState.Modified;

    try
    {
        await db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!db.Songs.Any(s => s.SongId == id))
        {
            return Results.NotFound();
        }
        else
        {
            throw;
        }
    }

    return Results.NoContent();
});

// View a List of all Songs
app.MapGet("/api/songs", (TunaPianoDbContext db) =>
{
    var songs = db.Songs.ToList();
    return Results.Ok(songs);
});

                                   // ARTIST

// Create an Artist
app.MapPost("/api/artists", async (TunaPianoDbContext db, Artist artist) =>
{
    db.Artists.Add(artist);
    await db.SaveChangesAsync();
    return Results.Created($"/api/artists/{artist.ArtistId}", artist);
});

// Delete an Artist
app.MapDelete("/api/artists/{id}", async (TunaPianoDbContext db, int id) =>
{
    var artist = await db.Artists.FindAsync(id);
    if (artist == null)
    {
        return Results.NotFound();
    }

    db.Artists.Remove(artist);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Update an Artist
app.MapPut("/api/artists/{id}", async (TunaPianoDbContext db, int id, Artist artist) =>
{
    if (id != artist.ArtistId)
    {
        return Results.BadRequest();
    }

    db.Entry(artist).State = EntityState.Modified;

    try
    {
        await db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!db.Artists.Any(a => a.ArtistId == id))
        {
            return Results.NotFound();
        }
        else
        {
            throw;
        }
    }

    return Results.NoContent();
});

// View List of all Artist
app.MapGet("/api/artists", (TunaPianoDbContext db) =>
{
    var artists = db.Artists.ToList();
    return Results.Ok(artists);
});

// Details view of a single Artist and the associated songs
app.MapGet("/api/artists/{id}", (TunaPianoDbContext db, int id) =>
{
    var artist = db.Artists
        .Include(a => a.Songs)
        .SingleOrDefault(a => a.ArtistId == id);

    if (artist == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(artist);
});


                                    // GENRE
// Create a Genre
app.MapPost("/api/genres", async (TunaPianoDbContext db, Genre genre) =>
{
    db.Genres.Add(genre);
    await db.SaveChangesAsync();
    return Results.Created($"/api/genres/{genre.GenreId}", genre);
});

// Delete a Genre
app.MapDelete("/api/genres/{id}", async (TunaPianoDbContext db, int id) =>
{
    var genre = await db.Genres.FindAsync(id);
    if (genre == null)
    {
        return Results.NotFound();
    }

    db.Genres.Remove(genre);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Update a Genre
app.MapPut("/api/genres/{id}", async (TunaPianoDbContext db, int id, Genre genre) =>
{
    if (id != genre.GenreId)
    {
        return Results.BadRequest();
    }

    db.Entry(genre).State = EntityState.Modified;

    try
    {
        await db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!db.Genres.Any(g => g.GenreId == id))
        {
            return Results.NotFound();
        }
        else
        {
            throw;
        }
    }

    return Results.NoContent();
});

// View a List of all Genres
app.MapGet("/api/genres", (TunaPianoDbContext db) =>
{
    var genres = db.Genres.ToList();
    return Results.Ok(genres);
});


                                // Relationship Class

// Details view of a single Genre and the songs associated with it
app.MapGet("/api/genres/{id}", (TunaPianoDbContext db, int id) =>
{
    var genre = db.Genres
        .Include(g => g.Songs)
        .SingleOrDefault(g => g.GenreId == id);

    if (genre == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(genre);
});


// Details view of a single Song and its associated genres and artist details
app.MapGet("api/songs/{id}", async (TunaPianoDbContext db, int id) =>
{
    var song = await db.Songs
    .Include(s => s.Genres)
    .Include(s => s.Artist)
        .FirstOrDefaultAsync(s => s.SongId == id);

    return Results.Ok(song);
});

app.Run();