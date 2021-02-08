using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTur.Infra.Data.Migrations
{
    public partial class BancoInicialPacote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Pacotes_PacoteId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_PacoteId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "PacoteId",
                table: "Comentarios");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Pacotes",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Pacotes",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Pacotes",
                type: "Text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdPacote",
                table: "Comentarios",
                column: "IdPacote");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Pacotes_IdPacote",
                table: "Comentarios",
                column: "IdPacote",
                principalTable: "Pacotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Pacotes_IdPacote",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_IdPacote",
                table: "Comentarios");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Pacotes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Pacotes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Pacotes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Text");

            migrationBuilder.AddColumn<Guid>(
                name: "PacoteId",
                table: "Comentarios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PacoteId",
                table: "Comentarios",
                column: "PacoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Pacotes_PacoteId",
                table: "Comentarios",
                column: "PacoteId",
                principalTable: "Pacotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
