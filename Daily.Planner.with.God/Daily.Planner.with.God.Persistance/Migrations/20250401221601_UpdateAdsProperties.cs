using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdsProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGlobal",
                table: "Ads",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserCreatedId",
                table: "Ads",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UserCreatedId",
                table: "Ads",
                column: "UserCreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_UserCreatedId",
                table: "Ads",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Users_UserCreatedId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_UserCreatedId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "IsGlobal",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "Ads");
        }
    }
}
