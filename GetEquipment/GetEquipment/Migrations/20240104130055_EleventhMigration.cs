using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GetEquipment.Migrations
{
    public partial class EleventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_WorkCalendars_WorkCalendarCalendarId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_WorkCalendarCalendarId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "WorkCalendarCalendarId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Appointments",
                newName: "AppointmentID");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkCalendarID",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_WorkCalendarID",
                table: "Appointments",
                column: "WorkCalendarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_WorkCalendars_WorkCalendarID",
                table: "Appointments",
                column: "WorkCalendarID",
                principalTable: "WorkCalendars",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_WorkCalendars_WorkCalendarID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_WorkCalendarID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "WorkCalendarID",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentID",
                table: "Appointments",
                newName: "AppointmentId");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkCalendarCalendarId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_WorkCalendarCalendarId",
                table: "Appointments",
                column: "WorkCalendarCalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_WorkCalendars_WorkCalendarCalendarId",
                table: "Appointments",
                column: "WorkCalendarCalendarId",
                principalTable: "WorkCalendars",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
