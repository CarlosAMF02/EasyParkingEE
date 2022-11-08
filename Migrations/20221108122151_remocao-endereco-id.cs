using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppGlobal.Migrations
{
    public partial class remocaoenderecoid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Endereco",
                table: "Estacionamentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Endereco",
                table: "Estacionamentos",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }
    }
}
