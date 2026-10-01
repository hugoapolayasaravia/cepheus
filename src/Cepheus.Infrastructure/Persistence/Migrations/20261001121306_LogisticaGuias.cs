using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LogisticaGuias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumeroRet",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "001-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroLet",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "001-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroGve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "001-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroFve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "001-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "001-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "001-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroBve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "001-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "GuiaNum",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "001-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MotivosDevolucion_Code",
                schema: "comun",
                table: "MotivosDevolucion",
                column: "Code");

            migrationBuilder.CreateTable(
                name: "Guias",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(10)", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "date", nullable: false),
                    Hora = table.Column<string>(type: "char(5)", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    MotivoCode = table.Column<string>(type: "char(2)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PuntoPartida = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    TransportistaCode = table.Column<string>(type: "char(5)", nullable: false),
                    ConductorCode = table.Column<string>(type: "char(5)", nullable: false),
                    VehiculoCode = table.Column<string>(type: "char(5)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guias", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_Guias_Conductores_ConductorCode",
                        column: x => x.ConductorCode,
                        principalSchema: "logistica",
                        principalTable: "Conductores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guias_MotivosDevolucion_MotivoCode",
                        column: x => x.MotivoCode,
                        principalSchema: "comun",
                        principalTable: "MotivosDevolucion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guias_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guias_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guias_Transportistas_TransportistaCode",
                        column: x => x.TransportistaCode,
                        principalSchema: "logistica",
                        principalTable: "Transportistas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guias_Vehiculos_VehiculoCode",
                        column: x => x.VehiculoCode,
                        principalSchema: "logistica",
                        principalTable: "Vehiculos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuiaDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    GuiaCode = table.Column<string>(type: "char(10)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuiaDetalles", x => new { x.PlantaCode, x.GuiaCode, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_GuiaDetalles_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuiaDetalles_Guias_PlantaCode_GuiaCode",
                        columns: x => new { x.PlantaCode, x.GuiaCode },
                        principalSchema: "logistica",
                        principalTable: "Guias",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuiaDetalles_ArticuloCode",
                schema: "logistica",
                table: "GuiaDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_Guias_ConductorCode",
                schema: "logistica",
                table: "Guias",
                column: "ConductorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Guias_MotivoCode",
                schema: "logistica",
                table: "Guias",
                column: "MotivoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Guias_PlantaCode_FechaEmision",
                schema: "logistica",
                table: "Guias",
                columns: new[] { "PlantaCode", "FechaEmision" });

            migrationBuilder.CreateIndex(
                name: "IX_Guias_ProveedorCode",
                schema: "logistica",
                table: "Guias",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Guias_TransportistaCode",
                schema: "logistica",
                table: "Guias",
                column: "TransportistaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Guias_VehiculoCode",
                schema: "logistica",
                table: "Guias",
                column: "VehiculoCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuiaDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Guias",
                schema: "logistica");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_MotivosDevolucion_Code",
                schema: "comun",
                table: "MotivosDevolucion");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroRet",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "001-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroLet",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "001-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroGve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "001-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroFve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "001-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "001-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "001-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroBve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "001-000000");

            migrationBuilder.AlterColumn<string>(
                name: "GuiaNum",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "001-000000");
        }
    }
}
