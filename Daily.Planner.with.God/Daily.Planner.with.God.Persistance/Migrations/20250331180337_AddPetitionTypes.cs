using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddPetitionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetitionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetitionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Petitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PrayFor = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPraying = table.Column<bool>(type: "boolean", nullable: false),
                    PetitionTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportedToUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Petitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Petitions_PetitionTypes_PetitionTypeId",
                        column: x => x.PetitionTypeId,
                        principalTable: "PetitionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Petitions_Users_ReportedToUserId",
                        column: x => x.ReportedToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Petitions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PetitionTypes",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { new Guid("f345ba02-73c0-42f4-8093-047a1cd0fe5f"), "mdi-comment-question-outline", "Otro" });

            migrationBuilder.CreateIndex(
                name: "IX_Petitions_PetitionTypeId",
                table: "Petitions",
                column: "PetitionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Petitions_ReportedToUserId",
                table: "Petitions",
                column: "ReportedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Petitions_UserId",
                table: "Petitions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Petitions");

            migrationBuilder.DropTable(
                name: "PetitionTypes");
        }
    }
}
