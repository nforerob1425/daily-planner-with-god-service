using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CreateAppConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationConfigs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationConfigs",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { new Guid("026f5f5c-97bc-4bf2-8b72-9d8d0b6b0694"), "HomeVideoUrl", "https://www.youtube.com/watch?v=Q9QoXR_5Qzs&list=PLt7-BTVbUMJne1HPcFvTt-Z8XxUSQCp0o" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationConfigs");
        }
    }
}
