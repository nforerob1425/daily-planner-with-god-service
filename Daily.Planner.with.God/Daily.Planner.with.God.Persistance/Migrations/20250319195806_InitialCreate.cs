using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ImageBackgroundSrc = table.Column<string>(type: "text", nullable: false),
                    IsReported = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Scale = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    RolId = table.Column<Guid>(type: "uuid", nullable: false),
                    SystemName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorPaletts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorPaletts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorPaletts_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShowFavorites = table.Column<bool>(type: "boolean", nullable: false),
                    ShowPetitions = table.Column<bool>(type: "boolean", nullable: false),
                    ColorPalettId = table.Column<Guid>(type: "uuid", nullable: true),
                    ColorPalettId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    ColorPalettId2 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_ColorPaletts_ColorPalettId",
                        column: x => x.ColorPalettId,
                        principalTable: "ColorPaletts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_ColorPaletts_ColorPalettId1",
                        column: x => x.ColorPalettId1,
                        principalTable: "ColorPaletts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configurations_ColorPaletts_ColorPalettId2",
                        column: x => x.ColorPalettId2,
                        principalTable: "ColorPaletts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ConfigurationId = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Favorite = table.Column<bool>(type: "boolean", nullable: false),
                    PrimaryColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    LetterColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    TitleColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Versicle = table.Column<string>(type: "text", nullable: false),
                    PrimaryColorDateId = table.Column<Guid>(type: "uuid", nullable: false),
                    LetterDateColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AgendaId = table.Column<Guid>(type: "uuid", nullable: false),
                    OriginalUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_ColorPaletts_LetterColorId",
                        column: x => x.LetterColorId,
                        principalTable: "ColorPaletts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_ColorPaletts_LetterDateColorId",
                        column: x => x.LetterDateColorId,
                        principalTable: "ColorPaletts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_ColorPaletts_PrimaryColorDateId",
                        column: x => x.PrimaryColorDateId,
                        principalTable: "ColorPaletts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_ColorPaletts_PrimaryColorId",
                        column: x => x.PrimaryColorId,
                        principalTable: "ColorPaletts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_ColorPaletts_TitleColorId",
                        column: x => x.TitleColorId,
                        principalTable: "ColorPaletts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Users_OriginalUserId",
                        column: x => x.OriginalUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AgendaId",
                table: "Cards",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_LetterColorId",
                table: "Cards",
                column: "LetterColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_LetterDateColorId",
                table: "Cards",
                column: "LetterDateColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_OriginalUserId",
                table: "Cards",
                column: "OriginalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PrimaryColorDateId",
                table: "Cards",
                column: "PrimaryColorDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PrimaryColorId",
                table: "Cards",
                column: "PrimaryColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TitleColorId",
                table: "Cards",
                column: "TitleColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId1",
                table: "Cards",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ColorPaletts_TypeId",
                table: "ColorPaletts",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ColorPalettId",
                table: "Configurations",
                column: "ColorPalettId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ColorPalettId1",
                table: "Configurations",
                column: "ColorPalettId1");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ColorPalettId2",
                table: "Configurations",
                column: "ColorPalettId2");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RolId",
                table: "Permissions",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ConfigurationId",
                table: "Users",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LeadId",
                table: "Users",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ColorPaletts");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
