using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlacesFS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeComaByPipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipsSeparatedByComma",
                table: "FavoritePlace",
                newName: "TipsSeparatedByPipes");

            migrationBuilder.RenameColumn(
                name: "ImagesSeparatedByComma",
                table: "FavoritePlace",
                newName: "ImagesSeparatedByPipes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipsSeparatedByPipes",
                table: "FavoritePlace",
                newName: "TipsSeparatedByComma");

            migrationBuilder.RenameColumn(
                name: "ImagesSeparatedByPipes",
                table: "FavoritePlace",
                newName: "ImagesSeparatedByComma");
        }
    }
}
