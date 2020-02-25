using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Drone.DataAccess.Migrations
{
    public partial class AddedItemCountExpirationDateAndManufacturingDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Containers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ItemCount",
                table: "Containers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ManufacturingDate",
                table: "Containers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "ItemCount",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "ManufacturingDate",
                table: "Containers");
        }
    }
}
