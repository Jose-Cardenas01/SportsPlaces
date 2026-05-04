using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsPlacesWeb.Migrations
{
    /// <inheritdoc />
    public partial class Adjustmen_in_Reservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hora",
                table: "Reservas",
                newName: "hora_inicio");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "hora_fin",
                table: "Reservas",
                type: "time",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "hora_fin",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "hora_inicio",
                table: "Reservas",
                newName: "hora");
        }
    }
}
