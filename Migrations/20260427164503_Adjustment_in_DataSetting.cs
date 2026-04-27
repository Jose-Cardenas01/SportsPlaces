using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsPlacesWeb.Migrations
{
    /// <inheritdoc />
    public partial class Adjustment_in_DataSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sedes__3213E83F0D49A02B", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    tipo_usuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Correo_Institucional = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3213E83F5DB2BFD7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Escenario",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    sedes_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalendarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Escenari__3213E83F8C58B69A", x => x.id);
                    table.ForeignKey(
                        name: "FK_Espacio_Sedes",
                        column: x => x.sedes_id,
                        principalTable: "Sedes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mensaje = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    fecha_envio = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipo_notificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83FCCC02D59", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notificacion_Usuario",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Calendarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Hora = table.Column<TimeOnly>(type: "time", nullable: false),
                    IdEscenario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Calendario__3213E83F12345678", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendarios_Escenario_IdEscenario",
                        column: x => x.IdEscenario,
                        principalTable: "Escenario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportesDano",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    evidencia = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    espacio_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reportes__3213E83F8E266D26", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reporte_Espacio",
                        column: x => x.espacio_id,
                        principalTable: "Escenario",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Reporte_Usuario",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    hora = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    espacio_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sedes_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservas__3213E83F22689D38", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reserva_Espacio",
                        column: x => x.espacio_id,
                        principalTable: "Escenario",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Reserva_Usuario",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendarios_IdEscenario",
                table: "Calendarios",
                column: "IdEscenario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Escenario_sedes_id",
                table: "Escenario",
                column: "sedes_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_usuario_id",
                table: "Notificaciones",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesDano_espacio_id",
                table: "ReportesDano",
                column: "espacio_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesDano_usuario_id",
                table: "ReportesDano",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_espacio_id",
                table: "Reservas",
                column: "espacio_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_usuario_id",
                table: "Reservas",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendarios");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "ReportesDano");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Escenario");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Sedes");
        }
    }
}
