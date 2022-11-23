using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaMicroservicios.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePersona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GeneroPersona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EdadPersona = table.Column<int>(type: "int", nullable: false),
                    IdentificacionPersona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DireccionPersona = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TelefonoPersona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstadoCliente = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
