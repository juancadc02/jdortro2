using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elementos",
                columns: table => new
                {
                    idElemento = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigoElemento = table.Column<string>(type: "text", nullable: false),
                    nombreElemento = table.Column<string>(type: "text", nullable: false),
                    descripcionElemento = table.Column<string>(type: "text", nullable: false),
                    cantidadElemento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elementos", x => x.idElemento);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    idReserva = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fchReserva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.idReserva);
                });

            migrationBuilder.CreateTable(
                name: "RelElementosReservas",
                columns: table => new
                {
                    idRelElementoReservas = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idElemento = table.Column<long>(type: "bigint", nullable: false),
                    idReserva = table.Column<long>(type: "bigint", nullable: false),
                    cantidadReservada = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelElementosReservas", x => x.idRelElementoReservas);
                    table.ForeignKey(
                        name: "FK_RelElementosReservas_Elementos_idElemento",
                        column: x => x.idElemento,
                        principalTable: "Elementos",
                        principalColumn: "idElemento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelElementosReservas_Reservas_idReserva",
                        column: x => x.idReserva,
                        principalTable: "Reservas",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelElementosReservas_idElemento",
                table: "RelElementosReservas",
                column: "idElemento");

            migrationBuilder.CreateIndex(
                name: "IX_RelElementosReservas_idReserva",
                table: "RelElementosReservas",
                column: "idReserva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelElementosReservas");

            migrationBuilder.DropTable(
                name: "Elementos");

            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
