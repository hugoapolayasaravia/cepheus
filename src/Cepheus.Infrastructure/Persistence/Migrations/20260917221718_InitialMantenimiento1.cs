using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMantenimiento1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mantenimiento");

            migrationBuilder.CreateTable(
                name: "CentrosEjecutores",
                schema: "mantenimiento",
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
                    table.PrimaryKey("PK_CentrosEjecutores", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    SubCentroCostoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
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
                name: "Especialidades",
                schema: "mantenimiento",
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
                    table.PrimaryKey("PK_Especialidades", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Inspecciones",
                schema: "mantenimiento",
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
                    table.PrimaryKey("PK_Inspecciones", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Maquinas",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
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
                name: "Negocios",
                schema: "comun",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false),
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
                name: "ObjetosActividad",
                schema: "mantenimiento",
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
                    table.PrimaryKey("PK_ObjetosActividad", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Oportunidades",
                schema: "mantenimiento",
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
                    table.PrimaryKey("PK_Oportunidades", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Prioridades",
                schema: "mantenimiento",
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
                    table.PrimaryKey("PK_Prioridades", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TiposOrden",
                schema: "mantenimiento",
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
                    table.PrimaryKey("PK_TiposOrden", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "VerbosActividad",
                schema: "mantenimiento",
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
                    table.PrimaryKey("PK_VerbosActividad", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SubCentrosEjecutores",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CentroEjecutorCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
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
                name: "Actividades",
                schema: "mantenimiento",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    VerboActividadCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ObjetoActividadCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
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
                name: "OrdenesTrabajo",
                schema: "mantenimiento",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaServicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaTermino = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResponsableCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    EspecialidadCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    OportunidadCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    EquipoCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    PrioridadCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    InspeccionCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    TipoOrdenCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ActividadCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    SubCentroCostoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    SubCentroEjecutorCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    PlanMantenimientoPreventivoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DowntimeHours = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Horometro = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_OrdenesTrabajo_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OTResponsables",
                schema: "mantenimiento",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    OrdenTrabajoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrabajadorCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "OTRMaquinas",
                schema: "mantenimiento",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    OrdenTrabajoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    MaquinaCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
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
                    PlantaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    OrdenTrabajoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticuloCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
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
                name: "IX_Equipos_SubCentroCostoCode",
                schema: "mantenimiento",
                table: "Equipos",
                column: "SubCentroCostoCode");

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
                name: "IX_OrdenesTrabajo_UserId",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "UserId");

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
                name: "IX_SubCentrosEjecutores_CentroEjecutorCode",
                schema: "mantenimiento",
                table: "SubCentrosEjecutores",
                column: "CentroEjecutorCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Negocios",
                schema: "comun");

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
                name: "Maquinas",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "OrdenesTrabajo",
                schema: "mantenimiento");

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
                name: "ObjetosActividad",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "VerbosActividad",
                schema: "mantenimiento");

            migrationBuilder.DropTable(
                name: "CentrosEjecutores",
                schema: "mantenimiento");
        }
    }
}
