using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class Cambios_Empleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Empleados",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "Empleados",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                table: "Empleados",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                table: "Empleados");
        }
    }
}
