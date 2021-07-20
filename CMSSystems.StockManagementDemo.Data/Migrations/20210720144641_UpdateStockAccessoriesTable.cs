using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSSystems.StockManagementDemo.Data.Migrations
{
    public partial class UpdateStockAccessoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockAccessories_Vehicles_VehicleId",
                table: "StockAccessories");

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleId",
                table: "StockAccessories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_StockAccessories_Vehicles_VehicleId",
                table: "StockAccessories",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockAccessories_Vehicles_VehicleId",
                table: "StockAccessories");

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleId",
                table: "StockAccessories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockAccessories_Vehicles_VehicleId",
                table: "StockAccessories",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
