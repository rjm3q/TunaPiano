using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPiano.Migrations
{
    public partial class endpoint3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_generesong_song_songsId",
                table: "generesong");

            migrationBuilder.RenameColumn(
                name: "songsId",
                table: "generesong",
                newName: "songId");

            migrationBuilder.RenameIndex(
                name: "IX_generesong_songsId",
                table: "generesong",
                newName: "IX_generesong_songId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_generesong_song_songId",
                table: "generesong",
                column: "songId",
                principalTable: "song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_generesong_song_songId",
                table: "generesong");

            migrationBuilder.RenameColumn(
                name: "songId",
                table: "generesong",
                newName: "songsId");

            migrationBuilder.RenameIndex(
                name: "IX_generesong_songId",
                table: "generesong",
                newName: "IX_generesong_songsId");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "song",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "album",
                table: "song",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_generesong_song_songsId",
                table: "generesong",
                column: "songsId",
                principalTable: "song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
