using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambiosComprobante1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesCompra_ComprobantesPago_ComprobantePagoId",
                schema: "logistica",
                table: "OrdenesCompra");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesCompra_ComprobantePagoId",
                schema: "logistica",
                table: "OrdenesCompra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComprobantesPago",
                schema: "comun",
                table: "ComprobantesPago");

            migrationBuilder.DropColumn(
                name: "ComprobantePagoId",
                schema: "logistica",
                table: "OrdenesCompra");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "comun",
                table: "ComprobantesPago");

            migrationBuilder.AddColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra",
                type: "nvarchar(2)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CantidadEntregada",
                schema: "logistica",
                table: "OrdenCompraPedidoOrigenes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "comun",
                table: "ComprobantesPago",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComprobantesPago",
                schema: "comun",
                table: "ComprobantesPago",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "ComprobantePagoCode");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesCompra_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesCompra_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesCompra_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComprobantesPago",
                schema: "comun",
                table: "ComprobantesPago");

            migrationBuilder.DropColumn(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra");

            migrationBuilder.DropColumn(
                name: "CantidadEntregada",
                schema: "logistica",
                table: "OrdenCompraPedidoOrigenes");

            migrationBuilder.AddColumn<int>(
                name: "ComprobantePagoId",
                schema: "logistica",
                table: "OrdenesCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "comun",
                table: "ComprobantesPago",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "comun",
                table: "ComprobantesPago",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComprobantesPago",
                schema: "comun",
                table: "ComprobantesPago",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_ComprobantePagoId",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "ComprobantePagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesCompra_ComprobantesPago_ComprobantePagoId",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "ComprobantePagoId",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
