using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pronia_FronttoBack.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "BasketDbItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketDbItems_OrderId",
                table: "BasketDbItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketDbItems_Orders_OrderId",
                table: "BasketDbItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketDbItems_Orders_OrderId",
                table: "BasketDbItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketDbItems_OrderId",
                table: "BasketDbItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "BasketDbItems");
        }
    }
}
