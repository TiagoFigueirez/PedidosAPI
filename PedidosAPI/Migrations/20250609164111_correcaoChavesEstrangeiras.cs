using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class correcaoChavesEstrangeiras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_SubCategorias_SubCategoriaId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategorias_Categorias_CategoriaId",
                table: "SubCategorias");

            migrationBuilder.RenameColumn(
                name: "SubCategoriaId",
                table: "Produtos",
                newName: "SubcategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_SubCategoriaId",
                table: "Produtos",
                newName: "IX_Produtos_SubcategoriaId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "SubCategorias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubcategoriaId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_SubCategorias_SubcategoriaId",
                table: "Produtos",
                column: "SubcategoriaId",
                principalTable: "SubCategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategorias_Categorias_CategoriaId",
                table: "SubCategorias",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_SubCategorias_SubcategoriaId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategorias_Categorias_CategoriaId",
                table: "SubCategorias");

            migrationBuilder.RenameColumn(
                name: "SubcategoriaId",
                table: "Produtos",
                newName: "SubCategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_SubcategoriaId",
                table: "Produtos",
                newName: "IX_Produtos_SubCategoriaId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "SubCategorias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoriaId",
                table: "Produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_SubCategorias_SubCategoriaId",
                table: "Produtos",
                column: "SubCategoriaId",
                principalTable: "SubCategorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategorias_Categorias_CategoriaId",
                table: "SubCategorias",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }
    }
}
