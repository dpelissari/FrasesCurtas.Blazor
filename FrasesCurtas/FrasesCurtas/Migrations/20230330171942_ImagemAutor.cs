using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrasesCurtas.Migrations
{
    public partial class ImagemAutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaminhoImagem",
                table: "Autores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoImagem",
                table: "Autores");
        }
    }
}
