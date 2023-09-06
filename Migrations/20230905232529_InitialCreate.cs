using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    age = table.Column<int>(type: "integer", nullable: false),
                    bio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    artist_Id = table.Column<int>(type: "integer", nullable: false),
                    album = table.Column<string>(type: "text", nullable: true),
                    length = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "song_genere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    song_Id = table.Column<int>(type: "integer", nullable: false),
                    genere_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song_genere", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "artist",
                columns: new[] { "Id", "age", "bio", "name" },
                values: new object[] { 1, 24, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", "Carol Quackenbush" });

            migrationBuilder.InsertData(
                table: "genere",
                columns: new[] { "Id", "description" },
                values: new object[] { 1, "Rockabilly" });

            migrationBuilder.InsertData(
                table: "song",
                columns: new[] { "Id", "album", "artist_Id", "length", "title" },
                values: new object[] { 1, "The South shall rock again!", 1, 201, "Jesus hold my beer" });

            migrationBuilder.InsertData(
                table: "song_genere",
                columns: new[] { "Id", "genere_Id", "song_Id" },
                values: new object[] { 1, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "artist");

            migrationBuilder.DropTable(
                name: "genere");

            migrationBuilder.DropTable(
                name: "song");

            migrationBuilder.DropTable(
                name: "song_genere");
        }
    }
}
