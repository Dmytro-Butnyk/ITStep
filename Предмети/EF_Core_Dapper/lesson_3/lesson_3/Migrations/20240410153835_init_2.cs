using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lesson_3.Migrations
{
    /// <inheritdoc />
    public partial class init_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CopiesSold",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayMode",
                table: "Games",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopiesSold",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlayMode",
                table: "Games");
        }
    }
}
