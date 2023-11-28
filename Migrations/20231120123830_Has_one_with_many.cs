using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class Has_one_with_many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Puestos");

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Puestos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_SectorId",
                table: "Puestos",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Puestos_Sector_SectorId",
                table: "Puestos",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puestos_Sector_SectorId",
                table: "Puestos");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropIndex(
                name: "IX_Puestos_SectorId",
                table: "Puestos");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Puestos");

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "Puestos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
