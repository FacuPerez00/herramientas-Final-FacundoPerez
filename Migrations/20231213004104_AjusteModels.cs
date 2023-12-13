using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class AjusteModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sector",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Sector",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Puestos",
                newName: "Nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Sector",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Sector",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Puestos",
                newName: "Name");
        }
    }
}
