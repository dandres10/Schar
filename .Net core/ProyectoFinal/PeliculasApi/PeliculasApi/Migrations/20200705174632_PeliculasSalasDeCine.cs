using Microsoft.EntityFrameworkCore.Migrations;

namespace PeliculasApi.Migrations
{
    public partial class PeliculasSalasDeCine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaDeCines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaDeCines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasSalasDeCines",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(nullable: false),
                    SalaDeCineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasSalasDeCines", x => new { x.PeliculaId, x.SalaDeCineId });
                    table.ForeignKey(
                        name: "FK_PeliculasSalasDeCines_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasSalasDeCines_SalaDeCines_SalaDeCineId",
                        column: x => x.SalaDeCineId,
                        principalTable: "SalaDeCines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasSalasDeCines_SalaDeCineId",
                table: "PeliculasSalasDeCines",
                column: "SalaDeCineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculasSalasDeCines");

            migrationBuilder.DropTable(
                name: "SalaDeCines");
        }
    }
}
