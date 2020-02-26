using Microsoft.EntityFrameworkCore.Migrations;

namespace Drone.DataAccess.Migrations
{
    public partial class AddedBoxCountAndLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoxCount",
                table: "Containers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Placement",
                table: "Containers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxCount",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "Placement",
                table: "Containers");
        }
    }
}
