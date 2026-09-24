using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambioFAC1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListasPrecios_Productos_ProductoTipoProductoCode_ProductoCode",
                schema: "facturacion",
                table: "ListasPrecios");

            migrationBuilder.DropIndex(
                name: "IX_ListasPrecios_ProductoTipoProductoCode_ProductoCode",
                schema: "facturacion",
                table: "ListasPrecios");

            migrationBuilder.DropColumn(
                name: "ProductoTipoProductoCode",
                schema: "facturacion",
                table: "ListasPrecios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductoTipoProductoCode",
                schema: "facturacion",
                table: "ListasPrecios",
                type: "char(2)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ListasPrecios_ProductoTipoProductoCode_ProductoCode",
                schema: "facturacion",
                table: "ListasPrecios",
                columns: new[] { "ProductoTipoProductoCode", "ProductoCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_ListasPrecios_Productos_ProductoTipoProductoCode_ProductoCode",
                schema: "facturacion",
                table: "ListasPrecios",
                columns: new[] { "ProductoTipoProductoCode", "ProductoCode" },
                principalSchema: "facturacion",
                principalTable: "Productos",
                principalColumns: new[] { "TipoProductoCode", "Code" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
