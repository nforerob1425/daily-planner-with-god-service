using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddTemporalPermissionsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Permissions");

            migrationBuilder.CreateTable(
                name: "TemporalPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporalPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemporalPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemporalPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "Name", "ShowFavorites", "ShowPetitions" },
                values: new object[,]
                {
                    { new Guid("24d897b2-e36c-4e3e-a60e-5075535f7352"), "", true, false },
                    { new Guid("dde063f6-79da-4707-852c-62260ffb82af"), "", false, true },
                    { new Guid("ed187966-ffc8-4897-becc-619cfe584445"), "", true, true }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "SystemName" },
                values: new object[,]
                {
                    { new Guid("05958f1c-844a-43e9-9bcb-6667dad75670"), "Puede ver la vista de Administracion de usuarios", "CSUV" },
                    { new Guid("0678fae5-e577-4fd5-a759-ae3fb0fd9d6b"), "Puede ver las agendas", "CSAG" },
                    { new Guid("0a1f874b-af1c-4b3f-8d3e-2714eb2a6ca4"), "Puede crear tarjetas", "CCCD" },
                    { new Guid("0aaa962a-8d64-4515-9659-63e37f98c8ca"), "Puede actualizar las configuraciones del sistema", "CUAP" },
                    { new Guid("0fe9b79f-8bf5-4742-8284-5414494988b0"), "Puede actualizar sus anuncios", "CUNW" },
                    { new Guid("161ab07a-92d0-422e-a7df-20e69238dad7"), "Puede actualizar usuarios", "CUUS" },
                    { new Guid("19f3b0e7-cc0b-44ba-ad7f-3ad17bcc9949"), "Puede ver la vista del R07", "CSPV" },
                    { new Guid("1f52010f-c57c-4031-a666-4ad9c4076404"), "Puede actualizar peticiones", "CUPT" },
                    { new Guid("24395707-0c33-42fe-bc05-39bd9b5e0485"), "Puede crear anuncios", "CCNW" },
                    { new Guid("2ad66724-24d7-4a86-b512-7cf5a4c4bfc3"), "Puede asignar permisos temporales", "CCTP" },
                    { new Guid("2dd17f8f-6e80-4e60-919d-e304b90d0f46"), "Puede actualizar las configuraciones", "CUCN" },
                    { new Guid("2f6a2460-7e0c-4677-a9a7-0c90ac88e2c7"), "Puede eliminar peticiones", "CDPT" },
                    { new Guid("348f5ae9-8ee7-40e1-bd13-0166e437ed1b"), "Puede eliminar colores", "CDCO" },
                    { new Guid("3bd9aa44-f431-43a6-8b0a-ca99b77d100c"), "Puede eliminar tarjetas", "CDCD" },
                    { new Guid("3fb76b0e-bcf6-45a0-a141-42873cff242c"), "Puede ver las configuraciones del sistema", "CSAP" },
                    { new Guid("410edf32-53fb-4242-9ca1-009ae499fcca"), "Puede ver la vista de Solicitudes", "CSEV" },
                    { new Guid("489facd4-0546-4e91-9d2d-26afc5e60080"), "Puede ver la vista del Dashboard", "CSDV" },
                    { new Guid("4f7c081e-b834-4fed-acfb-10d54e8c8f11"), "Puede reportar tarjetas", "CRCD" },
                    { new Guid("503fc79e-3f52-435b-9222-254c8c1fc738"), "Puede ver la vista de Manejo de la aplicacion", "CSHV" },
                    { new Guid("54b2a2a2-eccb-4241-8ece-d4e5a9beebaa"), "Puede actualizar colores", "CUCO" },
                    { new Guid("54e3c968-e8d4-4b43-87d6-6351076e0093"), "Puede eliminar usuarios", "CDUS" },
                    { new Guid("588ec542-ed55-4e66-9215-1c9216c5c914"), "Puede descargar el reporte del mes", "CDWCD" },
                    { new Guid("5bada406-7bf0-41e7-8f6c-52f65760181c"), "Puede ver la vista del Inicio", "CSHV" },
                    { new Guid("6a088364-cfa7-4e7c-8a31-17cddc9f1370"), "Puede ver los anuncios", "CSNW" },
                    { new Guid("717a6cae-0844-4666-9621-c7082a8b9539"), "Puede ver las configuraciones", "CSCN" },
                    { new Guid("72d1cb2c-30b0-4b6c-a9cd-d471940f7b93"), "Puede ver los colores", "CSCO" },
                    { new Guid("75cf41d2-ca8f-4cb0-a37c-e3b34ddcb8c9"), "Puede crear usuarios", "CCUS" },
                    { new Guid("7816c0b8-4db8-4a8b-b171-824a179709d2"), "Puede ver las tarjetas del R07", "CSCD" },
                    { new Guid("8682fd93-c365-48f6-a363-720fd272a589"), "Puede ver los permisos temporales", "CSTP" },
                    { new Guid("8cbaaf22-3f25-4e50-b4b9-cc5f4a78ba6c"), "Puede crear agendas", "CCAG" },
                    { new Guid("9054c555-4a30-495b-95d4-fff561ce11c6"), "Puede crear notas", "CCNT" },
                    { new Guid("90d0aaaf-793c-4cde-89ea-706cdd0c1a6d"), "Puede actualizar notas", "CUNT" },
                    { new Guid("929d0a6d-6b2d-4391-aa79-c4859b9cfa57"), "Puede eliminar agendas", "CDAG" },
                    { new Guid("a4f2229d-cd70-4c4f-a0fa-39e2f9e4a639"), "Puede ver los usuarios", "CSUS" },
                    { new Guid("b3deaccb-bd01-4cd6-a543-9a001a93101c"), "Puede ver las peticiones", "CSPT" },
                    { new Guid("ba75c802-413c-4209-abb5-d92fe883061c"), "Puede desasignar permisos temporales", "CDTP" },
                    { new Guid("bbb2b3dc-b3a5-4ce4-811c-7750cba00c59"), "Puede eliminar notas", "CDNT" },
                    { new Guid("c7f65971-5dcf-45e8-b146-3df6a710df2c"), "Puede eliminar sus anuncios", "CDNW" },
                    { new Guid("cbd3a20b-a12a-437d-b130-ef77cb174edf"), "Puede ver la vista de las Configuraciones", "CSCV" },
                    { new Guid("cc7d6a95-da2c-4eca-b0fd-7e711600027e"), "Puede ver la vista del Perfil", "CSPRV" },
                    { new Guid("d274575a-c4f2-4d0a-ab6a-c634fabf9c15"), "Puede actualizar agendas", "CUAG" },
                    { new Guid("dc508983-5917-4752-8ccc-1c6674234417"), "Puede crear colores", "CCCO" },
                    { new Guid("e7c19a6f-64d5-47a7-bb93-00aa103a884a"), "Puede ver sus notas", "CSNT" },
                    { new Guid("ee46d590-2457-4b01-95f1-3af291450552"), "Puede crear peticiones", "CCPT" },
                    { new Guid("f6042a14-5907-4a6e-9417-0519cc422160"), "Puede actualizar tarjetas", "CUCD" },
                    { new Guid("ffe00ecd-e320-4a9d-84d7-2d3b2d16aa7b"), "Puede ver la vista de Peticiones", "CSPTV" }
                });

            migrationBuilder.InsertData(
                table: "TemporalPermissions",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0577b25b-00d8-41d8-8166-f9561bc8c013"), new Guid("cc7d6a95-da2c-4eca-b0fd-7e711600027e"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("0617f000-969c-490a-8a07-41b56172404d"), new Guid("7816c0b8-4db8-4a8b-b171-824a179709d2"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("08712e8d-3df2-4dd0-a91a-8331df2aa13a"), new Guid("e7c19a6f-64d5-47a7-bb93-00aa103a884a"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("09146e3a-c35f-4756-89fb-bb61e5aa0ef1"), new Guid("ffe00ecd-e320-4a9d-84d7-2d3b2d16aa7b"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("0a918af0-de6e-4571-9d10-2b9e400731c3"), new Guid("f6042a14-5907-4a6e-9417-0519cc422160"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("14f7831d-6d13-40a3-bedd-ca797cc72ed8"), new Guid("ba75c802-413c-4209-abb5-d92fe883061c"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("1714b098-4d82-40b7-b7f8-a05a3b1ea5f4"), new Guid("dc508983-5917-4752-8ccc-1c6674234417"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("19a5e887-6a1c-4e55-8db3-44b1bad09ece"), new Guid("717a6cae-0844-4666-9621-c7082a8b9539"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("19f52fb7-f8df-4511-aa3c-47f1ec0b0b37"), new Guid("8682fd93-c365-48f6-a363-720fd272a589"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("1d9a1b5b-7a4b-4058-8562-ac2aa0d36c3d"), new Guid("d274575a-c4f2-4d0a-ab6a-c634fabf9c15"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("233ebd97-5c9f-47d5-96cd-4526164769c0"), new Guid("161ab07a-92d0-422e-a7df-20e69238dad7"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("288bd58c-f8c3-458c-83b1-a73a81ef86cb"), new Guid("24395707-0c33-42fe-bc05-39bd9b5e0485"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("2e231060-7f8a-4019-a266-87dc2beb3467"), new Guid("929d0a6d-6b2d-4391-aa79-c4859b9cfa57"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("30dfc7f2-1db9-4642-bcdd-675016360c43"), new Guid("bbb2b3dc-b3a5-4ce4-811c-7750cba00c59"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("320a73ad-f473-468f-afd7-d76d664b96a1"), new Guid("0fe9b79f-8bf5-4742-8284-5414494988b0"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("38594a70-4af7-4c54-840e-fe424706711a"), new Guid("2dd17f8f-6e80-4e60-919d-e304b90d0f46"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("39496f49-6060-424e-8d65-65e4b026a64d"), new Guid("588ec542-ed55-4e66-9215-1c9216c5c914"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("5661b5c1-642a-4119-8f65-7554ee45d7e0"), new Guid("3bd9aa44-f431-43a6-8b0a-ca99b77d100c"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("59a69444-5471-4992-9e7b-0bad2ec6d61a"), new Guid("54b2a2a2-eccb-4241-8ece-d4e5a9beebaa"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("63d9665b-0ce0-42e5-87be-9980952b5169"), new Guid("b3deaccb-bd01-4cd6-a543-9a001a93101c"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("67127b93-5e66-4da4-a23d-56b0f9939a5c"), new Guid("2ad66724-24d7-4a86-b512-7cf5a4c4bfc3"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("7414d9f5-bd59-4d7c-846c-0e716bc7b569"), new Guid("0678fae5-e577-4fd5-a759-ae3fb0fd9d6b"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("7f3d63ad-6b05-408c-bced-a2fd9e00f660"), new Guid("75cf41d2-ca8f-4cb0-a37c-e3b34ddcb8c9"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("863cdc15-04ae-413d-b164-3bc76e52e429"), new Guid("05958f1c-844a-43e9-9bcb-6667dad75670"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("8d61443f-5684-49ca-9dc8-687a403fedfe"), new Guid("9054c555-4a30-495b-95d4-fff561ce11c6"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("90e45009-9f72-4246-a736-5d7685726197"), new Guid("cbd3a20b-a12a-437d-b130-ef77cb174edf"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("998d41a1-4cef-4d68-b905-6a9ab14860c3"), new Guid("8cbaaf22-3f25-4e50-b4b9-cc5f4a78ba6c"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("9b473cda-5787-48e1-870a-539a83b61029"), new Guid("2f6a2460-7e0c-4677-a9a7-0c90ac88e2c7"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("a6f36ab9-4d51-48c1-9c14-109608a6a221"), new Guid("503fc79e-3f52-435b-9222-254c8c1fc738"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("a71c917c-d48c-4236-a816-83350a9c25ee"), new Guid("5bada406-7bf0-41e7-8f6c-52f65760181c"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("aa55ac93-e119-4aaa-b1f7-ed8af687825c"), new Guid("c7f65971-5dcf-45e8-b146-3df6a710df2c"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("aa830101-9350-4adf-8e06-7ba1c9c63588"), new Guid("410edf32-53fb-4242-9ca1-009ae499fcca"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("afdc6758-94fb-4312-8012-5bb5a0fe17bf"), new Guid("0aaa962a-8d64-4515-9659-63e37f98c8ca"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("c222f126-ab7e-4bcd-a379-86ca562bd505"), new Guid("1f52010f-c57c-4031-a666-4ad9c4076404"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("c35c989d-fba8-4a49-a570-369c2e7690b4"), new Guid("4f7c081e-b834-4fed-acfb-10d54e8c8f11"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("c588cfb0-8fcb-4808-a310-3d56a8f226a8"), new Guid("ee46d590-2457-4b01-95f1-3af291450552"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("d4e16d02-e46d-432a-b7fd-852703bc2b99"), new Guid("54e3c968-e8d4-4b43-87d6-6351076e0093"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("db07e1eb-b6e2-4be8-8982-7b92857bb4e9"), new Guid("348f5ae9-8ee7-40e1-bd13-0166e437ed1b"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("dc86b276-a3e3-4db7-b41c-f91479691cbc"), new Guid("3fb76b0e-bcf6-45a0-a141-42873cff242c"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("dfc3a9ac-79e9-47c1-bb64-93a5b38efa39"), new Guid("6a088364-cfa7-4e7c-8a31-17cddc9f1370"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("e2bfaaad-62c7-4a93-a801-d1d619872f91"), new Guid("90d0aaaf-793c-4cde-89ea-706cdd0c1a6d"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("e4afa176-d44e-4b9d-8af6-77fa958814e7"), new Guid("0a1f874b-af1c-4b3f-8d3e-2714eb2a6ca4"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("ebf94ba8-1187-4034-b1d8-deb0eb1b20e8"), new Guid("72d1cb2c-30b0-4b6c-a9cd-d471940f7b93"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("f31c456f-868c-464f-aabc-92c07da30dad"), new Guid("489facd4-0546-4e91-9d2d-26afc5e60080"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("fcb5d0c4-4bc9-4a92-8f40-b0a767922b71"), new Guid("19f3b0e7-cc0b-44ba-ad7f-3ad17bcc9949"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
                    { new Guid("fdbef808-0497-4340-b11c-e5847b48fad3"), new Guid("a4f2229d-cd70-4c4f-a0fa-39e2f9e4a639"), new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfigurationId", "Email", "FirstName", "IsMale", "LastName", "LeadId", "Password", "RoleId", "Username" },
                values: new object[] { new Guid("672a5cb2-73fb-4f4c-8764-a6c104a3062d"), new Guid("ed187966-ffc8-4897-becc-619cfe584445"), "SuperAdmin@dev.com", "Super", true, "Admin", null, "dCrinPZBjSOiUEfsVO0nGg==", new Guid("26c52004-d441-48d8-8e00-e2cea7e1d55a"), "SuperAdminDev" });

            migrationBuilder.CreateIndex(
                name: "IX_TemporalPermissions_PermissionId",
                table: "TemporalPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporalPermissions_RoleId",
                table: "TemporalPermissions",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemporalPermissions");

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("24d897b2-e36c-4e3e-a60e-5075535f7352"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("dde063f6-79da-4707-852c-62260ffb82af"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("05958f1c-844a-43e9-9bcb-6667dad75670"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0678fae5-e577-4fd5-a759-ae3fb0fd9d6b"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0a1f874b-af1c-4b3f-8d3e-2714eb2a6ca4"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0aaa962a-8d64-4515-9659-63e37f98c8ca"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0fe9b79f-8bf5-4742-8284-5414494988b0"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("161ab07a-92d0-422e-a7df-20e69238dad7"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("19f3b0e7-cc0b-44ba-ad7f-3ad17bcc9949"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("1f52010f-c57c-4031-a666-4ad9c4076404"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("24395707-0c33-42fe-bc05-39bd9b5e0485"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2ad66724-24d7-4a86-b512-7cf5a4c4bfc3"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2dd17f8f-6e80-4e60-919d-e304b90d0f46"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2f6a2460-7e0c-4677-a9a7-0c90ac88e2c7"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("348f5ae9-8ee7-40e1-bd13-0166e437ed1b"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3bd9aa44-f431-43a6-8b0a-ca99b77d100c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3fb76b0e-bcf6-45a0-a141-42873cff242c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("410edf32-53fb-4242-9ca1-009ae499fcca"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("489facd4-0546-4e91-9d2d-26afc5e60080"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("4f7c081e-b834-4fed-acfb-10d54e8c8f11"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("503fc79e-3f52-435b-9222-254c8c1fc738"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("54b2a2a2-eccb-4241-8ece-d4e5a9beebaa"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("54e3c968-e8d4-4b43-87d6-6351076e0093"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("588ec542-ed55-4e66-9215-1c9216c5c914"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("5bada406-7bf0-41e7-8f6c-52f65760181c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("6a088364-cfa7-4e7c-8a31-17cddc9f1370"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("717a6cae-0844-4666-9621-c7082a8b9539"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("72d1cb2c-30b0-4b6c-a9cd-d471940f7b93"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("75cf41d2-ca8f-4cb0-a37c-e3b34ddcb8c9"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("7816c0b8-4db8-4a8b-b171-824a179709d2"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("8682fd93-c365-48f6-a363-720fd272a589"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("8cbaaf22-3f25-4e50-b4b9-cc5f4a78ba6c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9054c555-4a30-495b-95d4-fff561ce11c6"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("90d0aaaf-793c-4cde-89ea-706cdd0c1a6d"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("929d0a6d-6b2d-4391-aa79-c4859b9cfa57"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a4f2229d-cd70-4c4f-a0fa-39e2f9e4a639"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b3deaccb-bd01-4cd6-a543-9a001a93101c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ba75c802-413c-4209-abb5-d92fe883061c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("bbb2b3dc-b3a5-4ce4-811c-7750cba00c59"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("c7f65971-5dcf-45e8-b146-3df6a710df2c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("cbd3a20b-a12a-437d-b130-ef77cb174edf"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("cc7d6a95-da2c-4eca-b0fd-7e711600027e"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d274575a-c4f2-4d0a-ab6a-c634fabf9c15"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("dc508983-5917-4752-8ccc-1c6674234417"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e7c19a6f-64d5-47a7-bb93-00aa103a884a"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ee46d590-2457-4b01-95f1-3af291450552"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f6042a14-5907-4a6e-9417-0519cc422160"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ffe00ecd-e320-4a9d-84d7-2d3b2d16aa7b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("672a5cb2-73fb-4f4c-8764-a6c104a3062d"));

            migrationBuilder.DeleteData(
                table: "Configurations",
                keyColumn: "Id",
                keyValue: new Guid("ed187966-ffc8-4897-becc-619cfe584445"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Permissions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
