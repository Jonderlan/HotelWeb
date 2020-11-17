using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelWeb.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    TipoQuarto = table.Column<string>(nullable: true),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: false),
                    QuantosAdultos = table.Column<int>(nullable: false),
                    QuantosCriancas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
