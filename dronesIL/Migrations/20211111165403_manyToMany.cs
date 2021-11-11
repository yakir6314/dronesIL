using Microsoft.EntityFrameworkCore.Migrations;

namespace dronesIL.Migrations
{
    public partial class manyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dronesOrders",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false),
                    droneId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dronesOrders", x => new { x.droneId, x.orderId });
                    table.ForeignKey(
                        name: "FK_dronesOrders_Drone_droneId",
                        column: x => x.droneId,
                        principalTable: "Drone",
                        principalColumn: "droneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dronesOrders_Order_orderId",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dronesOrders_orderId",
                table: "dronesOrders",
                column: "orderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dronesOrders");
        }
    }
}
