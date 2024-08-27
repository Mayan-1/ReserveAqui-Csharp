using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveAqui.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_ReservaMateriais_ReservaMaterialModelId",
                table: "Materiais");

            migrationBuilder.DropIndex(
                name: "IX_Materiais_ReservaMaterialModelId",
                table: "Materiais");

            migrationBuilder.DropColumn(
                name: "ReservaMaterialModelId",
                table: "Materiais");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "ReservaMateriais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservaMateriais_MaterialId",
                table: "ReservaMateriais",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaMateriais_Materiais_MaterialId",
                table: "ReservaMateriais",
                column: "MaterialId",
                principalTable: "Materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaMateriais_Materiais_MaterialId",
                table: "ReservaMateriais");

            migrationBuilder.DropIndex(
                name: "IX_ReservaMateriais_MaterialId",
                table: "ReservaMateriais");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "ReservaMateriais");

            migrationBuilder.AddColumn<int>(
                name: "ReservaMaterialModelId",
                table: "Materiais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_ReservaMaterialModelId",
                table: "Materiais",
                column: "ReservaMaterialModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_ReservaMateriais_ReservaMaterialModelId",
                table: "Materiais",
                column: "ReservaMaterialModelId",
                principalTable: "ReservaMateriais",
                principalColumn: "Id");
        }
    }
}
