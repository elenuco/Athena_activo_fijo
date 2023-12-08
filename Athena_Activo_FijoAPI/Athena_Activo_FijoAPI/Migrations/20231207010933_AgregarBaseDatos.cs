using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Athena_Activo_FijoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarBaseDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreasTrabajo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasTrabajo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipoActivo",
                columns: table => new
                {
                    ID_tipo_activo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoActivo", x => x.ID_tipo_activo);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id_Persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    n_carnet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreasTrabajoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id_Persona);
                    table.ForeignKey(
                        name: "FK_Personas_AreasTrabajo_AreasTrabajoid",
                        column: x => x.AreasTrabajoid,
                        principalTable: "AreasTrabajo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivosFijos",
                columns: table => new
                {
                    ID_tipo_activo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoActivoID_tipo_activo = table.Column<int>(type: "int", nullable: false),
                    Descipcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivosFijos", x => x.ID_tipo_activo);
                    table.ForeignKey(
                        name: "FK_ActivosFijos_tipoActivo_tipoActivoID_tipo_activo",
                        column: x => x.tipoActivoID_tipo_activo,
                        principalTable: "tipoActivo",
                        principalColumn: "ID_tipo_activo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    Id_Asignaciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonasId_Persona = table.Column<int>(type: "int", nullable: false),
                    ActivosFijosID_tipo_activo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.Id_Asignaciones);
                    table.ForeignKey(
                        name: "FK_Asignaciones_ActivosFijos_ActivosFijosID_tipo_activo",
                        column: x => x.ActivosFijosID_tipo_activo,
                        principalTable: "ActivosFijos",
                        principalColumn: "ID_tipo_activo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Personas_PersonasId_Persona",
                        column: x => x.PersonasId_Persona,
                        principalTable: "Personas",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Athena",
                columns: table => new
                {
                    ID_Athena = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivosFijosID_tipo_activo = table.Column<int>(type: "int", nullable: false),
                    tipoActivoID_tipo_activo = table.Column<int>(type: "int", nullable: false),
                    AsignacionesId_Asignaciones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athena", x => x.ID_Athena);
                    table.ForeignKey(
                        name: "FK_Athena_ActivosFijos_ActivosFijosID_tipo_activo",
                        column: x => x.ActivosFijosID_tipo_activo,
                        principalTable: "ActivosFijos",
                        principalColumn: "ID_tipo_activo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Athena_Asignaciones_AsignacionesId_Asignaciones",
                        column: x => x.AsignacionesId_Asignaciones,
                        principalTable: "Asignaciones",
                        principalColumn: "Id_Asignaciones",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Athena_tipoActivo_tipoActivoID_tipo_activo",
                        column: x => x.tipoActivoID_tipo_activo,
                        principalTable: "tipoActivo",
                        principalColumn: "ID_tipo_activo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivosFijos_tipoActivoID_tipo_activo",
                table: "ActivosFijos",
                column: "tipoActivoID_tipo_activo");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_ActivosFijosID_tipo_activo",
                table: "Asignaciones",
                column: "ActivosFijosID_tipo_activo");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_PersonasId_Persona",
                table: "Asignaciones",
                column: "PersonasId_Persona");

            migrationBuilder.CreateIndex(
                name: "IX_Athena_ActivosFijosID_tipo_activo",
                table: "Athena",
                column: "ActivosFijosID_tipo_activo");

            migrationBuilder.CreateIndex(
                name: "IX_Athena_AsignacionesId_Asignaciones",
                table: "Athena",
                column: "AsignacionesId_Asignaciones");

            migrationBuilder.CreateIndex(
                name: "IX_Athena_tipoActivoID_tipo_activo",
                table: "Athena",
                column: "tipoActivoID_tipo_activo");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_AreasTrabajoid",
                table: "Personas",
                column: "AreasTrabajoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Athena");

            migrationBuilder.DropTable(
                name: "Asignaciones");

            migrationBuilder.DropTable(
                name: "ActivosFijos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "tipoActivo");

            migrationBuilder.DropTable(
                name: "AreasTrabajo");
        }
    }
}
