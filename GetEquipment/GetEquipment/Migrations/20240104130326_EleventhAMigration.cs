using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GetEquipment.Migrations
{
    public partial class EleventhAMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservedEquipments",
                columns: table => new
                {
                    ReservedEquipmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservedAppointmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedEquipments", x => x.ReservedEquipmentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservedEquipments");
        }
    }
}
