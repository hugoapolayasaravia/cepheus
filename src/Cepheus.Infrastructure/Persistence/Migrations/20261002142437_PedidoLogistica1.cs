using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PedidoLogistica1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                schema: "logistica",
                table: "Pedidos",
                newName: "EstadoPedido");

            migrationBuilder.RenameColumn(
                name: "Estado",
                schema: "logistica",
                table: "PedidoDetalles",
                newName: "EstadoPedidoDetalle");

            migrationBuilder.AlterColumn<string>(
                name: "TipoValeCode",
                schema: "logistica",
                table: "Pedidos",
                type: "char(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstadoPedido",
                schema: "logistica",
                table: "Pedidos",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "EstadoPedidoDetalle",
                schema: "logistica",
                table: "PedidoDetalles",
                newName: "Estado");

            migrationBuilder.AlterColumn<string>(
                name: "TipoValeCode",
                schema: "logistica",
                table: "Pedidos",
                type: "char(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3);
        }
    }
}
