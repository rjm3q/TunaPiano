using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class endpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_song",
                table: "song");

            migrationBuilder.RenameTable(
                name: "song",
                newName: "songs");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "artist",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bio",
                table: "artist",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "songs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "album",
                table: "songs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "artistId",
                table: "songs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_songs",
                table: "songs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "generesong",
                columns: table => new
                {
                    genereId = table.Column<int>(type: "integer", nullable: false),
                    songsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generesong", x => new { x.genereId, x.songsId });
                    table.ForeignKey(
                        name: "FK_generesong_genere_genereId",
                        column: x => x.genereId,
                        principalTable: "genere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generesong_songs_songsId",
                        column: x => x.songsId,
                        principalTable: "songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_songs_artistId",
                table: "songs",
                column: "artistId");

            migrationBuilder.CreateIndex(
                name: "IX_generesong_songsId",
                table: "generesong",
                column: "songsId");

            migrationBuilder.AddForeignKey(
                name: "FK_songs_artist_artistId",
                table: "songs",
                column: "artistId",
                principalTable: "artist",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_songs_artist_artistId",
                table: "songs");

            migrationBuilder.DropTable(
                name: "generesong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_songs",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_songs_artistId",
                table: "songs");

            migrationBuilder.DropColumn(
                name: "artistId",
                table: "songs");

            migrationBuilder.RenameTable(
                name: "songs",
                newName: "song");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "artist",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "bio",
                table: "artist",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "song",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "album",
                table: "song",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_song",
                table: "song",
                column: "Id");
        }
    }
}
