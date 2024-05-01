using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hillary.Migrations
{
    /// <inheritdoc />
    public partial class RenamingStylistNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Service 1");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Service 2");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Service 3");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Service 4");

            migrationBuilder.UpdateData(
                table: "Stylists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Stylist 1");

            migrationBuilder.UpdateData(
                table: "Stylists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Stylist 2");

            migrationBuilder.UpdateData(
                table: "Stylists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Stylist 3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Customer 1");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Customer 2");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Customer 3");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Customer 4");

            migrationBuilder.UpdateData(
                table: "Stylists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Customer 1");

            migrationBuilder.UpdateData(
                table: "Stylists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Customer 2");

            migrationBuilder.UpdateData(
                table: "Stylists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Customer 3");
        }
    }
}
