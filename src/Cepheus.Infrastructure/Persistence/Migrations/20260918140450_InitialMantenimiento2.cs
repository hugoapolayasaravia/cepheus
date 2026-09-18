using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMantenimiento2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesTrabajo_Users_UserId",
                schema: "mantenimiento",
                table: "OrdenesTrabajo");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesTrabajo_UserId",
                schema: "mantenimiento",
                table: "OrdenesTrabajo");

            migrationBuilder.DropColumn(
                name: "FechaServicio",
                schema: "mantenimiento",
                table: "OrdenesTrabajo");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "mantenimiento",
                table: "OrdenesTrabajo");

            migrationBuilder.RenameColumn(
                name: "Observations",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                newName: "Observaciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Observaciones",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                newName: "Observations");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaServicio",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_UserId",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesTrabajo_Users_UserId",
                schema: "mantenimiento",
                table: "OrdenesTrabajo",
                column: "UserId",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
