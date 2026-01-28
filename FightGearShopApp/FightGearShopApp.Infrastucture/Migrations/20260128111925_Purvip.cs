using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightGearShopApp.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Purvip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LasttName",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "AspNetUsers",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "LasttName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "Adress");
        }
    }
}
