using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mantenimiento");

            migrationBuilder.EnsureSchema(
                name: "rrhh");

            migrationBuilder.EnsureSchema(
                name: "facturacion");

            migrationBuilder.EnsureSchema(
                name: "logistica");

            migrationBuilder.EnsureSchema(
                name: "comun");

            migrationBuilder.EnsureSchema(
                name: "admin");

            migrationBuilder.CreateTable(
                name: "Afps",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afps", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Alergias",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergias", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AtributosConcreto",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    AttributeType = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AtributosConcreto", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Bancos",
                schema: "comun",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_Bancos", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasOcupacionales",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasOcupacionales", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasProducto",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirthCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProducto", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasTrabajador",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_CategoriasTrabajador", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CentrosEjecutores",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosEjecutores", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionesCliente",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionesCliente", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Compradores",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compradores", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ComprobantesPago",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SunatCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RequiresRuc = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RequiresAddress = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobantesPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlesVentas",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IgvPercentage = table.Column<decimal>(type: "numeric(24,2)", nullable: false),
                    WithholdingPercentage = table.Column<decimal>(type: "numeric(24,2)", nullable: false),
                    ClosingPeriod = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    SalesProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasesProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesCancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasesCancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithholdingCap = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    DetractionPercentage = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    IncomeTaxPercentage = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    FonaviPercentage = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    ForeignIgvPercentage = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    QuotaPercentage = table.Column<decimal>(type: "numeric(6,2)", nullable: false),
                    BlocksGrouping = table.Column<bool>(type: "bit", nullable: false),
                    WithholdingCapInvoice = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    WorkOrderDaysLimit = table.Column<int>(type: "int", nullable: false),
                    WorkOrderMaxDays = table.Column<int>(type: "int", nullable: false),
                    SaleMaxDays = table.Column<int>(type: "int", nullable: false),
                    BalanceLimit = table.Column<int>(type: "int", nullable: true),
                    AdditionalActivationDays = table.Column<int>(type: "int", nullable: true),
                    IsServiceIndicator = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlesVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eps",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eps", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "EstadosCiviles",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCiviles", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "EstadosTrabajador",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_EstadosTrabajador", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Familias",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "FormasPago",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    IsCredit = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPago", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "FormasPagoVenta",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    IsCredit = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagoVenta", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "GradosInstruccion",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradosInstruccion", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Inspecciones",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspecciones", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "LugaresEnvio",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugaresEnvio", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Maquinas",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquinas", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ModalidadesFormativas",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadesFormativas", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ModosPago",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_ModosPago", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tooltip = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monedas",
                schema: "comun",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NumericCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DecimalPlaces = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "MotivosDevolucion",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AffectsStock = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosDevolucion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalidades",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_Nacionalidades", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Negocios",
                schema: "comun",
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
                    table.PrimaryKey("PK_Negocios", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Niveles",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveles", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "NivelesEducativos",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelesEducativos", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "NivelesTrabajador",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelesTrabajador", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "NotasCompra",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasCompra", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ObjetosActividad",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosActividad", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Ocupaciones",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupaciones", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Oficinas",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficinas", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Oportunidades",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oportunidades", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Parentescos",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_Parentescos", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PlanesArticulo",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesArticulo", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Plantas",
                schema: "comun",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AddressComplement = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UbigeoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ManagerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HasWarehouse = table.Column<bool>(type: "bit", nullable: false),
                    IsProductionPlant = table.Column<bool>(type: "bit", nullable: false),
                    IsProject = table.Column<bool>(type: "bit", nullable: false),
                    RequiresApprovals = table.Column<bool>(type: "bit", nullable: false),
                    AppliesDetraction = table.Column<bool>(type: "bit", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Prioridades",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "RegimenesLaborales",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegimenesLaborales", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "RegimenesPensionarios",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegimenesPensionarios", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SctrPension",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SctrPension", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SctrSalud",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SctrSalud", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SegmentosVentas",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentosVentas", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SituacionesEps",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacionesEps", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoriasOcupacionales",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoriasOcupacionales", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SubOcupaciones",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubOcupaciones", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposAfiliacion",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_TiposAfiliacion", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposArticulo",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposArticulo", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposBien",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DetractionRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposBien", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposCambio",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SellRate = table.Column<decimal>(type: "numeric(9,4)", nullable: false),
                    BuyRate = table.Column<decimal>(type: "numeric(9,4)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCambio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposCentroFormacion",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCentroFormacion", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposCliente",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCliente", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposCompra",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCompra", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposContrato",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposContrato", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposCuenta",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_TiposCuenta", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumento",
                schema: "comun",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    SunatCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AffectsIgv = table.Column<bool>(type: "bit", nullable: false),
                    IsNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    AffectsIncomeTax = table.Column<bool>(type: "bit", nullable: false),
                    AffectsFonavi = table.Column<bool>(type: "bit", nullable: false),
                    IsService = table.Column<bool>(type: "bit", nullable: false),
                    AffectsForeignIgv = table.Column<bool>(type: "bit", nullable: false),
                    AvailableForPurchaseOrder = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumento", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposExtensionContrato",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposExtensionContrato", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposOperacion",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposOperacion", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposOrden",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposOrden", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposPedido",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPedido", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposPension",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPension", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposPersonal",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_TiposPersonal", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposProducto",
                schema: "facturacion",
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
                    table.PrimaryKey("PK_TiposProducto", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposSangre",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSangre", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposSctr",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSctr", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposSeguroMedico",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSeguroMedico", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposTrabajador",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_TiposTrabajador", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposTransaccion",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTransaccion", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposVale",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVale", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposValorizacion",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposValorizacion", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposVia",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVia", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposZona",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
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
                    table.PrimaryKey("PK_TiposZona", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Titulos",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Tramites",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramites", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Ubigeos",
                schema: "comun",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubigeos", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedida",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedidaVenta",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedidaVenta", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesNegocio",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParentCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesNegocio", x => x.Code);
                    table.ForeignKey(
                        name: "FK_UnidadesNegocio_UnidadesNegocio_ParentCode",
                        column: x => x.ParentCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesNegocio",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerbosActividad",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbosActividad", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SubCentrosEjecutores",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CentroEjecutorCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCentrosEjecutores", x => x.Code);
                    table.ForeignKey(
                        name: "FK_SubCentrosEjecutores_CentrosEjecutores_CentroEjecutorCode",
                        column: x => x.CentroEjecutorCode,
                        principalSchema: "mantenimiento",
                        principalTable: "CentrosEjecutores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubFamilias",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    FamiliaCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFamilias", x => x.Code);
                    table.ForeignKey(
                        name: "FK_SubFamilias_Familias_FamiliaCode",
                        column: x => x.FamiliaCode,
                        principalSchema: "logistica",
                        principalTable: "Familias",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Submodulos",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tooltip = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submodulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submodulos_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalSchema: "admin",
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentrosCosto",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlantaCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosCosto", x => x.Code);
                    table.ForeignKey(
                        name: "FK_CentrosCosto_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ControlCierres",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    PeriodCode = table.Column<string>(type: "char(6)", nullable: false),
                    ClosureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DifferenceAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCierres", x => new { x.PlantaCode, x.PeriodCode });
                    table.ForeignKey(
                        name: "FK_ControlCierres_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalisisVentas",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SegmentoVentasCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisisVentas", x => x.Code);
                    table.ForeignKey(
                        name: "FK_AnalisisVentas_SegmentosVentas_SegmentoVentasCode",
                        column: x => x.SegmentoVentasCode,
                        principalSchema: "facturacion",
                        principalTable: "SegmentosVentas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conductores",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(5)", nullable: false),
                    DocumentTypeCode = table.Column<string>(type: "char(2)", maxLength: 3, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LicenseCategory = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Conductores_TiposDocumento_DocumentTypeCode",
                        column: x => x.DocumentTypeCode,
                        principalSchema: "comun",
                        principalTable: "TiposDocumento",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(5)", nullable: false),
                    DocumentTypeCode = table.Column<string>(type: "char(2)", maxLength: 3, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TradeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ProviderType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SunatCondition = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SunatStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeactivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Proveedores_TiposDocumento_DocumentTypeCode",
                        column: x => x.DocumentTypeCode,
                        principalSchema: "comun",
                        principalTable: "TiposDocumento",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(5)", nullable: false),
                    PersonType = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeCode = table.Column<string>(type: "char(2)", maxLength: 3, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentClientCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: true),
                    TipoClienteCode = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    ClasificacionClienteCode = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    LegalRepresentativeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegalRepresentativePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LegalRepresentativeDni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsVip = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RequiresCashOnly = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HasGlobalCreditLine = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    GlobalCreditAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RequiresPurchaseOrderApproval = table.Column<bool>(type: "bit", nullable: true),
                    RequiresWorkOrderApproval = table.Column<bool>(type: "bit", nullable: true),
                    FormaPagoVentaCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    CurrencyCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    RequiresManagementApproval = table.Column<bool>(type: "bit", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Clientes_ClasificacionesCliente_ClasificacionClienteCode",
                        column: x => x.ClasificacionClienteCode,
                        principalSchema: "facturacion",
                        principalTable: "ClasificacionesCliente",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Clientes_ParentClientCode",
                        column: x => x.ParentClientCode,
                        principalSchema: "facturacion",
                        principalTable: "Clientes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_FormasPagoVenta_FormaPagoVentaCode",
                        column: x => x.FormaPagoVentaCode,
                        principalSchema: "facturacion",
                        principalTable: "FormasPagoVenta",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Monedas_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_TiposCliente_TipoClienteCode",
                        column: x => x.TipoClienteCode,
                        principalSchema: "facturacion",
                        principalTable: "TiposCliente",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_TiposDocumento_DocumentTypeCode",
                        column: x => x.DocumentTypeCode,
                        principalSchema: "comun",
                        principalTable: "TiposDocumento",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Ubigeos_UbigeoCode",
                        column: x => x.UbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(5)", nullable: false),
                    FirstNames = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    PaternalSurname = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    MaternalSurname = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    SexoCode = table.Column<string>(type: "char(3)", maxLength: 10, nullable: true),
                    EstadoCivilCode = table.Column<string>(type: "char(3)", maxLength: 10, nullable: true),
                    NacionalidadCode = table.Column<string>(type: "char(3)", maxLength: 10, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BirthUbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    HasDisability = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Trabajadores_EstadosCiviles_EstadoCivilCode",
                        column: x => x.EstadoCivilCode,
                        principalSchema: "rrhh",
                        principalTable: "EstadosCiviles",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trabajadores_Nacionalidades_NacionalidadCode",
                        column: x => x.NacionalidadCode,
                        principalSchema: "rrhh",
                        principalTable: "Nacionalidades",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trabajadores_Sexos_SexoCode",
                        column: x => x.SexoCode,
                        principalSchema: "rrhh",
                        principalTable: "Sexos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trabajadores_Ubigeos_BirthUbigeoCode",
                        column: x => x.BirthUbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transportistas",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(5)", nullable: false),
                    DocumentTypeCode = table.Column<string>(type: "char(2)", maxLength: 3, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TradeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MtcRegistrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsOwnFleet = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportistas", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Transportistas_TiposDocumento_DocumentTypeCode",
                        column: x => x.DocumentTypeCode,
                        principalSchema: "comun",
                        principalTable: "TiposDocumento",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transportistas_Ubigeos_UbigeoCode",
                        column: x => x.UbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportistasVentas",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    DocumentTypeCode = table.Column<string>(type: "char(2)", maxLength: 3, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MtcInternalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportistasVentas", x => x.Code);
                    table.ForeignKey(
                        name: "FK_TransportistasVentas_TiposDocumento_DocumentTypeCode",
                        column: x => x.DocumentTypeCode,
                        principalSchema: "comun",
                        principalTable: "TiposDocumento",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportistasVentas_Ubigeos_UbigeoCode",
                        column: x => x.UbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "facturacion",
                columns: table => new
                {
                    TipoProductoCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UnitCode = table.Column<string>(type: "char(2)", maxLength: 5, nullable: false),
                    AccountingAccountCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TransportAccountCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    CreditNoteAccountCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    LengthLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TransportTipoProductoCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    TransportCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    CategoryCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    StrengthCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    CementTypeCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    StoneSizeCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    SlumpCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    WaterCementRatioCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    AgeCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    SpecialConditionCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    MixProportionCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    IsPumpable = table.Column<bool>(type: "bit", nullable: false),
                    IsSubjectToDetraction = table.Column<bool>(type: "bit", nullable: false),
                    GoodsTypeCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    OperationTypeCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    CementValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => new { x.TipoProductoCode, x.Code });
                    table.ForeignKey(
                        name: "FK_Productos_AtributosConcreto_AgeCode",
                        column: x => x.AgeCode,
                        principalSchema: "facturacion",
                        principalTable: "AtributosConcreto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_AtributosConcreto_CementTypeCode",
                        column: x => x.CementTypeCode,
                        principalSchema: "facturacion",
                        principalTable: "AtributosConcreto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_AtributosConcreto_MixProportionCode",
                        column: x => x.MixProportionCode,
                        principalSchema: "facturacion",
                        principalTable: "AtributosConcreto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_AtributosConcreto_SlumpCode",
                        column: x => x.SlumpCode,
                        principalSchema: "facturacion",
                        principalTable: "AtributosConcreto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_AtributosConcreto_SpecialConditionCode",
                        column: x => x.SpecialConditionCode,
                        principalSchema: "facturacion",
                        principalTable: "AtributosConcreto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_AtributosConcreto_StoneSizeCode",
                        column: x => x.StoneSizeCode,
                        principalSchema: "facturacion",
                        principalTable: "AtributosConcreto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_AtributosConcreto_StrengthCode",
                        column: x => x.StrengthCode,
                        principalSchema: "facturacion",
                        principalTable: "AtributosConcreto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_AtributosConcreto_WaterCementRatioCode",
                        column: x => x.WaterCementRatioCode,
                        principalSchema: "facturacion",
                        principalTable: "AtributosConcreto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_CategoriasProducto_CategoryCode",
                        column: x => x.CategoryCode,
                        principalSchema: "facturacion",
                        principalTable: "CategoriasProducto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Productos_TransportTipoProductoCode_TransportCode",
                        columns: x => new { x.TransportTipoProductoCode, x.TransportCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_TiposBien_GoodsTypeCode",
                        column: x => x.GoodsTypeCode,
                        principalSchema: "facturacion",
                        principalTable: "TiposBien",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_TiposOperacion_OperationTypeCode",
                        column: x => x.OperationTypeCode,
                        principalSchema: "facturacion",
                        principalTable: "TiposOperacion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_TiposProducto_TipoProductoCode",
                        column: x => x.TipoProductoCode,
                        principalSchema: "facturacion",
                        principalTable: "TiposProducto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_UnidadesMedidaVenta_UnitCode",
                        column: x => x.UnitCode,
                        principalSchema: "facturacion",
                        principalTable: "UnidadesMedidaVenta",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RangosAprobacion",
                schema: "logistica",
                columns: table => new
                {
                    NivelCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    TipoTransaccionCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    UnidadNegocioCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    ImporteMinimo = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    ImporteMaximo = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    ImporteAcumuladoDiario = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    ImporteAcumuladoMensual = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    PorcentajeTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangosAprobacion", x => new { x.NivelCode, x.TipoTransaccionCode, x.UnidadNegocioCode, x.MonedaCode });
                    table.ForeignKey(
                        name: "FK_RangosAprobacion_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RangosAprobacion_Niveles_NivelCode",
                        column: x => x.NivelCode,
                        principalSchema: "logistica",
                        principalTable: "Niveles",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RangosAprobacion_TiposTransaccion_TipoTransaccionCode",
                        column: x => x.TipoTransaccionCode,
                        principalSchema: "logistica",
                        principalTable: "TiposTransaccion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RangosAprobacion_UnidadesNegocio_UnidadNegocioCode",
                        column: x => x.UnidadNegocioCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesNegocio",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cobradores",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobradores", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Cobradores_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUsers",
                schema: "admin",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUsers", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "admin",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUsers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Vendedores_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    VerboActividadCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    ObjetoActividadCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Actividades_ObjetosActividad_ObjetoActividadCode",
                        column: x => x.ObjetoActividadCode,
                        principalSchema: "mantenimiento",
                        principalTable: "ObjetosActividad",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividades_VerbosActividad_VerboActividadCode",
                        column: x => x.VerboActividadCode,
                        principalSchema: "mantenimiento",
                        principalTable: "VerbosActividad",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(7)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UnidadMedidaCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    SubFamiliaCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    MinStock = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    MaxStock = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    IncomingStock = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    LeadTimeDays = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    AbcClass = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    TipoArticuloCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    PlanCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    ManufacturerCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Observations = table.Column<string>(type: "varchar(max)", nullable: false, defaultValue: ""),
                    SalesTypeCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SalesProductCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    IsAgreement = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AccountingAccountCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    AccountingAttachmentTypeCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PlantOriginCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Articulos_PlanesArticulo_PlanCode",
                        column: x => x.PlanCode,
                        principalSchema: "logistica",
                        principalTable: "PlanesArticulo",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Plantas_PlantOriginCode",
                        column: x => x.PlantOriginCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_SubFamilias_SubFamiliaCode",
                        column: x => x.SubFamiliaCode,
                        principalSchema: "logistica",
                        principalTable: "SubFamilias",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_TiposArticulo_TipoArticuloCode",
                        column: x => x.TipoArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "TiposArticulo",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_UnidadesMedida_UnidadMedidaCode",
                        column: x => x.UnidadMedidaCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesMedida",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Programas",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmoduloId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tooltip = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Route = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programas_Submodulos_SubmoduloId",
                        column: x => x.SubmoduloId,
                        principalSchema: "admin",
                        principalTable: "Submodulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCentrosCosto",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    CentroCostoCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountingAccountCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    AccountingAttachmentTypeCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PlantaCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    ParentCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCentrosCosto", x => x.Code);
                    table.ForeignKey(
                        name: "FK_SubCentrosCosto_CentrosCosto_CentroCostoCode",
                        column: x => x.CentroCostoCode,
                        principalSchema: "logistica",
                        principalTable: "CentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubCentrosCosto_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubCentrosCosto_SubCentrosCosto_ParentCode",
                        column: x => x.ParentCode,
                        principalSchema: "logistica",
                        principalTable: "SubCentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorCondiciones",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    FormaPagoCode = table.Column<string>(type: "char(2)", nullable: false),
                    PaymentTermDays = table.Column<int>(type: "int", nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorCondiciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProveedorCondiciones_FormasPago_FormaPagoCode",
                        column: x => x.FormaPagoCode,
                        principalSchema: "logistica",
                        principalTable: "FormasPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProveedorCondiciones_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProveedorCondiciones_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorContactos",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorContactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProveedorContactos_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorCuentas",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    BancoCode = table.Column<string>(type: "char(3)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InterbankCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorCuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProveedorCuentas_Bancos_BancoCode",
                        column: x => x.BancoCode,
                        principalSchema: "comun",
                        principalTable: "Bancos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProveedorCuentas_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProveedorCuentas_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorDirecciones",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UbigeoCode = table.Column<string>(type: "char(6)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorDirecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProveedorDirecciones_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProveedorDirecciones_Ubigeos_UbigeoCode",
                        column: x => x.UbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                schema: "facturacion",
                columns: table => new
                {
                    ClienteCode = table.Column<string>(type: "char(5)", nullable: false),
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeliveryUbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BillingUbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    ResponsibleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResponsiblePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResponsibleEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FormaPagoVentaCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    CobradorCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    VendedorCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    AnalisisVentaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditCurrencyCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasSurcharge = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TipoValorizacionCode = table.Column<string>(type: "char(1)", maxLength: 1, nullable: true),
                    RequiresValorizacion = table.Column<bool>(type: "bit", nullable: true),
                    ScheduledWeekday = table.Column<int>(type: "int", nullable: true),
                    IsProject = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RequiresPrinting = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RequiresManagementApproval = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => new { x.ClienteCode, x.Code });
                    table.ForeignKey(
                        name: "FK_Obras_AnalisisVentas_AnalisisVentaCode",
                        column: x => x.AnalisisVentaCode,
                        principalSchema: "facturacion",
                        principalTable: "AnalisisVentas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obras_Clientes_ClienteCode",
                        column: x => x.ClienteCode,
                        principalSchema: "facturacion",
                        principalTable: "Clientes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obras_FormasPagoVenta_FormaPagoVentaCode",
                        column: x => x.FormaPagoVentaCode,
                        principalSchema: "facturacion",
                        principalTable: "FormasPagoVenta",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obras_Monedas_CreditCurrencyCode",
                        column: x => x.CreditCurrencyCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obras_TiposValorizacion_TipoValorizacionCode",
                        column: x => x.TipoValorizacionCode,
                        principalSchema: "facturacion",
                        principalTable: "TiposValorizacion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obras_Ubigeos_BillingUbigeoCode",
                        column: x => x.BillingUbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obras_Ubigeos_DeliveryUbigeoCode",
                        column: x => x.DeliveryUbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obras_Ubigeos_UbigeoCode",
                        column: x => x.UbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_antecedente",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    TieneAntecedentes = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_antecedente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_antecedente_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_beneficio",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    Cts = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Gratificacion = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Vacaciones = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MovilidadAntesEntrada = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MovilidadDespuesSalida = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Refrigerio = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Cena = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Vale = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_beneficio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_beneficio_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_contable",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    NumeroItem = table.Column<int>(type: "int", nullable: false),
                    CuentaContable = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Porcentaje = table.Column<decimal>(type: "decimal(7,4)", nullable: false, defaultValue: 0m),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_contable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_contable_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_contrato",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    TipoContratoCode = table.Column<string>(type: "char(3)", nullable: true),
                    TipoExtensionCode = table.Column<string>(type: "char(3)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaTermino = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Renovado = table.Column<bool>(type: "bit", nullable: true),
                    TipoDuracion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CantidadDuracion = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_contrato_TiposContrato_TipoContratoCode",
                        column: x => x.TipoContratoCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposContrato",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_contrato_TiposExtensionContrato_TipoExtensionCode",
                        column: x => x.TipoExtensionCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposExtensionContrato",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_contrato_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_cuenta_bancaria",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    TipoCuentaCode = table.Column<string>(type: "char(3)", nullable: true),
                    BancoCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TipoOperacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_cuenta_bancaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_cuenta_bancaria_Bancos_BancoCode",
                        column: x => x.BancoCode,
                        principalSchema: "comun",
                        principalTable: "Bancos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_cuenta_bancaria_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_cuenta_bancaria_TiposCuenta_TipoCuentaCode",
                        column: x => x.TipoCuentaCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposCuenta",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_cuenta_bancaria_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_dependiente",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentescoCode = table.Column<string>(type: "char(3)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Asegurado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_dependiente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_dependiente_Parentescos_ParentescoCode",
                        column: x => x.ParentescoCode,
                        principalSchema: "rrhh",
                        principalTable: "Parentescos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_dependiente_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_fiscal",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    ConInmTrabajador = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Domiciliado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    OtrosIngresosQuinta = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RentaQuintaExonerada = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MadreResFamiliar = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_fiscal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_fiscal_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_formacion",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    NivelEducativoCode = table.Column<string>(type: "char(3)", nullable: true),
                    GradoInstruccionCode = table.Column<string>(type: "char(3)", nullable: true),
                    TituloCode = table.Column<string>(type: "char(3)", nullable: true),
                    EspecialidadCode = table.Column<string>(type: "char(3)", nullable: true),
                    TipoCentroFormacionCode = table.Column<string>(type: "char(3)", nullable: true),
                    ModalidadFormativaCode = table.Column<string>(type: "char(3)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_formacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_formacion_Especialidades_EspecialidadCode",
                        column: x => x.EspecialidadCode,
                        principalSchema: "rrhh",
                        principalTable: "Especialidades",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_formacion_GradosInstruccion_GradoInstruccionCode",
                        column: x => x.GradoInstruccionCode,
                        principalSchema: "rrhh",
                        principalTable: "GradosInstruccion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_formacion_ModalidadesFormativas_ModalidadFormativaCode",
                        column: x => x.ModalidadFormativaCode,
                        principalSchema: "rrhh",
                        principalTable: "ModalidadesFormativas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_formacion_NivelesEducativos_NivelEducativoCode",
                        column: x => x.NivelEducativoCode,
                        principalSchema: "rrhh",
                        principalTable: "NivelesEducativos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_formacion_TiposCentroFormacion_TipoCentroFormacionCode",
                        column: x => x.TipoCentroFormacionCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposCentroFormacion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_formacion_Titulos_TituloCode",
                        column: x => x.TituloCode,
                        principalSchema: "rrhh",
                        principalTable: "Titulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_formacion_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_jornada",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    HorarioCode = table.Column<string>(type: "char(3)", nullable: true),
                    HorasExtras = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HorasExt40 = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HorasExtCon = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HorasExtCon125 = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    HorasExtCon135 = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m),
                    ControlHorario = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HorarioOrdinario = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HorarioNocturno = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    JornadaMaxima = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RegimenAlternativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_jornada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_jornada_Horarios_HorarioCode",
                        column: x => x.HorarioCode,
                        principalSchema: "rrhh",
                        principalTable: "Horarios",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_jornada_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_laboral",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCese = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoTrabajadorCode = table.Column<string>(type: "char(3)", nullable: true),
                    CategoriaTrabajadorCode = table.Column<string>(type: "char(3)", nullable: true),
                    EstadoTrabajadorCode = table.Column<string>(type: "char(3)", nullable: true),
                    AreaCode = table.Column<string>(type: "char(3)", nullable: true),
                    OcupacionCode = table.Column<string>(type: "char(3)", nullable: true),
                    SubOcupacionCode = table.Column<string>(type: "char(3)", nullable: true),
                    CategoriaOcupacionalCode = table.Column<string>(type: "char(3)", nullable: true),
                    SubCategoriaOcupacionalCode = table.Column<string>(type: "char(3)", nullable: true),
                    OficinaCode = table.Column<string>(type: "char(3)", nullable: true),
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: true),
                    CargoCode = table.Column<string>(type: "char(3)", nullable: true),
                    NivelCode = table.Column<string>(type: "char(3)", nullable: true),
                    RegimenLaboralCode = table.Column<string>(type: "char(3)", nullable: true),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: true),
                    Permanente = table.Column<bool>(type: "bit", nullable: true),
                    Pensionista = table.Column<bool>(type: "bit", nullable: true),
                    TipoPersonalCode = table.Column<string>(type: "char(3)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_laboral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_Areas_AreaCode",
                        column: x => x.AreaCode,
                        principalSchema: "rrhh",
                        principalTable: "Areas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_Cargos_CargoCode",
                        column: x => x.CargoCode,
                        principalSchema: "rrhh",
                        principalTable: "Cargos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_CategoriasOcupacionales_CategoriaOcupacionalCode",
                        column: x => x.CategoriaOcupacionalCode,
                        principalSchema: "rrhh",
                        principalTable: "CategoriasOcupacionales",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_CategoriasTrabajador_CategoriaTrabajadorCode",
                        column: x => x.CategoriaTrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "CategoriasTrabajador",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_EstadosTrabajador_EstadoTrabajadorCode",
                        column: x => x.EstadoTrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "EstadosTrabajador",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_NivelesTrabajador_NivelCode",
                        column: x => x.NivelCode,
                        principalSchema: "rrhh",
                        principalTable: "NivelesTrabajador",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_Ocupaciones_OcupacionCode",
                        column: x => x.OcupacionCode,
                        principalSchema: "rrhh",
                        principalTable: "Ocupaciones",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_Oficinas_OficinaCode",
                        column: x => x.OficinaCode,
                        principalSchema: "rrhh",
                        principalTable: "Oficinas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_RegimenesLaborales_RegimenLaboralCode",
                        column: x => x.RegimenLaboralCode,
                        principalSchema: "rrhh",
                        principalTable: "RegimenesLaborales",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_SubCategoriasOcupacionales_SubCategoriaOcupacionalCode",
                        column: x => x.SubCategoriaOcupacionalCode,
                        principalSchema: "rrhh",
                        principalTable: "SubCategoriasOcupacionales",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_SubOcupaciones_SubOcupacionCode",
                        column: x => x.SubOcupacionCode,
                        principalSchema: "rrhh",
                        principalTable: "SubOcupaciones",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_TiposPersonal_TipoPersonalCode",
                        column: x => x.TipoPersonalCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposPersonal",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_TiposTrabajador_TipoTrabajadorCode",
                        column: x => x.TipoTrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposTrabajador",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_laboral_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_pension",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    TipoAfiliacionCode = table.Column<string>(type: "char(3)", nullable: true),
                    AfpCode = table.Column<string>(type: "char(3)", nullable: true),
                    FechaAfiliacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroAfp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RegimenPensionarioCode = table.Column<string>(type: "char(3)", nullable: true),
                    TipoPensionCode = table.Column<string>(type: "char(3)", nullable: true),
                    NumeroCarnetSsp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_pension", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_pension_Afps_AfpCode",
                        column: x => x.AfpCode,
                        principalSchema: "rrhh",
                        principalTable: "Afps",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_pension_RegimenesPensionarios_RegimenPensionarioCode",
                        column: x => x.RegimenPensionarioCode,
                        principalSchema: "rrhh",
                        principalTable: "RegimenesPensionarios",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_pension_TiposAfiliacion_TipoAfiliacionCode",
                        column: x => x.TipoAfiliacionCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposAfiliacion",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_pension_TiposPension_TipoPensionCode",
                        column: x => x.TipoPensionCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposPension",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_pension_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_remuneracion",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    SueldoBasico = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    ModoPagoCode = table.Column<string>(type: "char(3)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_remuneracion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_remuneracion_ModosPago_ModoPagoCode",
                        column: x => x.ModoPagoCode,
                        principalSchema: "rrhh",
                        principalTable: "ModosPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_remuneracion_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_remuneracion_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_salud",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    TipoSangreCode = table.Column<string>(type: "char(3)", nullable: true),
                    AlergiaCode = table.Column<string>(type: "char(3)", nullable: true),
                    Otros = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaEvaluacionMedica = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_salud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_salud_Alergias_AlergiaCode",
                        column: x => x.AlergiaCode,
                        principalSchema: "rrhh",
                        principalTable: "Alergias",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_salud_TiposSangre_TipoSangreCode",
                        column: x => x.TipoSangreCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposSangre",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_salud_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_seguro",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    EpsCode = table.Column<string>(type: "char(3)", nullable: true),
                    SituacionEpsCode = table.Column<string>(type: "char(3)", nullable: true),
                    TipoSeguroMedicoCode = table.Column<string>(type: "char(3)", nullable: true),
                    NumeroSeguro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SctrTipoCode = table.Column<string>(type: "char(3)", nullable: true),
                    SctrSaludCode = table.Column<string>(type: "char(3)", nullable: true),
                    SctrPensionCode = table.Column<string>(type: "char(3)", nullable: true),
                    EpsActivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SeguroMedico = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EssaludVida = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_seguro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_seguro_Eps_EpsCode",
                        column: x => x.EpsCode,
                        principalSchema: "rrhh",
                        principalTable: "Eps",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_seguro_SctrPension_SctrPensionCode",
                        column: x => x.SctrPensionCode,
                        principalSchema: "rrhh",
                        principalTable: "SctrPension",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_seguro_SctrSalud_SctrSaludCode",
                        column: x => x.SctrSaludCode,
                        principalSchema: "rrhh",
                        principalTable: "SctrSalud",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_seguro_SituacionesEps_SituacionEpsCode",
                        column: x => x.SituacionEpsCode,
                        principalSchema: "rrhh",
                        principalTable: "SituacionesEps",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_seguro_TiposSctr_SctrTipoCode",
                        column: x => x.SctrTipoCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposSctr",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_seguro_TiposSeguroMedico_TipoSeguroMedicoCode",
                        column: x => x.TipoSeguroMedicoCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposSeguroMedico",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trabajador_seguro_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_sindicato",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    Afiliado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_sindicato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_sindicato_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trabajador_vacacion",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    FechaVacaciones = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajador_vacacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trabajador_vacacion_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrabajadorContactos",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ParentescoCode = table.Column<string>(type: "char(3)", maxLength: 10, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrabajadorContactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrabajadorContactos_Parentescos_ParentescoCode",
                        column: x => x.ParentescoCode,
                        principalSchema: "rrhh",
                        principalTable: "Parentescos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrabajadorContactos_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrabajadorDocumentos",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    TipoDocumentoCode = table.Column<string>(type: "char(2)", maxLength: 20, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrabajadorDocumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrabajadorDocumentos_TiposDocumento_TipoDocumentoCode",
                        column: x => x.TipoDocumentoCode,
                        principalSchema: "comun",
                        principalTable: "TiposDocumento",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrabajadorDocumentos_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrabajadorDomicilios",
                schema: "rrhh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabajadorCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    RoadTypeCode = table.Column<string>(type: "char(3)", maxLength: 10, nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InteriorNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ZoneTypeCode = table.Column<string>(type: "char(3)", maxLength: 10, nullable: true),
                    ZoneName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrabajadorDomicilios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrabajadorDomicilios_TiposVia_RoadTypeCode",
                        column: x => x.RoadTypeCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposVia",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrabajadorDomicilios_TiposZona_ZoneTypeCode",
                        column: x => x.ZoneTypeCode,
                        principalSchema: "rrhh",
                        principalTable: "TiposZona",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrabajadorDomicilios_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrabajadorDomicilios_Ubigeos_UbigeoCode",
                        column: x => x.UbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(5)", nullable: false),
                    TransportistaCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VehicleCategory = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManufactureYear = table.Column<short>(type: "smallint", nullable: true),
                    EngineNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CargoCapacityKg = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    LengthM = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    WidthM = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    HeightM = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    VehicularCertificateNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CirculationCardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VehicularConfiguration = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Transportistas_TransportistaCode",
                        column: x => x.TransportistaCode,
                        principalSchema: "logistica",
                        principalTable: "Transportistas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChoferesVentas",
                schema: "facturacion",
                columns: table => new
                {
                    TransportistaCode = table.Column<string>(type: "char(4)", nullable: false),
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoferesVentas", x => new { x.TransportistaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_ChoferesVentas_TransportistasVentas_TransportistaCode",
                        column: x => x.TransportistaCode,
                        principalSchema: "facturacion",
                        principalTable: "TransportistasVentas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListasPrecios",
                schema: "facturacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProductoCode = table.Column<string>(type: "char(2)", nullable: false),
                    ProductoCode = table.Column<string>(type: "char(4)", nullable: false),
                    ProductoTipoProductoCode = table.Column<string>(type: "char(2)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasPrecios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListasPrecios_Productos_ProductoTipoProductoCode_ProductoCode",
                        columns: x => new { x.ProductoTipoProductoCode, x.ProductoCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListasPrecios_Productos_TipoProductoCode_ProductoCode",
                        columns: x => new { x.TipoProductoCode, x.ProductoCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockProductos",
                schema: "facturacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    TipoProductoCode = table.Column<string>(type: "char(2)", nullable: false),
                    ProductoCode = table.Column<string>(type: "char(4)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockProductos_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockProductos_Productos_TipoProductoCode_ProductoCode",
                        columns: x => new { x.TipoProductoCode, x.ProductoCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AprobadoresAsignados",
                schema: "logistica",
                columns: table => new
                {
                    NivelCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    TipoTransaccionCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    UnidadNegocioCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    SuplenteTrabajadorCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SuperiorTrabajadorCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AprobadoresAsignados", x => new { x.NivelCode, x.TipoTransaccionCode, x.UnidadNegocioCode, x.MonedaCode, x.TrabajadorCode });
                    table.ForeignKey(
                        name: "FK_AprobadoresAsignados_RangosAprobacion_NivelCode_TipoTransaccionCode_UnidadNegocioCode_MonedaCode",
                        columns: x => new { x.NivelCode, x.TipoTransaccionCode, x.UnidadNegocioCode, x.MonedaCode },
                        principalSchema: "logistica",
                        principalTable: "RangosAprobacion",
                        principalColumns: new[] { "NivelCode", "TipoTransaccionCode", "UnidadNegocioCode", "MonedaCode" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AprobadoresAsignados_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticuloProveedor",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    IsAgreement = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AgreementPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloProveedor", x => new { x.PlantaCode, x.ArticuloCode, x.ProveedorCode });
                    table.ForeignKey(
                        name: "FK_ArticuloProveedor_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticuloProveedor_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticuloProveedor_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockArticulos",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    UnitCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    UnitCostUsd = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    AverageCost = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MinStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    MaxStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockArticulos", x => new { x.PlantaCode, x.ArticuloCode });
                    table.CheckConstraint("CK_StockArticulos_Quantity_NonNegative", "[Quantity] >= 0");
                    table.ForeignKey(
                        name: "FK_StockArticulos_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockArticulos_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramaId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalSchema: "admin",
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(8)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    SubCentroCostoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Equipos_SubCentrosCosto_SubCentroCostoCode",
                        column: x => x.SubCentroCostoCode,
                        principalSchema: "logistica",
                        principalTable: "SubCentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                schema: "facturacion",
                columns: table => new
                {
                    TransportistaCode = table.Column<string>(type: "char(4)", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "char(4)", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChoferCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    Capacity = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    Suple = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    LengthM = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    WidthM = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    HeightM = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    Telescopic = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    WithoutSuple = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    WithSuple = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    CubicWithoutSuple = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    CubicWithSuple = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    MtcInternalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VehicularConfiguration = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PlanillaCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => new { x.TransportistaCode, x.VehicleType, x.Code });
                    table.ForeignKey(
                        name: "FK_Vehiculos_ChoferesVentas_TransportistaCode_ChoferCode",
                        columns: x => new { x.TransportistaCode, x.ChoferCode },
                        principalSchema: "facturacion",
                        principalTable: "ChoferesVentas",
                        principalColumns: new[] { "TransportistaCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculos_TransportistasVentas_TransportistaCode",
                        column: x => x.TransportistaCode,
                        principalSchema: "facturacion",
                        principalTable: "TransportistasVentas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRoles",
                schema: "admin",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRoles", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "admin",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "admin",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesTrabajo",
                schema: "mantenimiento",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaTermino = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponsableCode = table.Column<string>(type: "char(5)", nullable: false),
                    EspecialidadCode = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    OportunidadCode = table.Column<string>(type: "char(4)", maxLength: 2, nullable: false),
                    EquipoCode = table.Column<string>(type: "char(8)", maxLength: 8, nullable: false),
                    PrioridadCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    InspeccionCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    TipoOrdenCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    ActividadCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    SubCentroCostoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: true),
                    SubCentroEjecutorCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    PlanMantenimientoPreventivoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DowntimeHours = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Horometro = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesTrabajo", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_Actividades_ActividadCode",
                        column: x => x.ActividadCode,
                        principalSchema: "mantenimiento",
                        principalTable: "Actividades",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_Equipos_EquipoCode",
                        column: x => x.EquipoCode,
                        principalSchema: "mantenimiento",
                        principalTable: "Equipos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_Especialidades_EspecialidadCode",
                        column: x => x.EspecialidadCode,
                        principalSchema: "mantenimiento",
                        principalTable: "Especialidades",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_Inspecciones_InspeccionCode",
                        column: x => x.InspeccionCode,
                        principalSchema: "mantenimiento",
                        principalTable: "Inspecciones",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_Oportunidades_OportunidadCode",
                        column: x => x.OportunidadCode,
                        principalSchema: "mantenimiento",
                        principalTable: "Oportunidades",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_Prioridades_PrioridadCode",
                        column: x => x.PrioridadCode,
                        principalSchema: "mantenimiento",
                        principalTable: "Prioridades",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_SubCentrosCosto_SubCentroCostoCode",
                        column: x => x.SubCentroCostoCode,
                        principalSchema: "logistica",
                        principalTable: "SubCentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_SubCentrosEjecutores_SubCentroEjecutorCode",
                        column: x => x.SubCentroEjecutorCode,
                        principalSchema: "mantenimiento",
                        principalTable: "SubCentrosEjecutores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_TiposOrden_TipoOrdenCode",
                        column: x => x.TipoOrdenCode,
                        principalSchema: "mantenimiento",
                        principalTable: "TiposOrden",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_Trabajadores_ResponsableCode",
                        column: x => x.ResponsableCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OTResponsables",
                schema: "mantenimiento",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    OrdenTrabajoCode = table.Column<string>(type: "char(6)", nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    TiempoProceso = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    Basico = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CostoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTResponsables", x => new { x.PlantaCode, x.OrdenTrabajoCode, x.FechaProceso, x.TrabajadorCode });
                    table.ForeignKey(
                        name: "FK_OTResponsables_OrdenesTrabajo_PlantaCode_OrdenTrabajoCode",
                        columns: x => new { x.PlantaCode, x.OrdenTrabajoCode },
                        principalSchema: "mantenimiento",
                        principalTable: "OrdenesTrabajo",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OTResponsables_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OTRMaquinas",
                schema: "mantenimiento",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    OrdenTrabajoCode = table.Column<string>(type: "char(6)", nullable: false),
                    MaquinaCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    Horas = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTRMaquinas", x => new { x.PlantaCode, x.OrdenTrabajoCode, x.MaquinaCode });
                    table.ForeignKey(
                        name: "FK_OTRMaquinas_Maquinas_MaquinaCode",
                        column: x => x.MaquinaCode,
                        principalSchema: "mantenimiento",
                        principalTable: "Maquinas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OTRMaquinas_OrdenesTrabajo_PlantaCode_OrdenTrabajoCode",
                        columns: x => new { x.PlantaCode, x.OrdenTrabajoCode },
                        principalSchema: "mantenimiento",
                        principalTable: "OrdenesTrabajo",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OTRMateriales",
                schema: "mantenimiento",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    OrdenTrabajoCode = table.Column<string>(type: "char(6)", nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", maxLength: 7, nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    CostoUnitario = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    CostoTotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    EstadoCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTRMateriales", x => new { x.PlantaCode, x.OrdenTrabajoCode, x.FechaProceso, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_OTRMateriales_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OTRMateriales_OrdenesTrabajo_PlantaCode_OrdenTrabajoCode",
                        columns: x => new { x.PlantaCode, x.OrdenTrabajoCode },
                        principalSchema: "mantenimiento",
                        principalTable: "OrdenesTrabajo",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_ObjetoActividadCode",
                schema: "mantenimiento",
                table: "Actividades",
                column: "ObjetoActividadCode");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_VerboActividadCode",
                schema: "mantenimiento",
                table: "Actividades",
                column: "VerboActividadCode");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisVentas_Name",
                schema: "facturacion",
                table: "AnalisisVentas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisVentas_SegmentoVentasCode",
                schema: "facturacion",
                table: "AnalisisVentas",
                column: "SegmentoVentasCode");

            migrationBuilder.CreateIndex(
                name: "IX_AprobadoresAsignados_TrabajadorCode",
                schema: "logistica",
                table: "AprobadoresAsignados",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloProveedor_ArticuloCode",
                schema: "logistica",
                table: "ArticuloProveedor",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloProveedor_ProveedorCode",
                schema: "logistica",
                table: "ArticuloProveedor",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_PlanCode",
                schema: "logistica",
                table: "Articulos",
                column: "PlanCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_PlantOriginCode",
                schema: "logistica",
                table: "Articulos",
                column: "PlantOriginCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_SubFamiliaCode",
                schema: "logistica",
                table: "Articulos",
                column: "SubFamiliaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_TipoArticuloCode",
                schema: "logistica",
                table: "Articulos",
                column: "TipoArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_UnidadMedidaCode",
                schema: "logistica",
                table: "Articulos",
                column: "UnidadMedidaCode");

            migrationBuilder.CreateIndex(
                name: "IX_AtributosConcreto_AttributeType",
                schema: "facturacion",
                table: "AtributosConcreto",
                column: "AttributeType");

            migrationBuilder.CreateIndex(
                name: "IX_CentrosCosto_PlantaCode",
                schema: "logistica",
                table: "CentrosCosto",
                column: "PlantaCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionesCliente_Name",
                schema: "facturacion",
                table: "ClasificacionesCliente",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ClasificacionClienteCode",
                schema: "facturacion",
                table: "Clientes",
                column: "ClasificacionClienteCode");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CurrencyCode",
                schema: "facturacion",
                table: "Clientes",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DocumentNumber",
                schema: "facturacion",
                table: "Clientes",
                column: "DocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DocumentTypeCode",
                schema: "facturacion",
                table: "Clientes",
                column: "DocumentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Estado",
                schema: "facturacion",
                table: "Clientes",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FormaPagoVentaCode",
                schema: "facturacion",
                table: "Clientes",
                column: "FormaPagoVentaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Name",
                schema: "facturacion",
                table: "Clientes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ParentClientCode",
                schema: "facturacion",
                table: "Clientes",
                column: "ParentClientCode");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoClienteCode",
                schema: "facturacion",
                table: "Clientes",
                column: "TipoClienteCode");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UbigeoCode",
                schema: "facturacion",
                table: "Clientes",
                column: "UbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cobradores_UserId",
                schema: "facturacion",
                table: "Cobradores",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesPago_Code",
                schema: "comun",
                table: "ComprobantesPago",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesPago_SunatCode",
                schema: "comun",
                table: "ComprobantesPago",
                column: "SunatCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conductores_DocumentTypeCode_DocumentNumber",
                schema: "logistica",
                table: "Conductores",
                columns: new[] { "DocumentTypeCode", "DocumentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conductores_DriverLicenseNumber",
                schema: "logistica",
                table: "Conductores",
                column: "DriverLicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_SubCentroCostoCode",
                schema: "mantenimiento",
                table: "Equipos",
                column: "SubCentroCostoCode");

            migrationBuilder.CreateIndex(
                name: "IX_EstadosCiviles_Name",
                schema: "rrhh",
                table: "EstadosCiviles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormasPagoVenta_Name",
                schema: "facturacion",
                table: "FormasPagoVenta",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListasPrecios_ProductoTipoProductoCode_ProductoCode",
                schema: "facturacion",
                table: "ListasPrecios",
                columns: new[] { "ProductoTipoProductoCode", "ProductoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_ListasPrecios_TipoProductoCode_ProductoCode",
                schema: "facturacion",
                table: "ListasPrecios",
                columns: new[] { "TipoProductoCode", "ProductoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_Code",
                schema: "admin",
                table: "Modulos",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_Name",
                schema: "admin",
                table: "Modulos",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monedas_Code",
                schema: "comun",
                table: "Monedas",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monedas_NumericCode",
                schema: "comun",
                table: "Monedas",
                column: "NumericCode",
                unique: true,
                filter: "[NumericCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MotivosDevolucion_Code",
                schema: "comun",
                table: "MotivosDevolucion",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nacionalidades_Name",
                schema: "rrhh",
                table: "Nacionalidades",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Obras_AnalisisVentaCode",
                schema: "facturacion",
                table: "Obras",
                column: "AnalisisVentaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_BillingUbigeoCode",
                schema: "facturacion",
                table: "Obras",
                column: "BillingUbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_CobradorCode",
                schema: "facturacion",
                table: "Obras",
                column: "CobradorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_CreditCurrencyCode",
                schema: "facturacion",
                table: "Obras",
                column: "CreditCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_DeliveryUbigeoCode",
                schema: "facturacion",
                table: "Obras",
                column: "DeliveryUbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_Estado",
                schema: "facturacion",
                table: "Obras",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_FormaPagoVentaCode",
                schema: "facturacion",
                table: "Obras",
                column: "FormaPagoVentaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_TipoValorizacionCode",
                schema: "facturacion",
                table: "Obras",
                column: "TipoValorizacionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_UbigeoCode",
                schema: "facturacion",
                table: "Obras",
                column: "UbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_VendedorCode",
                schema: "facturacion",
                table: "Obras",
                column: "VendedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_ActividadCode",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "ActividadCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_EquipoCode",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "EquipoCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_EspecialidadCode",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "EspecialidadCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_InspeccionCode",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "InspeccionCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_OportunidadCode",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "OportunidadCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_PrioridadCode",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "PrioridadCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_ResponsableCode",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "ResponsableCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_SubCentroCostoCode",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "SubCentroCostoCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_SubCentroEjecutorCode",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "SubCentroEjecutorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_TipoOrdenCode",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "TipoOrdenCode");

            migrationBuilder.CreateIndex(
                name: "IX_OTResponsables_TrabajadorCode",
                schema: "mantenimiento",
                table: "OTResponsables",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OTRMaquinas_MaquinaCode",
                schema: "mantenimiento",
                table: "OTRMaquinas",
                column: "MaquinaCode");

            migrationBuilder.CreateIndex(
                name: "IX_OTRMateriales_ArticuloCode",
                schema: "mantenimiento",
                table: "OTRMateriales",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRoles_PermissionId",
                schema: "admin",
                table: "PermissionRoles",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ProgramaId_Code",
                schema: "admin",
                table: "Permissions",
                columns: new[] { "ProgramaId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_Code",
                schema: "comun",
                table: "Plantas",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_AgeCode",
                schema: "facturacion",
                table: "Productos",
                column: "AgeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoryCode",
                schema: "facturacion",
                table: "Productos",
                column: "CategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CementTypeCode",
                schema: "facturacion",
                table: "Productos",
                column: "CementTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_GoodsTypeCode",
                schema: "facturacion",
                table: "Productos",
                column: "GoodsTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MixProportionCode",
                schema: "facturacion",
                table: "Productos",
                column: "MixProportionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_OperationTypeCode",
                schema: "facturacion",
                table: "Productos",
                column: "OperationTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SlumpCode",
                schema: "facturacion",
                table: "Productos",
                column: "SlumpCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SpecialConditionCode",
                schema: "facturacion",
                table: "Productos",
                column: "SpecialConditionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_StoneSizeCode",
                schema: "facturacion",
                table: "Productos",
                column: "StoneSizeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_StrengthCode",
                schema: "facturacion",
                table: "Productos",
                column: "StrengthCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TransportTipoProductoCode_TransportCode",
                schema: "facturacion",
                table: "Productos",
                columns: new[] { "TransportTipoProductoCode", "TransportCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UnitCode",
                schema: "facturacion",
                table: "Productos",
                column: "UnitCode");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_WaterCementRatioCode",
                schema: "facturacion",
                table: "Productos",
                column: "WaterCementRatioCode");

            migrationBuilder.CreateIndex(
                name: "IX_Programas_SubmoduloId_Code",
                schema: "admin",
                table: "Programas",
                columns: new[] { "SubmoduloId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programas_SubmoduloId_Name",
                schema: "admin",
                table: "Programas",
                columns: new[] { "SubmoduloId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCondiciones_FormaPagoCode",
                schema: "logistica",
                table: "ProveedorCondiciones",
                column: "FormaPagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCondiciones_MonedaCode",
                schema: "logistica",
                table: "ProveedorCondiciones",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCondiciones_ProveedorCode",
                schema: "logistica",
                table: "ProveedorCondiciones",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorContactos_ProveedorCode",
                schema: "logistica",
                table: "ProveedorContactos",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCuentas_BancoCode",
                schema: "logistica",
                table: "ProveedorCuentas",
                column: "BancoCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCuentas_MonedaCode",
                schema: "logistica",
                table: "ProveedorCuentas",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCuentas_ProveedorCode",
                schema: "logistica",
                table: "ProveedorCuentas",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorDirecciones_ProveedorCode",
                schema: "logistica",
                table: "ProveedorDirecciones",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorDirecciones_UbigeoCode",
                schema: "logistica",
                table: "ProveedorDirecciones",
                column: "UbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_DocumentNumber",
                schema: "logistica",
                table: "Proveedores",
                column: "DocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_DocumentTypeCode",
                schema: "logistica",
                table: "Proveedores",
                column: "DocumentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_LegalName",
                schema: "logistica",
                table: "Proveedores",
                column: "LegalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RangosAprobacion_MonedaCode",
                schema: "logistica",
                table: "RangosAprobacion",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_RangosAprobacion_TipoTransaccionCode",
                schema: "logistica",
                table: "RangosAprobacion",
                column: "TipoTransaccionCode");

            migrationBuilder.CreateIndex(
                name: "IX_RangosAprobacion_UnidadNegocioCode",
                schema: "logistica",
                table: "RangosAprobacion",
                column: "UnidadNegocioCode");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                schema: "admin",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "admin",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                schema: "admin",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_RoleId",
                schema: "admin",
                table: "RoleUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentosVentas_Name",
                schema: "facturacion",
                table: "SegmentosVentas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sexos_Name",
                schema: "rrhh",
                table: "Sexos",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockArticulos_ArticuloCode",
                schema: "logistica",
                table: "StockArticulos",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_StockProductos_PlantaCode_TipoProductoCode_ProductoCode",
                schema: "facturacion",
                table: "StockProductos",
                columns: new[] { "PlantaCode", "TipoProductoCode", "ProductoCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockProductos_TipoProductoCode_ProductoCode",
                schema: "facturacion",
                table: "StockProductos",
                columns: new[] { "TipoProductoCode", "ProductoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_SubCentrosCosto_CentroCostoCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                column: "CentroCostoCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCentrosCosto_ParentCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                column: "ParentCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCentrosCosto_PlantaCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                column: "PlantaCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCentrosEjecutores_CentroEjecutorCode",
                schema: "mantenimiento",
                table: "SubCentrosEjecutores",
                column: "CentroEjecutorCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubFamilias_FamiliaCode",
                schema: "logistica",
                table: "SubFamilias",
                column: "FamiliaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Submodulos_ModuloId_Code",
                schema: "admin",
                table: "Submodulos",
                columns: new[] { "ModuloId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submodulos_ModuloId_Name",
                schema: "admin",
                table: "Submodulos",
                columns: new[] { "ModuloId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposCambio_Date",
                schema: "comun",
                table: "TiposCambio",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposCliente_Name",
                schema: "facturacion",
                table: "TiposCliente",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposDocumento_Code",
                schema: "comun",
                table: "TiposDocumento",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposValorizacion_Name",
                schema: "facturacion",
                table: "TiposValorizacion",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_antecedente_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_antecedente",
                column: "TrabajadorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_beneficio_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_beneficio",
                column: "TrabajadorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_contable_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_contable",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_contrato_TipoContratoCode",
                schema: "rrhh",
                table: "trabajador_contrato",
                column: "TipoContratoCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_contrato_TipoExtensionCode",
                schema: "rrhh",
                table: "trabajador_contrato",
                column: "TipoExtensionCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_contrato_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_contrato",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_cuenta_bancaria_BancoCode",
                schema: "rrhh",
                table: "trabajador_cuenta_bancaria",
                column: "BancoCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_cuenta_bancaria_MonedaCode",
                schema: "rrhh",
                table: "trabajador_cuenta_bancaria",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_cuenta_bancaria_TipoCuentaCode",
                schema: "rrhh",
                table: "trabajador_cuenta_bancaria",
                column: "TipoCuentaCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_cuenta_bancaria_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_cuenta_bancaria",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_dependiente_ParentescoCode",
                schema: "rrhh",
                table: "trabajador_dependiente",
                column: "ParentescoCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_dependiente_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_dependiente",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_fiscal_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_fiscal",
                column: "TrabajadorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_formacion_EspecialidadCode",
                schema: "rrhh",
                table: "trabajador_formacion",
                column: "EspecialidadCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_formacion_GradoInstruccionCode",
                schema: "rrhh",
                table: "trabajador_formacion",
                column: "GradoInstruccionCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_formacion_ModalidadFormativaCode",
                schema: "rrhh",
                table: "trabajador_formacion",
                column: "ModalidadFormativaCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_formacion_NivelEducativoCode",
                schema: "rrhh",
                table: "trabajador_formacion",
                column: "NivelEducativoCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_formacion_TipoCentroFormacionCode",
                schema: "rrhh",
                table: "trabajador_formacion",
                column: "TipoCentroFormacionCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_formacion_TituloCode",
                schema: "rrhh",
                table: "trabajador_formacion",
                column: "TituloCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_formacion_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_formacion",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_jornada_HorarioCode",
                schema: "rrhh",
                table: "trabajador_jornada",
                column: "HorarioCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_jornada_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_jornada",
                column: "TrabajadorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_AreaCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "AreaCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_CargoCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "CargoCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_CategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "CategoriaOcupacionalCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_CategoriaTrabajadorCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "CategoriaTrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_EstadoTrabajadorCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "EstadoTrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_NivelCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "NivelCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_OcupacionCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "OcupacionCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_OficinaCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "OficinaCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_PlantaCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "PlantaCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_ProveedorCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_RegimenLaboralCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "RegimenLaboralCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_SubCategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "SubCategoriaOcupacionalCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_SubOcupacionCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "SubOcupacionCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_TipoPersonalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "TipoPersonalCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_TipoTrabajadorCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "TipoTrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "TrabajadorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_pension_AfpCode",
                schema: "rrhh",
                table: "trabajador_pension",
                column: "AfpCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_pension_RegimenPensionarioCode",
                schema: "rrhh",
                table: "trabajador_pension",
                column: "RegimenPensionarioCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_pension_TipoAfiliacionCode",
                schema: "rrhh",
                table: "trabajador_pension",
                column: "TipoAfiliacionCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_pension_TipoPensionCode",
                schema: "rrhh",
                table: "trabajador_pension",
                column: "TipoPensionCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_pension_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_pension",
                column: "TrabajadorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_remuneracion_ModoPagoCode",
                schema: "rrhh",
                table: "trabajador_remuneracion",
                column: "ModoPagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_remuneracion_MonedaCode",
                schema: "rrhh",
                table: "trabajador_remuneracion",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_remuneracion_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_remuneracion",
                column: "TrabajadorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_salud_AlergiaCode",
                schema: "rrhh",
                table: "trabajador_salud",
                column: "AlergiaCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_salud_TipoSangreCode",
                schema: "rrhh",
                table: "trabajador_salud",
                column: "TipoSangreCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_salud_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_salud",
                column: "TrabajadorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_seguro_EpsCode",
                schema: "rrhh",
                table: "trabajador_seguro",
                column: "EpsCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_seguro_SctrPensionCode",
                schema: "rrhh",
                table: "trabajador_seguro",
                column: "SctrPensionCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_seguro_SctrSaludCode",
                schema: "rrhh",
                table: "trabajador_seguro",
                column: "SctrSaludCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_seguro_SctrTipoCode",
                schema: "rrhh",
                table: "trabajador_seguro",
                column: "SctrTipoCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_seguro_SituacionEpsCode",
                schema: "rrhh",
                table: "trabajador_seguro",
                column: "SituacionEpsCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_seguro_TipoSeguroMedicoCode",
                schema: "rrhh",
                table: "trabajador_seguro",
                column: "TipoSeguroMedicoCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_seguro_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_seguro",
                column: "TrabajadorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_sindicato_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_sindicato",
                column: "TrabajadorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_vacacion_TrabajadorCode",
                schema: "rrhh",
                table: "trabajador_vacacion",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorContactos_ParentescoCode",
                schema: "rrhh",
                table: "TrabajadorContactos",
                column: "ParentescoCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorContactos_TrabajadorCode",
                schema: "rrhh",
                table: "TrabajadorContactos",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorDocumentos_TipoDocumentoCode_DocumentNumber",
                schema: "rrhh",
                table: "TrabajadorDocumentos",
                columns: new[] { "TipoDocumentoCode", "DocumentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorDocumentos_TrabajadorCode",
                schema: "rrhh",
                table: "TrabajadorDocumentos",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorDomicilios_RoadTypeCode",
                schema: "rrhh",
                table: "TrabajadorDomicilios",
                column: "RoadTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorDomicilios_TrabajadorCode",
                schema: "rrhh",
                table: "TrabajadorDomicilios",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorDomicilios_UbigeoCode",
                schema: "rrhh",
                table: "TrabajadorDomicilios",
                column: "UbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajadorDomicilios_ZoneTypeCode",
                schema: "rrhh",
                table: "TrabajadorDomicilios",
                column: "ZoneTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_BirthUbigeoCode",
                schema: "rrhh",
                table: "Trabajadores",
                column: "BirthUbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_EstadoCivilCode",
                schema: "rrhh",
                table: "Trabajadores",
                column: "EstadoCivilCode");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_NacionalidadCode",
                schema: "rrhh",
                table: "Trabajadores",
                column: "NacionalidadCode");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_SexoCode",
                schema: "rrhh",
                table: "Trabajadores",
                column: "SexoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Transportistas_DocumentTypeCode_DocumentNumber",
                schema: "logistica",
                table: "Transportistas",
                columns: new[] { "DocumentTypeCode", "DocumentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportistas_LegalName",
                schema: "logistica",
                table: "Transportistas",
                column: "LegalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportistas_UbigeoCode",
                schema: "logistica",
                table: "Transportistas",
                column: "UbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_TransportistasVentas_DocumentTypeCode_DocumentNumber",
                schema: "facturacion",
                table: "TransportistasVentas",
                columns: new[] { "DocumentTypeCode", "DocumentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportistasVentas_UbigeoCode",
                schema: "facturacion",
                table: "TransportistasVentas",
                column: "UbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Ubigeos_Code",
                schema: "comun",
                table: "Ubigeos",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ubigeos_Department_Province_District",
                schema: "comun",
                table: "Ubigeos",
                columns: new[] { "Department", "Province", "District" });

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesNegocio_ParentCode",
                schema: "logistica",
                table: "UnidadesNegocio",
                column: "ParentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "admin",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TransportistaCode_ChoferCode",
                schema: "facturacion",
                table: "Vehiculos",
                columns: new[] { "TransportistaCode", "ChoferCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TransportistaCode_LicensePlate",
                schema: "facturacion",
                table: "Vehiculos",
                columns: new[] { "TransportistaCode", "LicensePlate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_LicensePlate",
                schema: "logistica",
                table: "Vehiculos",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TransportistaCode",
                schema: "logistica",
                table: "Vehiculos",
                column: "TransportistaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedores_UserId",
                schema: "facturacion",
                table: "Vendedores",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AprobadoresAsignados",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ArticuloProveedor",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Cobradores",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "Compradores",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ComprobantesPago",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "Conductores",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ControlCierres",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ControlesVentas",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "ListasPrecios",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "LugaresEnvio",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "MotivosDevolucion",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "Negocios",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "NotasCompra",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Obras",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "OTResponsables",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "OTRMaquinas",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "OTRMateriales",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "PermissionRoles",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "ProveedorCondiciones",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ProveedorContactos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ProveedorCuentas",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ProveedorDirecciones",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "RoleUsers",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "StockArticulos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "StockProductos",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "TiposCambio",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "TiposCompra",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "TiposPedido",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "TiposVale",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "trabajador_antecedente",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_beneficio",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_contable",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_contrato",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_cuenta_bancaria",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_dependiente",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_fiscal",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_formacion",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_jornada",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_laboral",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_pension",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_remuneracion",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_salud",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_seguro",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_sindicato",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "trabajador_vacacion",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TrabajadorContactos",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TrabajadorDocumentos",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TrabajadorDomicilios",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Tramites",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Vehiculos",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "Vehiculos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Vendedores",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "RangosAprobacion",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "AnalisisVentas",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "TiposValorizacion",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "Maquinas",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "OrdenesTrabajo",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "FormasPago",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "Articulos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Productos",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "TiposContrato",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposExtensionContrato",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Bancos",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "TiposCuenta",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Especialidades",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "GradosInstruccion",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "ModalidadesFormativas",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "NivelesEducativos",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposCentroFormacion",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Titulos",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Horarios",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Areas",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Cargos",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "CategoriasOcupacionales",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "CategoriasTrabajador",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "EstadosTrabajador",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "NivelesTrabajador",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Ocupaciones",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Oficinas",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Proveedores",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "RegimenesLaborales",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "SubCategoriasOcupacionales",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "SubOcupaciones",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposPersonal",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposTrabajador",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Afps",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "RegimenesPensionarios",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposAfiliacion",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposPension",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "ModosPago",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Alergias",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposSangre",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Eps",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "SctrPension",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "SctrSalud",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "SituacionesEps",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposSctr",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposSeguroMedico",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Parentescos",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposVia",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "TiposZona",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "ChoferesVentas",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "Transportistas",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "Niveles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "TiposTransaccion",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "UnidadesNegocio",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "SegmentosVentas",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "ClasificacionesCliente",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "FormasPagoVenta",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "Monedas",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "TiposCliente",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "Actividades",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "Equipos",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "Especialidades",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "Inspecciones",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "Oportunidades",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "Prioridades",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "SubCentrosEjecutores",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "TiposOrden",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "Trabajadores",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Programas",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "PlanesArticulo",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "SubFamilias",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "TiposArticulo",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "UnidadesMedida",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "AtributosConcreto",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "CategoriasProducto",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "TiposBien",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "TiposOperacion",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "TiposProducto",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "UnidadesMedidaVenta",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "TransportistasVentas",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "ObjetosActividad",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "VerbosActividad",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "SubCentrosCosto",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "CentrosEjecutores",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "EstadosCiviles",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Nacionalidades",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Sexos",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "Submodulos",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "Familias",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "TiposDocumento",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "Ubigeos",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "CentrosCosto",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Modulos",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "Plantas",
                schema: "comun");
        }
    }
}
