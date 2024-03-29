﻿// <auto-generated />
using System;
using GetEquipment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GetEquipment.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240104130326_EleventhAMigration")]
    partial class EleventhAMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GetEquipment.Model.Appointment", b =>
                {
                    b.Property<Guid>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAndTimeOfAppointment")
                        .HasColumnType("datetime2");

                    b.Property<int>("DurationH")
                        .HasColumnType("int");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<Guid>("WorkCalendarID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AppointmentID");

                    b.HasIndex("WorkCalendarID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("GetEquipment.Model.Company", b =>
                {
                    b.Property<Guid>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("GetEquipment.Model.Equipment", b =>
                {
                    b.Property<Guid>("EquipmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<Guid>("CompanyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EquipmentType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("GetEquipment.Model.ReservedEquipment", b =>
                {
                    b.Property<Guid>("ReservedEquipmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EquipmentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReservedAppointmentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReservedEquipmentID");

                    b.ToTable("ReservedEquipments");
                });

            modelBuilder.Entity("GetEquipment.Model.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Penalty")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GetEquipment.Model.WorkCalendar", b =>
                {
                    b.Property<Guid>("CalendarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CalendarId");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("WorkCalendars");
                });

            modelBuilder.Entity("GetEquipment.Model.Appointment", b =>
                {
                    b.HasOne("GetEquipment.Model.WorkCalendar", null)
                        .WithMany("Appointments")
                        .HasForeignKey("WorkCalendarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GetEquipment.Model.Equipment", b =>
                {
                    b.HasOne("GetEquipment.Model.Company", null)
                        .WithMany("EquipmentInStock")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GetEquipment.Model.WorkCalendar", b =>
                {
                    b.HasOne("GetEquipment.Model.Company", null)
                        .WithOne("WorkCalendar")
                        .HasForeignKey("GetEquipment.Model.WorkCalendar", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GetEquipment.Model.Company", b =>
                {
                    b.Navigation("EquipmentInStock");

                    b.Navigation("WorkCalendar");
                });

            modelBuilder.Entity("GetEquipment.Model.WorkCalendar", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
