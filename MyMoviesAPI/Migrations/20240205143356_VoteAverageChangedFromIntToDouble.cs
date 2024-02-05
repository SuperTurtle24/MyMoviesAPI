using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMoviesAPI.Migrations
{
    /// <inheritdoc />
    public partial class VoteAverageChangedFromIntToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "VoteAverage",
                table: "Movies",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VoteAverage",
                table: "Movies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
