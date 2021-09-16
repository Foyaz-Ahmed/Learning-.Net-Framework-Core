using Microsoft.EntityFrameworkCore.Migrations;

namespace JurseyBazar.Migrations
{
    public partial class AddPriceQuantityInJursey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Jursey",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Jursey",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Jursey");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Jursey");
        }
    }
}
