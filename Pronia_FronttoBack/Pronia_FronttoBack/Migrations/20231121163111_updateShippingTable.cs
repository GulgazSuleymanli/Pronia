using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pronia_FronttoBack.Migrations
{
    /// <inheritdoc />
    public partial class updateShippingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Shippers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Shippers");
        }
    }
}
