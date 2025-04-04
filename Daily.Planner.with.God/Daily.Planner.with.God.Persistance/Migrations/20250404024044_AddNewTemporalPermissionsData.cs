using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTemporalPermissionsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "SystemName" },
                values: new object[,]
                {
                    { new Guid("2a02728c-4408-4628-84bf-3b9650df5705"), "Puede ver los permisos del sistema", "CSPM" },
                    { new Guid("95a80530-1b8a-4a6b-9c88-d0f57ad03fcb"), "Puede cambiar su contraseña", "CUPS" },
                    { new Guid("96f97762-8b1e-46d8-8450-f52e85c2c2ac"), "Puede ver la clasificacion de los colores", "CSTC" }
                });

            migrationBuilder.InsertData(
                table: "TemporalPermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("315dade7-a364-4729-ada3-bcf99ce44a57"), new Guid("96f97762-8b1e-46d8-8450-f52e85c2c2ac"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("57dec3c3-5278-4cde-bcb3-804e1db105a1"), new Guid("95a80530-1b8a-4a6b-9c88-d0f57ad03fcb"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("b1bc8599-3dbe-46b1-8ce8-24f42980fe2e"), new Guid("2a02728c-4408-4628-84bf-3b9650df5705"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TemporalPermissions",
                keyColumn: "Id",
                keyValue: new Guid("315dade7-a364-4729-ada3-bcf99ce44a57"));

            migrationBuilder.DeleteData(
                table: "TemporalPermissions",
                keyColumn: "Id",
                keyValue: new Guid("57dec3c3-5278-4cde-bcb3-804e1db105a1"));

            migrationBuilder.DeleteData(
                table: "TemporalPermissions",
                keyColumn: "Id",
                keyValue: new Guid("b1bc8599-3dbe-46b1-8ce8-24f42980fe2e"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2a02728c-4408-4628-84bf-3b9650df5705"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("95a80530-1b8a-4a6b-9c88-d0f57ad03fcb"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("96f97762-8b1e-46d8-8450-f52e85c2c2ac"));
        }
    }
}
