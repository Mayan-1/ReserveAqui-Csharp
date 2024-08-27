using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveAqui.Migrations
{
    /// <inheritdoc />
    public partial class Refatorar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_Instituicoes_InstituicaoId",
                table: "Administradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_ReservaMateriais_ReservaMaterialId",
                table: "Materiais");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Instituicoes_InstituicaoId",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Salas_ReservaSalas_ReservaSalaId",
                table: "Salas");

            migrationBuilder.RenameColumn(
                name: "ReservaSalaId",
                table: "Salas",
                newName: "ReservaSalaModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Salas_ReservaSalaId",
                table: "Salas",
                newName: "IX_Salas_ReservaSalaModelId");

            migrationBuilder.RenameColumn(
                name: "ReservaMaterialId",
                table: "Materiais",
                newName: "ReservaMaterialModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Materiais_ReservaMaterialId",
                table: "Materiais",
                newName: "IX_Materiais_ReservaMaterialModelId");

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Professores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Administradores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_Instituicoes_InstituicaoId",
                table: "Administradores",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_ReservaMateriais_ReservaMaterialModelId",
                table: "Materiais",
                column: "ReservaMaterialModelId",
                principalTable: "ReservaMateriais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Instituicoes_InstituicaoId",
                table: "Professores",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_ReservaSalas_ReservaSalaModelId",
                table: "Salas",
                column: "ReservaSalaModelId",
                principalTable: "ReservaSalas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_Instituicoes_InstituicaoId",
                table: "Administradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_ReservaMateriais_ReservaMaterialModelId",
                table: "Materiais");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Instituicoes_InstituicaoId",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Salas_ReservaSalas_ReservaSalaModelId",
                table: "Salas");

            migrationBuilder.RenameColumn(
                name: "ReservaSalaModelId",
                table: "Salas",
                newName: "ReservaSalaId");

            migrationBuilder.RenameIndex(
                name: "IX_Salas_ReservaSalaModelId",
                table: "Salas",
                newName: "IX_Salas_ReservaSalaId");

            migrationBuilder.RenameColumn(
                name: "ReservaMaterialModelId",
                table: "Materiais",
                newName: "ReservaMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Materiais_ReservaMaterialModelId",
                table: "Materiais",
                newName: "IX_Materiais_ReservaMaterialId");

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstituicaoId",
                table: "Administradores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_Instituicoes_InstituicaoId",
                table: "Administradores",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_ReservaMateriais_ReservaMaterialId",
                table: "Materiais",
                column: "ReservaMaterialId",
                principalTable: "ReservaMateriais",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Instituicoes_InstituicaoId",
                table: "Professores",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_ReservaSalas_ReservaSalaId",
                table: "Salas",
                column: "ReservaSalaId",
                principalTable: "ReservaSalas",
                principalColumn: "Id");
        }
    }
}
