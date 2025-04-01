using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddAgendaProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OriginalAgendaId",
                table: "Agendas",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Agendas",
                keyColumn: "Id",
                keyValue: new Guid("9656ec88-b900-4117-984f-74d2868a2a7c"),
                columns: new[] { "ImageBackgroundSrc", "OriginalAgendaId" },
                values: new object[] { "/assets/backgrounds/R07-2025.png", null });

            migrationBuilder.UpdateData(
                table: "Agendas",
                keyColumn: "Id",
                keyValue: new Guid("e345b2d8-1c47-405c-b762-7c8dc3d8388a"),
                columns: new[] { "ImageBackgroundSrc", "OriginalAgendaId" },
                values: new object[] { "/assets/backgrounds/R07-2025.png", null });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_OriginalAgendaId",
                table: "Agendas",
                column: "OriginalAgendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Agendas_OriginalAgendaId",
                table: "Agendas",
                column: "OriginalAgendaId",
                principalTable: "Agendas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Agendas_OriginalAgendaId",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_OriginalAgendaId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "OriginalAgendaId",
                table: "Agendas");

            migrationBuilder.UpdateData(
                table: "Agendas",
                keyColumn: "Id",
                keyValue: new Guid("9656ec88-b900-4117-984f-74d2868a2a7c"),
                column: "ImageBackgroundSrc",
                value: "https://imgs.search.brave.com/sX79eLHhVT15r0HiO6z-lp5roWgDnOR0ktAmkvij5Gk/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93YWxs/cGFwZXJzLmNvbS9p/bWFnZXMvZmVhdHVy/ZWQvaW1hZ2VuZXMt/Y3Jpc3RpYW5hcy10/dWV3dnVyN2t6OWY3/Y3lxLmpwZw");

            migrationBuilder.UpdateData(
                table: "Agendas",
                keyColumn: "Id",
                keyValue: new Guid("e345b2d8-1c47-405c-b762-7c8dc3d8388a"),
                column: "ImageBackgroundSrc",
                value: "https://imgs.search.brave.com/sX79eLHhVT15r0HiO6z-lp5roWgDnOR0ktAmkvij5Gk/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93YWxs/cGFwZXJzLmNvbS9p/bWFnZXMvZmVhdHVy/ZWQvaW1hZ2VuZXMt/Y3Jpc3RpYW5hcy10/dWV3dnVyN2t6OWY3/Y3lxLmpwZw");
        }
    }
}
