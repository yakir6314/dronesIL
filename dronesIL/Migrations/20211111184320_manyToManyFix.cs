using Microsoft.EntityFrameworkCore.Migrations;

namespace dronesIL.Migrations
{
    public partial class manyToManyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drone_Order_orderId",
                table: "Drone");

            migrationBuilder.DropIndex(
                name: "IX_Drone_orderId",
                table: "Drone");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Drone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Drone",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drone_orderId",
                table: "Drone",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drone_Order_orderId",
                table: "Drone",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
