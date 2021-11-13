using Microsoft.EntityFrameworkCore.Migrations;

namespace dronesIL.Migrations
{
    public partial class DroneEnt_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isEnterprise",
                table: "Drone",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isEnterprise",
                table: "Drone");
        }
    }
}
