using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daily.Planner.with.God.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NewPropCardUppercase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "reported",
                table: "Cards",
                newName: "Reported");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reported",
                table: "Cards",
                newName: "reported");
        }
    }
}
