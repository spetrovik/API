using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ExtendedIngridient3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngrdientQuantity",
                table: "Ingridients",
                newName: "IngridientQuantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngridientQuantity",
                table: "Ingridients",
                newName: "IngrdientQuantity");
        }
    }
}
