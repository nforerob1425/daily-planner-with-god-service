using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddNameConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Configurations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("788a03cd-2864-44b2-883a-4d137f737ada"),
                column: "Name",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Configurations");
        }
    }
}
