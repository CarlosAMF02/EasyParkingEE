using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppGlobal.Migrations
{
    public partial class idendereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estacionamentos_Enderecos_EnderecoId",
                table: "Estacionamentos");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Estacionamentos",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddColumn<int>(
                name: "Id_Endereco",
                table: "Estacionamentos",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Estacionamentos_Enderecos_EnderecoId",
                table: "Estacionamentos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estacionamentos_Enderecos_EnderecoId",
                table: "Estacionamentos");

            migrationBuilder.DropColumn(
                name: "Id_Endereco",
                table: "Estacionamentos");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Estacionamentos",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estacionamentos_Enderecos_EnderecoId",
                table: "Estacionamentos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
