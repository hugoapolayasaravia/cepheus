using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LogisticaTraCompras2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlturasLosa_Productos_ConcreteProductoTipoCode_ConcreteProductoCode",
                schema: "facturacion",
                table: "AlturasLosa");

            migrationBuilder.RenameColumn(
                name: "ConcreteProductoTipoCode",
                schema: "facturacion",
                table: "AlturasLosa",
                newName: "ProductoTipoCode");

            migrationBuilder.RenameColumn(
                name: "ConcreteProductoCode",
                schema: "facturacion",
                table: "AlturasLosa",
                newName: "ProductoCode");

            migrationBuilder.RenameIndex(
                name: "IX_AlturasLosa_ConcreteProductoTipoCode_ConcreteProductoCode",
                schema: "facturacion",
                table: "AlturasLosa",
                newName: "IX_AlturasLosa_ProductoTipoCode_ProductoCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AlturasLosa_Productos_ProductoTipoCode_ProductoCode",
                schema: "facturacion",
                table: "AlturasLosa",
                columns: new[] { "ProductoTipoCode", "ProductoCode" },
                principalSchema: "facturacion",
                principalTable: "Productos",
                principalColumns: new[] { "TipoProductoCode", "Code" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlturasLosa_Productos_ProductoTipoCode_ProductoCode",
                schema: "facturacion",
                table: "AlturasLosa");

            migrationBuilder.RenameColumn(
                name: "ProductoTipoCode",
                schema: "facturacion",
                table: "AlturasLosa",
                newName: "ConcreteProductoTipoCode");

            migrationBuilder.RenameColumn(
                name: "ProductoCode",
                schema: "facturacion",
                table: "AlturasLosa",
                newName: "ConcreteProductoCode");

            migrationBuilder.RenameIndex(
                name: "IX_AlturasLosa_ProductoTipoCode_ProductoCode",
                schema: "facturacion",
                table: "AlturasLosa",
                newName: "IX_AlturasLosa_ConcreteProductoTipoCode_ConcreteProductoCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AlturasLosa_Productos_ConcreteProductoTipoCode_ConcreteProductoCode",
                schema: "facturacion",
                table: "AlturasLosa",
                columns: new[] { "ConcreteProductoTipoCode", "ConcreteProductoCode" },
                principalSchema: "facturacion",
                principalTable: "Productos",
                principalColumns: new[] { "TipoProductoCode", "Code" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
