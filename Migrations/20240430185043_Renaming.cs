using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hillary.Migrations
{
    /// <inheritdoc />
    public partial class Renaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Campsites_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Stylists_StylistId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_CampsiteTypes_ServiceId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Reservations_AppointmentId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campsites",
                table: "Campsites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CampsiteTypes",
                table: "CampsiteTypes");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "AppointmentServices");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Appointments");

            migrationBuilder.RenameTable(
                name: "Campsites",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "CampsiteTypes",
                newName: "Services");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_ServiceId",
                table: "AppointmentServices",
                newName: "IX_AppointmentServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_AppointmentId",
                table: "AppointmentServices",
                newName: "IX_AppointmentServices_AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_StylistId",
                table: "Appointments",
                newName: "IX_Appointments_StylistId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerId",
                table: "Appointments",
                newName: "IX_Appointments_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentServices",
                table: "AppointmentServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduledDate",
                value: new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Appointments_AppointmentId",
                table: "AppointmentServices",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Services_ServiceId",
                table: "AppointmentServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Customers_CustomerId",
                table: "Appointments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Stylists_StylistId",
                table: "Appointments",
                column: "StylistId",
                principalTable: "Stylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Appointments_AppointmentId",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Services_ServiceId",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Customers_CustomerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Stylists_StylistId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentServices",
                table: "AppointmentServices");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "CampsiteTypes");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Campsites");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "AppointmentServices",
                newName: "UserProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_StylistId",
                table: "Reservations",
                newName: "IX_Reservations_StylistId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_CustomerId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentServices_ServiceId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentServices_AppointmentId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_AppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CampsiteTypes",
                table: "CampsiteTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campsites",
                table: "Campsites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduledDate",
                value: new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Campsites_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Campsites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Stylists_StylistId",
                table: "Reservations",
                column: "StylistId",
                principalTable: "Stylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_CampsiteTypes_ServiceId",
                table: "UserProfiles",
                column: "ServiceId",
                principalTable: "CampsiteTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Reservations_AppointmentId",
                table: "UserProfiles",
                column: "AppointmentId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
