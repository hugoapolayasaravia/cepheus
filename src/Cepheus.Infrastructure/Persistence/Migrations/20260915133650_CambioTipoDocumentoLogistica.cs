using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambioTipoDocumentoLogistica : Migration
    {
        /// <inheritdoc />
protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Eliminar las FK antes de modificar las columnas relacionadas
            migrationBuilder.DropForeignKey(
                name: "FK_Conductores_TiposDocumento_DocumentTypeCode",
                schema: "logistica",
                table: "Conductores");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_TiposDocumento_DocumentTypeCode",
                schema: "logistica",
                table: "Proveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Transportistas_TiposDocumento_DocumentTypeCode",
                schema: "logistica",
                table: "Transportistas");

            // 2. Eliminar la restricción única de Code
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TiposDocumento_Code",
                schema: "comun",
                table: "TiposDocumento");

            // 3. Eliminar la PK actual
            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposDocumento",
                schema: "comun",
                table: "TiposDocumento");

            // 4. Eliminar Id
            migrationBuilder.DropColumn(
                name: "Id",
                schema: "comun",
                table: "TiposDocumento");

            // 5. Cambiar DocumentTypeCode de Transportistas
            migrationBuilder.AlterColumn<string>(
                name: "DocumentTypeCode",
                schema: "logistica",
                table: "Transportistas",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            // 6. Cambiar Code de TiposDocumento
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "comun",
                table: "TiposDocumento",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            // 7. Cambiar DocumentTypeCode de Proveedores
            migrationBuilder.AlterColumn<string>(
                name: "DocumentTypeCode",
                schema: "logistica",
                table: "Proveedores",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            // 8. Cambiar DocumentTypeCode de Conductores
            migrationBuilder.AlterColumn<string>(
                name: "DocumentTypeCode",
                schema: "logistica",
                table: "Conductores",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            // 9. Crear nueva PK sobre Code
            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposDocumento",
                schema: "comun",
                table: "TiposDocumento",
                column: "Code");

            // 10. Restaurar FK Conductores
            migrationBuilder.AddForeignKey(
                name: "FK_Conductores_TiposDocumento_DocumentTypeCode",
                schema: "logistica",
                table: "Conductores",
                column: "DocumentTypeCode",
                principalSchema: "comun",
                principalTable: "TiposDocumento",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            // 11. Restaurar FK Proveedores
            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_TiposDocumento_DocumentTypeCode",
                schema: "logistica",
                table: "Proveedores",
                column: "DocumentTypeCode",
                principalSchema: "comun",
                principalTable: "TiposDocumento",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            // 12. Restaurar FK Transportistas
            migrationBuilder.AddForeignKey(
                name: "FK_Transportistas_TiposDocumento_DocumentTypeCode",
                schema: "logistica",
                table: "Transportistas",
                column: "DocumentTypeCode",
                principalSchema: "comun",
                principalTable: "TiposDocumento",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposDocumento",
                schema: "comun",
                table: "TiposDocumento");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentTypeCode",
                schema: "logistica",
                table: "Transportistas",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "comun",
                table: "TiposDocumento",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "comun",
                table: "TiposDocumento",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentTypeCode",
                schema: "logistica",
                table: "Proveedores",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentTypeCode",
                schema: "logistica",
                table: "Conductores",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TiposDocumento_Code",
                schema: "comun",
                table: "TiposDocumento",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposDocumento",
                schema: "comun",
                table: "TiposDocumento",
                column: "Id");
        }
    }
}
