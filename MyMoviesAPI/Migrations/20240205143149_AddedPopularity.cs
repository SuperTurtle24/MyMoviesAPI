using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMoviesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedPopularity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Popularity",
                table: "Movies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Movies");
        }
    }
}
