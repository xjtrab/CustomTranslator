using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomTranslator.API.Migrations
{
    public partial class ChangeFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "TranslatorHistorys",
                newName: "ToText");

            migrationBuilder.AddColumn<string>(
                name: "FromText",
                table: "TranslatorHistorys",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromText",
                table: "TranslatorHistorys");

            migrationBuilder.RenameColumn(
                name: "ToText",
                table: "TranslatorHistorys",
                newName: "Text");
        }
    }
}
