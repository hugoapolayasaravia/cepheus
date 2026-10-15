
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ORDENCOMPRADM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Eliminar las claves foráneas que dependen de ComprobantesPago.Code.
            migrationBuilder.DropForeignKey(
                name: "FK_ImportacionDetalles_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportacionGastos_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionGastos");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaIngresos_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaIngresos_ComprobantesPago_ComprobantePagoReferenciaCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesCompra_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesServicio_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesServicio");

            // 2. Eliminar la clave primaria antes de modificar Code.
            migrationBuilder.DropPrimaryKey(
                name: "PK_ComprobantesPago",
                schema: "comun",
                table: "ComprobantesPago");

            // 3. Cambiar las columnas dependientes a char(2).
            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesServicio",
                type: "char(2)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)");

            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra",
                type: "char(2)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)");

            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoReferenciaCode",
                schema: "logistica",
                table: "NotaIngresos",
                type: "char(2)",
                fixedLength: true,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "NotaIngresos",
                type: "char(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)");

            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionGastos",
                type: "char(2)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionDetalles",
                type: "char(2)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "SunatCode",
                schema: "comun",
                table: "ComprobantesPago",
                type: "char(2)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "comun",
                table: "ComprobantesPago",
                type: "char(2)",
                fixedLength: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            // 4. Restaurar la clave primaria inmediatamente después de modificar Code.
            migrationBuilder.AddPrimaryKey(
                name: "PK_ComprobantesPago",
                schema: "comun",
                table: "ComprobantesPago",
                column: "Code");

            // 5. Crear la tabla OrdenesCompraAdministracion.
            migrationBuilder.CreateTable(
                name: "OrdenesCompraAdministracion",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    ComprobantePagoCode = table.Column<string>(type: "char(2)", fixedLength: true, nullable: false),
                    EmitirDocumento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    CompradorCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    LugarEnvioCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    FormaPagoCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    TramiteCode = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Observaciones1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Observaciones2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NotaCompraCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    UnidadNegocioCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false, defaultValue: "000000"),
                    Motivo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    AprobadoPor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NetoCompra = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    IgvCompra = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    TotalCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    NoGravableCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    RentaCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    FonaviCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    ServicioCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    IgvExteriorCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesCompraAdministracion", x => x.Code);

                    table.ForeignKey(
                        name: "FK_OrdenesCompraAdministracion_Compradores_CompradorCode",
                        column: x => x.CompradorCode,
                        principalSchema: "logistica",
                        principalTable: "Compradores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_OrdenesCompraAdministracion_ComprobantesPago_ComprobantePagoCode",
                        column: x => x.ComprobantePagoCode,
                        principalSchema: "comun",
                        principalTable: "ComprobantesPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_OrdenesCompraAdministracion_FormasPago_FormaPagoCode",
                        column: x => x.FormaPagoCode,
                        principalSchema: "logistica",
                        principalTable: "FormasPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_OrdenesCompraAdministracion_LugaresEnvio_LugarEnvioCode",
                        column: x => x.LugarEnvioCode,
                        principalSchema: "logistica",
                        principalTable: "LugaresEnvio",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_OrdenesCompraAdministracion_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_OrdenesCompraAdministracion_NotasCompra_NotaCompraCode",
                        column: x => x.NotaCompraCode,
                        principalSchema: "logistica",
                        principalTable: "NotasCompra",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_OrdenesCompraAdministracion_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_OrdenesCompraAdministracion_Tramites_TramiteCode",
                        column: x => x.TramiteCode,
                        principalSchema: "logistica",
                        principalTable: "Tramites",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_OrdenesCompraAdministracion_UnidadesNegocio_UnidadNegocioCode",
                        column: x => x.UnidadNegocioCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesNegocio",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            // 6. Crear la tabla DocumentosCompra.
            migrationBuilder.CreateTable(
                name: "DocumentosCompra",
                schema: "contabilidad",
                columns: table => new
                {
                    ComprobantePagoCode = table.Column<string>(type: "char(2)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "char(15)", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "date", nullable: false),
                    FechaRecepcion = table.Column<DateTime>(type: "date", nullable: false),
                    FormaPagoCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    TipoCambioFecha = table.Column<DateOnly>(type: "date", nullable: true),
                    ParcialSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, defaultValue: 0m),
                    IgvSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, defaultValue: 0m),
                    NoGravableSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, defaultValue: 0m),
                    RentaSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, defaultValue: 0m),
                    FonaviSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, defaultValue: 0m),
                    ServicioSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, defaultValue: 0m),
                    IgvExteriorSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, defaultValue: 0m),
                    TotalSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, defaultValue: 0m),
                    Glosa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Origen = table.Column<int>(type: "int", nullable: false),
                    Procedencia = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    TipoBienCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    TipoOperacionCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    OperacionDetraccion = table.Column<string>(type: "char(10)", nullable: true),
                    ConstanciaDetraccion = table.Column<string>(type: "char(10)", nullable: true),
                    FechaConstanciaDetraccion = table.Column<DateTime>(type: "date", nullable: true),
                    NumeroDetraccion = table.Column<string>(type: "char(10)", nullable: true),
                    FechaEmisionDetraccion = table.Column<DateTime>(type: "date", nullable: true),
                    MontoDetraccionSol = table.Column<decimal>(type: "decimal(16,2)", nullable: false, defaultValue: 0m),
                    DocumentoOrigenComprobantePagoCode = table.Column<string>(type: "char(2)", nullable: true),
                    DocumentoOrigenNumero = table.Column<string>(type: "char(15)", nullable: true),
                    OrdenCompraAdministracionCode = table.Column<string>(type: "char(6)", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "date", nullable: false),
                    PagadoSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, defaultValue: 0m),
                    FechaCancelacion = table.Column<DateTime>(type: "date", nullable: true),
                    PendienteSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, computedColumnSql: "[TotalSol] - [PagadoSol]"),
                    AsientoProvisionCode = table.Column<string>(type: "char(13)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_DocumentosCompra",
                        x => new { x.ComprobantePagoCode, x.NumeroDocumento, x.ProveedorCode });

                    table.ForeignKey(
                        name: "FK_DocumentosCompra_ComprobantesPago_ComprobantePagoCode",
                        column: x => x.ComprobantePagoCode,
                        principalSchema: "comun",
                        principalTable: "ComprobantesPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentosCompra_DocumentosCompra_DocumentoOrigenComprobantePagoCode_DocumentoOrigenNumero_ProveedorCode",
                        columns: x => new { x.DocumentoOrigenComprobantePagoCode, x.DocumentoOrigenNumero, x.ProveedorCode },
                        principalSchema: "contabilidad",
                        principalTable: "DocumentosCompra",
                        principalColumns: new[] { "ComprobantePagoCode", "NumeroDocumento", "ProveedorCode" },
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentosCompra_FormasPago_FormaPagoCode",
                        column: x => x.FormaPagoCode,
                        principalSchema: "logistica",
                        principalTable: "FormasPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentosCompra_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentosCompra_OrdenesCompraAdministracion_OrdenCompraAdministracionCode",
                        column: x => x.OrdenCompraAdministracionCode,
                        principalSchema: "logistica",
                        principalTable: "OrdenesCompraAdministracion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentosCompra_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentosCompra_TiposBien_TipoBienCode",
                        column: x => x.TipoBienCode,
                        principalSchema: "facturacion",
                        principalTable: "TiposBien",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentosCompra_TiposOperacion_TipoOperacionCode",
                        column: x => x.TipoOperacionCode,
                        principalSchema: "facturacion",
                        principalTable: "TiposOperacion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            // 7. Crear la tabla OrdenCompraAdministracionDetalles.
            migrationBuilder.CreateTable(
                name: "OrdenCompraAdministracionDetalles",
                schema: "logistica",
                columns: table => new
                {
                    OrdenCompraAdministracionCode = table.Column<string>(type: "char(6)", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    Glosa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UnidadMedidaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    Descuento = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    SubCentroCostoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    CantidadEntregada = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_OrdenCompraAdministracionDetalles",
                        x => new { x.OrdenCompraAdministracionCode, x.ItemNumber });

                    table.ForeignKey(
                        name: "FK_OrdenCompraAdministracionDetalles_OrdenesCompraAdministracion_OrdenCompraAdministracionCode",
                        column: x => x.OrdenCompraAdministracionCode,
                        principalSchema: "logistica",
                        principalTable: "OrdenesCompraAdministracion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_OrdenCompraAdministracionDetalles_SubCentrosCosto_SubCentroCostoCode",
                        column: x => x.SubCentroCostoCode,
                        principalSchema: "logistica",
                        principalTable: "SubCentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_OrdenCompraAdministracionDetalles_UnidadesMedida_UnidadMedidaCode",
                        column: x => x.UnidadMedidaCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesMedida",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            // 8. Crear la tabla DocumentoCompraDetalles.
            migrationBuilder.CreateTable(
                name: "DocumentoCompraDetalles",
                schema: "contabilidad",
                columns: table => new
                {
                    ComprobantePagoCode = table.Column<string>(type: "char(2)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "char(15)", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    CuentaContableCode = table.Column<string>(type: "char(8)", nullable: false),
                    AnexoTipoCode = table.Column<string>(type: "char(3)", nullable: true),
                    AnexoCode = table.Column<string>(type: "char(5)", nullable: true),
                    Detalle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(24,4)", nullable: false, defaultValue: 0m),
                    UnidadMedidaCode = table.Column<string>(type: "char(2)", maxLength: 5, nullable: false),
                    PrecioSol = table.Column<decimal>(type: "decimal(24,5)", nullable: false, defaultValue: 0m),
                    ParcialSol = table.Column<decimal>(type: "decimal(24,2)", nullable: false, defaultValue: 0m),
                    NumeroGuiaVenta = table.Column<string>(type: "char(10)", nullable: true),
                    ProductoTipoCode = table.Column<string>(type: "char(2)", nullable: true),
                    ProductoCode = table.Column<string>(type: "char(4)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_DocumentoCompraDetalles",
                        x => new { x.ComprobantePagoCode, x.NumeroDocumento, x.ProveedorCode, x.ItemNumber });

                    table.ForeignKey(
                        name: "FK_DocumentoCompraDetalles_Anexos_AnexoTipoCode_AnexoCode",
                        columns: x => new { x.AnexoTipoCode, x.AnexoCode },
                        principalSchema: "contabilidad",
                        principalTable: "Anexos",
                        principalColumns: new[] { "TipoAnexoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentoCompraDetalles_CuentasContables_CuentaContableCode",
                        column: x => x.CuentaContableCode,
                        principalSchema: "contabilidad",
                        principalTable: "CuentasContables",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentoCompraDetalles_DocumentosCompra_ComprobantePagoCode_NumeroDocumento_ProveedorCode",
                        columns: x => new { x.ComprobantePagoCode, x.NumeroDocumento, x.ProveedorCode },
                        principalSchema: "contabilidad",
                        principalTable: "DocumentosCompra",
                        principalColumns: new[] { "ComprobantePagoCode", "NumeroDocumento", "ProveedorCode" },
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_DocumentoCompraDetalles_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentoCompraDetalles_Productos_ProductoTipoCode_ProductoCode",
                        columns: x => new { x.ProductoTipoCode, x.ProductoCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_DocumentoCompraDetalles_UnidadesMedidaVenta_UnidadMedidaCode",
                        column: x => x.UnidadMedidaCode,
                        principalSchema: "facturacion",
                        principalTable: "UnidadesMedidaVenta",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            // 9. Crear índices de DocumentoCompraDetalles.
            migrationBuilder.CreateIndex(
                name: "IX_DocumentoCompraDetalles_AnexoTipoCode_AnexoCode",
                schema: "contabilidad",
                table: "DocumentoCompraDetalles",
                columns: new[] { "AnexoTipoCode", "AnexoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoCompraDetalles_CuentaContableCode",
                schema: "contabilidad",
                table: "DocumentoCompraDetalles",
                column: "CuentaContableCode");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoCompraDetalles_PlantaCode",
                schema: "contabilidad",
                table: "DocumentoCompraDetalles",
                column: "PlantaCode");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoCompraDetalles_ProductoTipoCode_ProductoCode",
                schema: "contabilidad",
                table: "DocumentoCompraDetalles",
                columns: new[] { "ProductoTipoCode", "ProductoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoCompraDetalles_UnidadMedidaCode",
                schema: "contabilidad",
                table: "DocumentoCompraDetalles",
                column: "UnidadMedidaCode");

            // 10. Crear índices de DocumentosCompra.
            migrationBuilder.CreateIndex(
                name: "IX_DocumentosCompra_DocumentoOrigenComprobantePagoCode_DocumentoOrigenNumero_ProveedorCode",
                schema: "contabilidad",
                table: "DocumentosCompra",
                columns: new[] { "DocumentoOrigenComprobantePagoCode", "DocumentoOrigenNumero", "ProveedorCode" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosCompra_Estado",
                schema: "contabilidad",
                table: "DocumentosCompra",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosCompra_FechaEmision",
                schema: "contabilidad",
                table: "DocumentosCompra",
                column: "FechaEmision");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosCompra_FormaPagoCode",
                schema: "contabilidad",
                table: "DocumentosCompra",
                column: "FormaPagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosCompra_MonedaCode",
                schema: "contabilidad",
                table: "DocumentosCompra",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosCompra_OrdenCompraAdministracionCode",
                schema: "contabilidad",
                table: "DocumentosCompra",
                column: "OrdenCompraAdministracionCode");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosCompra_ProveedorCode",
                schema: "contabilidad",
                table: "DocumentosCompra",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosCompra_TipoBienCode",
                schema: "contabilidad",
                table: "DocumentosCompra",
                column: "TipoBienCode");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosCompra_TipoOperacionCode",
                schema: "contabilidad",
                table: "DocumentosCompra",
                column: "TipoOperacionCode");

            // 11. Crear índices de OrdenCompraAdministracionDetalles.
            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraAdministracionDetalles_SubCentroCostoCode",
                schema: "logistica",
                table: "OrdenCompraAdministracionDetalles",
                column: "SubCentroCostoCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraAdministracionDetalles_UnidadMedidaCode",
                schema: "logistica",
                table: "OrdenCompraAdministracionDetalles",
                column: "UnidadMedidaCode");

            // 12. Crear índices de OrdenesCompraAdministracion.
            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_CompradorCode",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "CompradorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "ComprobantePagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_CreatedAt",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_Estado",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_FormaPagoCode",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "FormaPagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_LugarEnvioCode",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "LugarEnvioCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_MonedaCode",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_NotaCompraCode",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "NotaCompraCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_ProveedorCode",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_TramiteCode",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "TramiteCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraAdministracion_UnidadNegocioCode",
                schema: "logistica",
                table: "OrdenesCompraAdministracion",
                column: "UnidadNegocioCode");

            // 13. Restaurar las seis claves foráneas eliminadas al inicio.
            migrationBuilder.AddForeignKey(
                name: "FK_ImportacionDetalles_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionDetalles",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportacionGastos_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionGastos",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaIngresos_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaIngresos_ComprobantesPago_ComprobantePagoReferenciaCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "ComprobantePagoReferenciaCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesCompra_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesServicio_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 1. Eliminar primero las tablas creadas por esta migración.
            migrationBuilder.DropTable(
                name: "DocumentoCompraDetalles",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "OrdenCompraAdministracionDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "DocumentosCompra",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "OrdenesCompraAdministracion",
                schema: "logistica");

            // 2. Eliminar las seis claves foráneas antes de cambiar los tipos.
            migrationBuilder.DropForeignKey(
                name: "FK_ImportacionDetalles_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportacionGastos_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionGastos");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaIngresos_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaIngresos_ComprobantesPago_ComprobantePagoReferenciaCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesCompra_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesServicio_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesServicio");

            // 3. Eliminar la clave primaria antes de revertir el tipo de Code.
            migrationBuilder.DropPrimaryKey(
                name: "PK_ComprobantesPago",
                schema: "comun",
                table: "ComprobantesPago");

            // 4. Revertir las columnas a nvarchar(2).
            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesServicio",
                type: "nvarchar(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldFixedLength: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra",
                type: "nvarchar(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldFixedLength: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoReferenciaCode",
                schema: "logistica",
                table: "NotaIngresos",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldFixedLength: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "NotaIngresos",
                type: "nvarchar(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(2)");

            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionGastos",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldFixedLength: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionDetalles",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldFixedLength: true);

            migrationBuilder.AlterColumn<string>(
                name: "SunatCode",
                schema: "comun",
                table: "ComprobantesPago",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldFixedLength: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "comun",
                table: "ComprobantesPago",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldFixedLength: true);

            // 5. Restaurar la clave primaria después de revertir Code.
            migrationBuilder.AddPrimaryKey(
                name: "PK_ComprobantesPago",
                schema: "comun",
                table: "ComprobantesPago",
                column: "Code");

            // 6. Restaurar las seis claves foráneas originales.
            migrationBuilder.AddForeignKey(
                name: "FK_ImportacionDetalles_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionDetalles",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportacionGastos_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionGastos",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaIngresos_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaIngresos_ComprobantesPago_ComprobantePagoReferenciaCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "ComprobantePagoReferenciaCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesCompra_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesServicio_ComprobantesPago_ComprobantePagoCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "ComprobantePagoCode",
                principalSchema: "comun",
                principalTable: "ComprobantesPago",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
