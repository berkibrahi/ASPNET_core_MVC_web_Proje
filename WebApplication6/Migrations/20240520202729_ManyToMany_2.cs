using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_genreId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_genreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "genreId",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresgenreId = table.Column<int>(type: "int", nullable: false),
                    MoviesmovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresgenreId, x.MoviesmovieId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_GenresgenreId",
                        column: x => x.GenresgenreId,
                        principalTable: "Genres",
                        principalColumn: "genreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_MoviesmovieId",
                        column: x => x.MoviesmovieId,
                        principalTable: "Movies",
                        principalColumn: "movieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesmovieId",
                table: "GenreMovie",
                column: "MoviesmovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.AddColumn<int>(
                name: "genreId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genreId",
                table: "Movies",
                column: "genreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_genreId",
                table: "Movies",
                column: "genreId",
                principalTable: "Genres",
                principalColumn: "genreId");
        }
    }
}
