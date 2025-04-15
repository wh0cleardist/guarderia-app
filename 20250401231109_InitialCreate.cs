using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuarderiaApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niños",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroMatricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niños", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonasAutorizadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasAutorizadas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Platos_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenusConsumidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NiñoId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenusConsumidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenusConsumidos_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenusConsumidos_Niños_NiñoId",
                        column: x => x.NiñoId,
                        principalTable: "Niños",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NiñoPersonaAutorizada",
                columns: table => new
                {
                    NiñosId = table.Column<int>(type: "int", nullable: false),
                    PersonasAutorizadasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiñoPersonaAutorizada", x => new { x.NiñosId, x.PersonasAutorizadasId });
                    table.ForeignKey(
                        name: "FK_NiñoPersonaAutorizada_Niños_NiñosId",
                        column: x => x.NiñosId,
                        principalTable: "Niños",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NiñoPersonaAutorizada_PersonasAutorizadas_PersonasAutorizadasId",
                        column: x => x.PersonasAutorizadasId,
                        principalTable: "PersonasAutorizadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Platos_PlatoId",
                        column: x => x.PlatoId,
                        principalTable: "Platos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PlatoId",
                table: "Ingredientes",
                column: "PlatoId");

            migrationBuilder.CreateIndex(
                name: "IX_MenusConsumidos_MenuId",
                table: "MenusConsumidos",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenusConsumidos_NiñoId",
                table: "MenusConsumidos",
                column: "NiñoId");

            migrationBuilder.CreateIndex(
                name: "IX_NiñoPersonaAutorizada_PersonasAutorizadasId",
                table: "NiñoPersonaAutorizada",
                column: "PersonasAutorizadasId");

            migrationBuilder.CreateIndex(
                name: "IX_Platos_MenuId",
                table: "Platos",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "MenusConsumidos");

            migrationBuilder.DropTable(
                name: "NiñoPersonaAutorizada");

            migrationBuilder.DropTable(
                name: "Platos");

            migrationBuilder.DropTable(
                name: "Niños");

            migrationBuilder.DropTable(
                name: "PersonasAutorizadas");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
