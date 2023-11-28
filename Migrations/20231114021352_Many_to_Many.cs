using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class Many_to_Many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Puestos_PuestoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_PuestoId",
                table: "Empleados");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Empleados",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Empleados",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "EmpleadoPuesto",
                columns: table => new
                {
                    EmpleadosId = table.Column<int>(type: "INTEGER", nullable: false),
                    PuestosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoPuesto", x => new { x.EmpleadosId, x.PuestosId });
                    table.ForeignKey(
                        name: "FK_EmpleadoPuesto_Empleados_EmpleadosId",
                        column: x => x.EmpleadosId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadoPuesto_Puestos_PuestosId",
                        column: x => x.PuestosId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoPuesto_PuestosId",
                table: "EmpleadoPuesto",
                column: "PuestosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadoPuesto");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Empleados",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Empleados",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PuestoId",
                table: "Empleados",
                column: "PuestoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Puestos_PuestoId",
                table: "Empleados",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
