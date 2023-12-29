using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GetEquipment.Migrations
{
    public partial class TenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appoitments");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAndTimeOfAppointment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationH = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkCalendarCalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_WorkCalendars_WorkCalendarCalendarId",
                        column: x => x.WorkCalendarCalendarId,
                        principalTable: "WorkCalendars",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_WorkCalendarCalendarId",
                table: "Appointments",
                column: "WorkCalendarCalendarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.CreateTable(
                name: "Appoitments",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAndTimeOfAppointment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationH = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkCalendarCalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appoitments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appoitments_WorkCalendars_WorkCalendarCalendarId",
                        column: x => x.WorkCalendarCalendarId,
                        principalTable: "WorkCalendars",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appoitments_WorkCalendarCalendarId",
                table: "Appoitments",
                column: "WorkCalendarCalendarId");
        }
    }
}
