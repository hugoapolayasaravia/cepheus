using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialLogisticaCatalogoPart1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "logistica");

            migrationBuilder.CreateTable(
                name: "Compradores",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
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
                name: "Familias",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
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
                name: "LugaresEnvio",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
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
                name: "NotasCompra",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
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
                name: "TiposCompra",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
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
                name: "TiposPedido",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
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
                name: "Tramites",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
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
                name: "UnidadesMedida",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
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
                name: "UnidadesNegocio",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParentCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
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
                name: "SubFamilias",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FamiliaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_SubFamilias_FamiliaCode",
                schema: "logistica",
                table: "SubFamilias",
                column: "FamiliaCode");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesNegocio_ParentCode",
                schema: "logistica",
                table: "UnidadesNegocio",
                column: "ParentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compradores",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "LugaresEnvio",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "NotasCompra",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "SubFamilias",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "TiposCompra",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "TiposPedido",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Tramites",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "UnidadesMedida",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "UnidadesNegocio",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Familias",
                schema: "logistica");
        }
    }
}
