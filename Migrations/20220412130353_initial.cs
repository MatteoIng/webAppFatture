using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace webApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fattura",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numeroFattura = table.Column<string>(nullable: true),
                    dataFattura = table.Column<DateTime>(nullable: true),
                    dataRicezione = table.Column<DateTime>(nullable: true),
                    intestatario = table.Column<string>(nullable: true),
                    importo = table.Column<float>(nullable: true),
                    metodoPagamento = table.Column<string>(nullable: true),
                    pagatore = table.Column<string>(nullable: true),
                    dataPagamento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fattura", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fattura");
        }
    }
}
