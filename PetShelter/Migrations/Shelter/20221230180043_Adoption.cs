using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShelter.Migrations.Shelter
{
    public partial class Adoption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Adoption",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BeforePet",
                table: "Adoption",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomePet",
                table: "Adoption",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Adoption");

            migrationBuilder.DropColumn(
                name: "BeforePet",
                table: "Adoption");

            migrationBuilder.DropColumn(
                name: "HomePet",
                table: "Adoption");
        }
    }
}
