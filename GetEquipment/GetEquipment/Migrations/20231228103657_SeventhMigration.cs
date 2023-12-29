using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GetEquipment.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appoitments_Companies_companyID",
                table: "Appoitments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.RenameColumn(
                name: "isSuccessful",
                table: "Appoitments",
                newName: "isReserved");

            migrationBuilder.RenameColumn(
                name: "companyID",
                table: "Appoitments",
                newName: "WorkCalendarcalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_Appoitments_companyID",
                table: "Appoitments",
                newName: "IX_Appoitments_WorkCalendarcalendarId");

            migrationBuilder.AddColumn<Guid>(
                name: "adminId",
                table: "Appoitments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "durationH",
                table: "Appoitments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkCalendars",
                columns: table => new
                {
                    calendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    companyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkCalendars", x => x.calendarId);
                    table.ForeignKey(
                        name: "FK_WorkCalendars_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "companyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkCalendars_companyId",
                table: "WorkCalendars",
                column: "companyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appoitments_WorkCalendars_WorkCalendarcalendarId",
                table: "Appoitments",
                column: "WorkCalendarcalendarId",
                principalTable: "WorkCalendars",
                principalColumn: "calendarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appoitments_WorkCalendars_WorkCalendarcalendarId",
                table: "Appoitments");

            migrationBuilder.DropTable(
                name: "WorkCalendars");

            migrationBuilder.DropColumn(
                name: "adminId",
                table: "Appoitments");

            migrationBuilder.DropColumn(
                name: "durationH",
                table: "Appoitments");

            migrationBuilder.RenameColumn(
                name: "isReserved",
                table: "Appoitments",
                newName: "isSuccessful");

            migrationBuilder.RenameColumn(
                name: "WorkCalendarcalendarId",
                table: "Appoitments",
                newName: "companyID");

            migrationBuilder.RenameIndex(
                name: "IX_Appoitments_WorkCalendarcalendarId",
                table: "Appoitments",
                newName: "IX_Appoitments_companyID");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    reservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectedAppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.reservationId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appoitments_Companies_companyID",
                table: "Appoitments",
                column: "companyID",
                principalTable: "Companies",
                principalColumn: "companyID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
