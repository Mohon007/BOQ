using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddRimUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "QtyPersheet",
                table: "workOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RimPrice",
                table: "workOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SheetInReem",
                table: "workOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "UPS",
                table: "workOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtyPersheet",
                table: "workOrders");

            migrationBuilder.DropColumn(
                name: "RimPrice",
                table: "workOrders");

            migrationBuilder.DropColumn(
                name: "SheetInReem",
                table: "workOrders");

            migrationBuilder.DropColumn(
                name: "UPS",
                table: "workOrders");
        }
    }
}
