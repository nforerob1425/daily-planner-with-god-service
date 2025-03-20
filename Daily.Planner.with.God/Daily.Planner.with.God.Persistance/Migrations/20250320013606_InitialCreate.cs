using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Year = table.Column<int>(type: "integer", nullable: false),
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
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShowFavorites = table.Column<bool>(type: "boolean", nullable: false),
                    ShowPetitions = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
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
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    SystemName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    LeadId = table.Column<Guid>(type: "uuid", nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    OriginalUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Content", "ImageBackgroundSrc", "IsReported", "Title", "Year" },
                values: new object[,]
                {
                    { new Guid("9656ec88-b900-4117-984f-74d2868a2a7c"), "Contenido para la agenda", "https://imgs.search.brave.com/sX79eLHhVT15r0HiO6z-lp5roWgDnOR0ktAmkvij5Gk/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93YWxs/cGFwZXJzLmNvbS9p/bWFnZXMvZmVhdHVy/ZWQvaW1hZ2VuZXMt/Y3Jpc3RpYW5hcy10/dWV3dnVyN2t6OWY3/Y3lxLmpwZw", false, "R07-2025", 2025 },
                    { new Guid("e345b2d8-1c47-405c-b762-7c8dc3d8388a"), "Contenido para la agenda", "https://imgs.search.brave.com/sX79eLHhVT15r0HiO6z-lp5roWgDnOR0ktAmkvij5Gk/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93YWxs/cGFwZXJzLmNvbS9p/bWFnZXMvZmVhdHVy/ZWQvaW1hZ2VuZXMt/Y3Jpc3RpYW5hcy10/dWV3dnVyN2t6OWY3/Y3lxLmpwZw", true, "R07-2025", 2025 }
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "ShowFavorites", "ShowPetitions" },
                values: new object[] { new Guid("788a03cd-2864-44b2-883a-4d137f737ada"), false, false });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "Scale" },
                values: new object[,]
                {
                    { new Guid("0cc14aac-9f7c-4f37-a7d2-01226d41b2d2"), "Oveja", 1 },
                    { new Guid("0edea2e2-b3e0-4445-b7b1-856b098250fe"), "Coordinador de red", 3 },
                    { new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a"), "Admin", 100 },
                    { new Guid("448f0302-927a-4a9e-b8f7-2ea10cd434e4"), "Moderador", 10 },
                    { new Guid("b671e630-e8fc-48b0-bb22-6c5b608173f9"), "Pastor", 6 },
                    { new Guid("e48ca8b7-c812-4a6c-8bc1-0d0ddbe21e32"), "Lider de red", 4 },
                    { new Guid("e52ada33-3ac0-445a-a307-7df21bcfb719"), "Lider", 2 },
                    { new Guid("fdd6e043-eba2-4087-9b70-a1afdf654060"), "Cabeza de red", 5 }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("457978c7-36f9-4ce0-b511-c5146c80c22e"), "Title Date Background" },
                    { new Guid("7e3db5bd-c255-4795-8d3b-3f038f09a9ba"), "Title" },
                    { new Guid("84d0826e-ce9c-4a52-b27e-e7740e8f98e7"), "Primary Background" },
                    { new Guid("9659ad69-c5d3-4939-8702-af2064d6f1fd"), "Title Date" },
                    { new Guid("db0d60a6-e693-44eb-ae68-cc31719599ae"), "Primary Letter" }
                });

            migrationBuilder.InsertData(
                table: "ColorPaletts",
                columns: new[] { "Id", "Color", "TypeId" },
                values: new object[,]
                {
                    { new Guid("498ca682-19b8-40bb-9c5a-2e5e99f0796e"), "#A0D3FA", new Guid("7e3db5bd-c255-4795-8d3b-3f038f09a9ba") },
                    { new Guid("6626c294-ee9f-4105-b858-68e4a6ba3036"), "#FAE1A0", new Guid("9659ad69-c5d3-4939-8702-af2064d6f1fd") },
                    { new Guid("836d62f8-dea8-4bdc-856f-613de2dd79eb"), "#7A3F11", new Guid("457978c7-36f9-4ce0-b511-c5146c80c22e") },
                    { new Guid("8f25df6d-44f0-4985-8e56-9d193d9f4570"), "#114D7A", new Guid("84d0826e-ce9c-4a52-b27e-e7740e8f98e7") },
                    { new Guid("b06ddf08-6d80-433d-9599-97ed6ab805d4"), "#EAE9E6", new Guid("db0d60a6-e693-44eb-ae68-cc31719599ae") }
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
                name: "IX_ColorPaletts_TypeId",
                table: "ColorPaletts",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

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
                name: "ColorPaletts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
