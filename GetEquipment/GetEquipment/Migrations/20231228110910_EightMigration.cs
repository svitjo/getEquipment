using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GetEquipment.Migrations
{
    public partial class EightMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appoitments_WorkCalendars_WorkCalendarcalendarId",
                table: "Appoitments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Companies_companyID",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkCalendars_Companies_companyId",
                table: "WorkCalendars");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "WorkCalendars",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "calendarId",
                table: "WorkCalendars",
                newName: "CalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkCalendars_companyId",
                table: "WorkCalendars",
                newName: "IX_WorkCalendars_CompanyId");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "penalty",
                table: "Users",
                newName: "Penalty");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Users",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "isVerified",
                table: "Users",
                newName: "IsVerified");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Users",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Users",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "company",
                table: "Users",
                newName: "Company");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Users",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Users",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Equipments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "equipmentType",
                table: "Equipments",
                newName: "EquipmentType");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Equipments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "companyID",
                table: "Equipments",
                newName: "CompanyID");

            migrationBuilder.RenameColumn(
                name: "averageRating",
                table: "Equipments",
                newName: "AverageRating");

            migrationBuilder.RenameColumn(
                name: "equipmentID",
                table: "Equipments",
                newName: "EquipmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_companyID",
                table: "Equipments",
                newName: "IX_Equipments_CompanyID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Companies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "averageRating",
                table: "Companies",
                newName: "AverageRating");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Companies",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "companyID",
                table: "Companies",
                newName: "CompanyID");

            migrationBuilder.RenameColumn(
                name: "isReserved",
                table: "Appoitments",
                newName: "IsReserved");

            migrationBuilder.RenameColumn(
                name: "durationH",
                table: "Appoitments",
                newName: "DurationH");

            migrationBuilder.RenameColumn(
                name: "dateAndTimeOfAppointment",
                table: "Appoitments",
                newName: "DateAndTimeOfAppointment");

            migrationBuilder.RenameColumn(
                name: "adminId",
                table: "Appoitments",
                newName: "AdminId");

            migrationBuilder.RenameColumn(
                name: "WorkCalendarcalendarId",
                table: "Appoitments",
                newName: "WorkCalendarCalendarId");

            migrationBuilder.RenameColumn(
                name: "appointmentId",
                table: "Appoitments",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Appoitments_WorkCalendarcalendarId",
                table: "Appoitments",
                newName: "IX_Appoitments_WorkCalendarCalendarId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Appoitments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Appoitments_WorkCalendars_WorkCalendarCalendarId",
                table: "Appoitments",
                column: "WorkCalendarCalendarId",
                principalTable: "WorkCalendars",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Companies_CompanyID",
                table: "Equipments",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkCalendars_Companies_CompanyId",
                table: "WorkCalendars",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appoitments_WorkCalendars_WorkCalendarCalendarId",
                table: "Appoitments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Companies_CompanyID",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkCalendars_Companies_CompanyId",
                table: "WorkCalendars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Appoitments");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "WorkCalendars",
                newName: "companyId");

            migrationBuilder.RenameColumn(
                name: "CalendarId",
                table: "WorkCalendars",
                newName: "calendarId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkCalendars_CompanyId",
                table: "WorkCalendars",
                newName: "IX_WorkCalendars_companyId");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Penalty",
                table: "Users",
                newName: "penalty");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Users",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "IsVerified",
                table: "Users",
                newName: "isVerified");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Users",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Users",
                newName: "company");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Users",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Equipments",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "EquipmentType",
                table: "Equipments",
                newName: "equipmentType");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Equipments",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Equipments",
                newName: "companyID");

            migrationBuilder.RenameColumn(
                name: "AverageRating",
                table: "Equipments",
                newName: "averageRating");

            migrationBuilder.RenameColumn(
                name: "EquipmentID",
                table: "Equipments",
                newName: "equipmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_CompanyID",
                table: "Equipments",
                newName: "IX_Equipments_companyID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "AverageRating",
                table: "Companies",
                newName: "averageRating");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Companies",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Companies",
                newName: "companyID");

            migrationBuilder.RenameColumn(
                name: "WorkCalendarCalendarId",
                table: "Appoitments",
                newName: "WorkCalendarcalendarId");

            migrationBuilder.RenameColumn(
                name: "IsReserved",
                table: "Appoitments",
                newName: "isReserved");

            migrationBuilder.RenameColumn(
                name: "DurationH",
                table: "Appoitments",
                newName: "durationH");

            migrationBuilder.RenameColumn(
                name: "DateAndTimeOfAppointment",
                table: "Appoitments",
                newName: "dateAndTimeOfAppointment");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Appoitments",
                newName: "adminId");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Appoitments",
                newName: "appointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Appoitments_WorkCalendarCalendarId",
                table: "Appoitments",
                newName: "IX_Appoitments_WorkCalendarcalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appoitments_WorkCalendars_WorkCalendarcalendarId",
                table: "Appoitments",
                column: "WorkCalendarcalendarId",
                principalTable: "WorkCalendars",
                principalColumn: "calendarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Companies_companyID",
                table: "Equipments",
                column: "companyID",
                principalTable: "Companies",
                principalColumn: "companyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkCalendars_Companies_companyId",
                table: "WorkCalendars",
                column: "companyId",
                principalTable: "Companies",
                principalColumn: "companyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
