using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hillary.Migrations
{
    /// <inheritdoc />
    public partial class StylistActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Stylists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Stylists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Stylists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Stylists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Active",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Stylists");
        }
    }
}
