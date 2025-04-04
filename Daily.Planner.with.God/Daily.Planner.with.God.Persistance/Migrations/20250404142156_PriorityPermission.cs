using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class PriorityPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Permissions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("05958f1c-844a-43e9-9bcb-6667dad75670"),
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0678fae5-e577-4fd5-a759-ae3fb0fd9d6b"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0a1f874b-af1c-4b3f-8d3e-2714eb2a6ca4"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0aaa962a-8d64-4515-9659-63e37f98c8ca"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("0fe9b79f-8bf5-4742-8284-5414494988b0"),
                column: "Priority",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("161ab07a-92d0-422e-a7df-20e69238dad7"),
                column: "Priority",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("19f3b0e7-cc0b-44ba-ad7f-3ad17bcc9949"),
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("1f52010f-c57c-4031-a666-4ad9c4076404"),
                column: "Priority",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("24395707-0c33-42fe-bc05-39bd9b5e0485"),
                column: "Priority",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2a02728c-4408-4628-84bf-3b9650df5705"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2ad66724-24d7-4a86-b512-7cf5a4c4bfc3"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2dd17f8f-6e80-4e60-919d-e304b90d0f46"),
                column: "Priority",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2f6a2460-7e0c-4677-a9a7-0c90ac88e2c7"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("348f5ae9-8ee7-40e1-bd13-0166e437ed1b"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3bd9aa44-f431-43a6-8b0a-ca99b77d100c"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3fb76b0e-bcf6-45a0-a141-42873cff242c"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("410edf32-53fb-4242-9ca1-009ae499fcca"),
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("489facd4-0546-4e91-9d2d-26afc5e60080"),
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("4f7c081e-b834-4fed-acfb-10d54e8c8f11"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("503fc79e-3f52-435b-9222-254c8c1fc738"),
                columns: new[] { "Priority", "SystemName" },
                values: new object[] { 1, "CSMAV" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("54b2a2a2-eccb-4241-8ece-d4e5a9beebaa"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("54e3c968-e8d4-4b43-87d6-6351076e0093"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("588ec542-ed55-4e66-9215-1c9216c5c914"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("5bada406-7bf0-41e7-8f6c-52f65760181c"),
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("6a088364-cfa7-4e7c-8a31-17cddc9f1370"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("717a6cae-0844-4666-9621-c7082a8b9539"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("72d1cb2c-30b0-4b6c-a9cd-d471940f7b93"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("75cf41d2-ca8f-4cb0-a37c-e3b34ddcb8c9"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("7816c0b8-4db8-4a8b-b171-824a179709d2"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("8682fd93-c365-48f6-a363-720fd272a589"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("8cbaaf22-3f25-4e50-b4b9-cc5f4a78ba6c"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9054c555-4a30-495b-95d4-fff561ce11c6"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("90d0aaaf-793c-4cde-89ea-706cdd0c1a6d"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("929d0a6d-6b2d-4391-aa79-c4859b9cfa57"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("95a80530-1b8a-4a6b-9c88-d0f57ad03fcb"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("96f97762-8b1e-46d8-8450-f52e85c2c2ac"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a4f2229d-cd70-4c4f-a0fa-39e2f9e4a639"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b3deaccb-bd01-4cd6-a543-9a001a93101c"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ba75c802-413c-4209-abb5-d92fe883061c"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("bbb2b3dc-b3a5-4ce4-811c-7750cba00c59"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("c7f65971-5dcf-45e8-b146-3df6a710df2c"),
                column: "Priority",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("cbd3a20b-a12a-437d-b130-ef77cb174edf"),
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("cc7d6a95-da2c-4eca-b0fd-7e711600027e"),
                column: "Priority",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d274575a-c4f2-4d0a-ab6a-c634fabf9c15"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("dc508983-5917-4752-8ccc-1c6674234417"),
                column: "Priority",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e7c19a6f-64d5-47a7-bb93-00aa103a884a"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ee46d590-2457-4b01-95f1-3af291450552"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f6042a14-5907-4a6e-9417-0519cc422160"),
                column: "Priority",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ffe00ecd-e320-4a9d-84d7-2d3b2d16aa7b"),
                columns: new[] { "Description", "Priority" },
                values: new object[] { "Puede ver la vista de Manejar tus peticiones", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("503fc79e-3f52-435b-9222-254c8c1fc738"),
                column: "SystemName",
                value: "CSHV");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ffe00ecd-e320-4a9d-84d7-2d3b2d16aa7b"),
                column: "Description",
                value: "Puede ver la vista de Peticiones");
        }
    }
}
