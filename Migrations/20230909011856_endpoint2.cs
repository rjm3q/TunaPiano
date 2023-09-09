using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class endpoint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_generesong_songs_songsId",
                table: "generesong");

            migrationBuilder.DropForeignKey(
                name: "FK_songs_artist_artistId",
                table: "songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_songs",
                table: "songs");

            migrationBuilder.RenameTable(
                name: "songs",
                newName: "song");

            migrationBuilder.RenameIndex(
                name: "IX_songs_artistId",
                table: "song",
                newName: "IX_song_artistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_song",
                table: "song",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_generesong_song_songsId",
                table: "generesong",
                column: "songsId",
                principalTable: "song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_song_artist_artistId",
                table: "song",
                column: "artistId",
                principalTable: "artist",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_generesong_song_songsId",
                table: "generesong");

            migrationBuilder.DropForeignKey(
                name: "FK_song_artist_artistId",
                table: "song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_song",
                table: "song");

            migrationBuilder.RenameTable(
                name: "song",
                newName: "songs");

            migrationBuilder.RenameIndex(
                name: "IX_song_artistId",
                table: "songs",
                newName: "IX_songs_artistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_songs",
                table: "songs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_generesong_songs_songsId",
                table: "generesong",
                column: "songsId",
                principalTable: "songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_songs_artist_artistId",
                table: "songs",
                column: "artistId",
                principalTable: "artist",
                principalColumn: "Id");
        }
    }
}
