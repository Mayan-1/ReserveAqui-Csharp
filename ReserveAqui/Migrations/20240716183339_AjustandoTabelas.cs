using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveAqui.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salas_ReservaSalas_ReservaSalaModelId",
                table: "Salas");

            migrationBuilder.DropIndex(
                name: "IX_Salas_ReservaSalaModelId",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "ReservaSalaModelId",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "DataReserva",
                table: "ReservaSalas");

            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Salas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraInicio",
                table: "ReservaSalas",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraFim",
                table: "ReservaSalas",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "ReservaSalas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservaSalas_SalaId",
                table: "ReservaSalas",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaSalas_Salas_SalaId",
                table: "ReservaSalas",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaSalas_Salas_SalaId",
                table: "ReservaSalas");

            migrationBuilder.DropIndex(
                name: "IX_ReservaSalas_SalaId",
                table: "ReservaSalas");

            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "ReservaSalas");

            migrationBuilder.AddColumn<int>(
                name: "ReservaSalaModelId",
                table: "Salas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HoraInicio",
                table: "ReservaSalas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HoraFim",
                table: "ReservaSalas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataReserva",
                table: "ReservaSalas",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salas_ReservaSalaModelId",
                table: "Salas",
                column: "ReservaSalaModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_ReservaSalas_ReservaSalaModelId",
                table: "Salas",
                column: "ReservaSalaModelId",
                principalTable: "ReservaSalas",
                principalColumn: "Id");
        }
    }
}
