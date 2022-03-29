using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    cor = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tarefa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    prioridade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_entrega = table.Column<DateTime>(type: "datetime", nullable: false),
                    categoria_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tarefa", x => x.id);
                    table.ForeignKey(
                        name: "fk_tarefa_categoria",
                        column: x => x.categoria_id,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "idx_tarefa_categoria",
                table: "tarefa",
                column: "categoria_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tarefa");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
