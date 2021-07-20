using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSSystems.StockManagementDemo.Data.Migrations
{
    public partial class AddVehicleAccessoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleAccessories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockAccessoryId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleAccessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleAccessories_StockAccessories_StockAccessoryId",
                        column: x => x.StockAccessoryId,
                        principalTable: "StockAccessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleAccessories_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAccessories_StockAccessoryId",
                table: "VehicleAccessories",
                column: "StockAccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAccessories_VehicleId",
                table: "VehicleAccessories",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleAccessories");
        }
    }
}
