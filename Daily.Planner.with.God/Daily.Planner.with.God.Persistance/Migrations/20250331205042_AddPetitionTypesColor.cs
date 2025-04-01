using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddPetitionTypesColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "PetitionTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "PetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("f345ba02-73c0-42f4-8093-047a1cd0fe5f"),
                column: "Color",
                value: "#FFFFFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "PetitionTypes");
        }
    }
}
