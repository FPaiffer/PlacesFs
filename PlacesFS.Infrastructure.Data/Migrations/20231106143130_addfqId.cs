using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlacesFS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addfqId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fsq_id",
                table: "FavoritePlace",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fsq_id",
                table: "FavoritePlace");
        }
    }
}
