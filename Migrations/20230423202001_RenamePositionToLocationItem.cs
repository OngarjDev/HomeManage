using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsureManage.Migrations
{
    public partial class RenamePositionToLocationItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Position",
                newName: "LocationItem"
                );
            migrationBuilder.RenameColumn(
                name: "Id_Position",
                table: "LocationItem",
                newName: "Id_LocationItem");

            migrationBuilder.RenameColumn(
                name: "Name_Position",
                table: "LocationItem",
                newName: "Name_LocationItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name_LocationItem",
                table: "LocationItem",
                newName: "Name_Position");

            migrationBuilder.RenameColumn(
                name: "Id_LocationItem",
                table: "LocationItem",
                newName: "Id_Position");
        }
    }
}
