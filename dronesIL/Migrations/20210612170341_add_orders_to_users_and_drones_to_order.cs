using Microsoft.EntityFrameworkCore.Migrations;

namespace dronesIL.Migrations
{
    public partial class add_orders_to_users_and_drones_to_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Drone",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
