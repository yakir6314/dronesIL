using Microsoft.EntityFrameworkCore.Migrations;

namespace dronesIL.Migrations
{
    public partial class initadddronesprops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Drone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Drone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Drone");

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Drone");
        }
    }
}
