using Microsoft.EntityFrameworkCore.Migrations;

namespace dronesIL.Migrations
{
    public partial class changDroneIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Drone",
                table: "Drone");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Drone");

            migrationBuilder.AddColumn<int>(
                name: "droneId",
                table: "Drone",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drone",
                table: "Drone",
                column: "droneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Drone",
                table: "Drone");

            migrationBuilder.DropColumn(
                name: "droneId",
                table: "Drone");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Drone",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drone",
                table: "Drone",
                column: "id");
        }
    }
}
