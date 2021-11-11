using Microsoft.EntityFrameworkCore.Migrations;

namespace dronesIL.Migrations
{
    public partial class addonetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_userId",
                table: "Order",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_user_userId",
                table: "Order",
                column: "userId",
                principalTable: "user",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_user_userId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_userId",
                table: "Order");
        }
    }
}
