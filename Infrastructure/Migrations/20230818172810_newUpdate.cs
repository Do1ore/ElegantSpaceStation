using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastLocationDateTime",
                table: "RoverLocations",
                newName: "LocationDateTime");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentDirection",
                table: "RoverLocations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocationDateTime",
                table: "RoverLocations",
                newName: "LastLocationDateTime");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentDirection",
                table: "RoverLocations",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
