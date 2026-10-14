using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Contabilidad1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "contabilidad");

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                type: "char(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAccountCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                type: "char(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransportAccountCode",
                schema: "facturacion",
                table: "Productos",
                type: "char(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditNoteAccountCode",
                schema: "facturacion",
                table: "Productos",
                type: "char(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAccountCode",
                schema: "facturacion",
                table: "Productos",
                type: "char(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "Articulos",
                type: "char(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAccountCode",
                schema: "logistica",
                table: "Articulos",
                type: "char(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TiposAnexo",
                schema: "contabilidad",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Flag = table.Column<string>(type: "char(1)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAnexo", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposAsiento",
                schema: "contabilidad",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExchangeRateType = table.Column<int>(type: "int", nullable: false),
                    Valuation = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAsiento", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposCuentaContable",
                schema: "contabilidad",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCuentaContable", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Anexos",
                schema: "contabilidad",
                columns: table => new
                {
                    TipoAnexoCode = table.Column<string>(type: "char(3)", nullable: false),
                    Code = table.Column<string>(type: "char(5)", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: true),
                    LinkAccount1Code = table.Column<string>(type: "char(8)", nullable: false),
                    LinkAccount2Code = table.Column<string>(type: "char(8)", nullable: false),
                    Flag = table.Column<string>(type: "char(1)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexos", x => new { x.TipoAnexoCode, x.Code });
                    table.ForeignKey(
                        name: "FK_Anexos_TiposAnexo_TipoAnexoCode",
                        column: x => x.TipoAnexoCode,
                        principalSchema: "contabilidad",
                        principalTable: "TiposAnexo",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuentasContables",
                schema: "contabilidad",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(8)", nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", nullable: false),
                    TipoCuentaCode = table.Column<string>(type: "char(2)", nullable: false),
                    TipoAnexoCode = table.Column<string>(type: "char(3)", nullable: false),
                    LinkAccount1Code = table.Column<string>(type: "char(8)", nullable: false),
                    LinkAccount2Code = table.Column<string>(type: "char(8)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "char(3)", nullable: false),
                    AcmFlag = table.Column<string>(type: "char(1)", nullable: false),
                    PilotFlag = table.Column<string>(type: "char(1)", nullable: false),
                    GainsLossesFlag = table.Column<string>(type: "char(1)", nullable: false),
                    ClosingAccountCode = table.Column<string>(type: "char(8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasContables", x => x.Code);
                    table.ForeignKey(
                        name: "FK_CuentasContables_Monedas_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuentasContables_TiposAnexo_TipoAnexoCode",
                        column: x => x.TipoAnexoCode,
                        principalSchema: "contabilidad",
                        principalTable: "TiposAnexo",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuentasContables_TiposCuentaContable_TipoCuentaCode",
                        column: x => x.TipoCuentaCode,
                        principalSchema: "contabilidad",
                        principalTable: "TiposCuentaContable",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuentasBancarias",
                schema: "contabilidad",
                columns: table => new
                {
                    BankCode = table.Column<string>(type: "char(3)", nullable: false),
                    AccountNumber = table.Column<string>(type: "char(20)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "char(3)", nullable: false),
                    CheckStart = table.Column<string>(type: "char(10)", nullable: false),
                    CheckEnd = table.Column<string>(type: "char(10)", nullable: false),
                    CheckCurrent = table.Column<string>(type: "char(10)", nullable: false),
                    ControlFlag = table.Column<string>(type: "char(1)", nullable: false),
                    AccountCode = table.Column<string>(type: "char(8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasBancarias", x => new { x.BankCode, x.AccountNumber });
                    table.ForeignKey(
                        name: "FK_CuentasBancarias_Bancos_BankCode",
                        column: x => x.BankCode,
                        principalSchema: "comun",
                        principalTable: "Bancos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuentasBancarias_CuentasContables_AccountCode",
                        column: x => x.AccountCode,
                        principalSchema: "contabilidad",
                        principalTable: "CuentasContables",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuentasBancarias_Monedas_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCentrosCosto_AccountingAccountCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                column: "AccountingAccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCentrosCosto_AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                column: "AccountingAttachmentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_AccountingAccountCode",
                schema: "facturacion",
                table: "Productos",
                column: "AccountingAccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CreditNoteAccountCode",
                schema: "facturacion",
                table: "Productos",
                column: "CreditNoteAccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TransportAccountCode",
                schema: "facturacion",
                table: "Productos",
                column: "TransportAccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_AccountingAccountCode",
                schema: "logistica",
                table: "Articulos",
                column: "AccountingAccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "Articulos",
                column: "AccountingAttachmentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasBancarias_AccountCode",
                schema: "contabilidad",
                table: "CuentasBancarias",
                column: "AccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasBancarias_CurrencyCode",
                schema: "contabilidad",
                table: "CuentasBancarias",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasContables_CurrencyCode",
                schema: "contabilidad",
                table: "CuentasContables",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasContables_TipoAnexoCode",
                schema: "contabilidad",
                table: "CuentasContables",
                column: "TipoAnexoCode");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasContables_TipoCuentaCode",
                schema: "contabilidad",
                table: "CuentasContables",
                column: "TipoCuentaCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_CuentasContables_AccountingAccountCode",
                schema: "logistica",
                table: "Articulos",
                column: "AccountingAccountCode",
                principalSchema: "contabilidad",
                principalTable: "CuentasContables",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_TiposAnexo_AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "Articulos",
                column: "AccountingAttachmentTypeCode",
                principalSchema: "contabilidad",
                principalTable: "TiposAnexo",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_CuentasContables_AccountingAccountCode",
                schema: "facturacion",
                table: "Productos",
                column: "AccountingAccountCode",
                principalSchema: "contabilidad",
                principalTable: "CuentasContables",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_CuentasContables_CreditNoteAccountCode",
                schema: "facturacion",
                table: "Productos",
                column: "CreditNoteAccountCode",
                principalSchema: "contabilidad",
                principalTable: "CuentasContables",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_CuentasContables_TransportAccountCode",
                schema: "facturacion",
                table: "Productos",
                column: "TransportAccountCode",
                principalSchema: "contabilidad",
                principalTable: "CuentasContables",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCentrosCosto_CuentasContables_AccountingAccountCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                column: "AccountingAccountCode",
                principalSchema: "contabilidad",
                principalTable: "CuentasContables",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCentrosCosto_TiposAnexo_AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                column: "AccountingAttachmentTypeCode",
                principalSchema: "contabilidad",
                principalTable: "TiposAnexo",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_CuentasContables_AccountingAccountCode",
                schema: "logistica",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_TiposAnexo_AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_CuentasContables_AccountingAccountCode",
                schema: "facturacion",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_CuentasContables_CreditNoteAccountCode",
                schema: "facturacion",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_CuentasContables_TransportAccountCode",
                schema: "facturacion",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCentrosCosto_CuentasContables_AccountingAccountCode",
                schema: "logistica",
                table: "SubCentrosCosto");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCentrosCosto_TiposAnexo_AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "SubCentrosCosto");

            migrationBuilder.DropTable(
                name: "Anexos",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "CuentasBancarias",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "TiposAsiento",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "CuentasContables",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "TiposAnexo",
                schema: "contabilidad");

            migrationBuilder.DropTable(
                name: "TiposCuentaContable",
                schema: "contabilidad");

            migrationBuilder.DropIndex(
                name: "IX_SubCentrosCosto_AccountingAccountCode",
                schema: "logistica",
                table: "SubCentrosCosto");

            migrationBuilder.DropIndex(
                name: "IX_SubCentrosCosto_AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "SubCentrosCosto");

            migrationBuilder.DropIndex(
                name: "IX_Productos_AccountingAccountCode",
                schema: "facturacion",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CreditNoteAccountCode",
                schema: "facturacion",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_TransportAccountCode",
                schema: "facturacion",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_AccountingAccountCode",
                schema: "logistica",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "Articulos");

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAccountCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TransportAccountCode",
                schema: "facturacion",
                table: "Productos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditNoteAccountCode",
                schema: "facturacion",
                table: "Productos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAccountCode",
                schema: "facturacion",
                table: "Productos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAttachmentTypeCode",
                schema: "logistica",
                table: "Articulos",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountingAccountCode",
                schema: "logistica",
                table: "Articulos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(8)",
                oldMaxLength: 8,
                oldNullable: true);
        }
    }
}
