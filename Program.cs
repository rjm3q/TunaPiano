//need to make migrations folder and update database

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

// get all artists

// delete artist

// update artist

// create new artist

// get all generes

// delete genere

// update genere

// create new genere

// get all songs

// delete song

// update song
app.MapPut("/tunapiano/songs/{songId}", (TunaPianoDbContext db, int songId, song song) =>
{
    song songToUpdate = db.song.FirstOrDefault(s => s.Id == songId);
    if (songToUpdate == null)
    {
        return Results.NotFound();
    }
    songToUpdate.title = song.title;
    songToUpdate.artist_Id = song.artist_Id;
    songToUpdate.album = song.album;
    songToUpdate.length = song.length;
    db.Update(songToUpdate);
    return Results.Ok(songToUpdate);
});
// create new song
app.MapPost("/tunapiano/songs", (TunaPianoDbContext db, song song) =>
{
    try
    {
        db.Add(song);
        db.SaveChanges();
        return Results.Created($"/tunapiano/songs/{song.Id}", song);
    }
    catch (DbUpdateException)
    {
        return Results.NotFound();
    }
});
app.Run();