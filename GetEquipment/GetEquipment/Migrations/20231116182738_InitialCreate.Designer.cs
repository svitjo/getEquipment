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
    [Migration("20231116182738_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GetEquipment.Model.Appoitment", b =>
                {
                    b.Property<Guid>("appointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("companyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateAndTimeOfAppointment")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isSuccessful")
                        .HasColumnType("bit");

                    b.HasKey("appointmentId");

                    b.HasIndex("companyID");

                    b.ToTable("Appoitments");
                });

            modelBuilder.Entity("GetEquipment.Model.Company", b =>
                {
                    b.Property<Guid>("companyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("averageRating")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("GetEquipment.Model.Equipment", b =>
                {
                    b.Property<Guid>("equipmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("averageRating")
                        .HasColumnType("float");

                    b.Property<Guid?>("companyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("equipmentType")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("equipmentID");

                    b.HasIndex("companyID");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("GetEquipment.Model.User", b =>
                {
                    b.Property<Guid>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isVerified")
                        .HasColumnType("bit");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("penalty")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GetEquipment.Model.Appoitment", b =>
                {
                    b.HasOne("GetEquipment.Model.Company", null)
                        .WithMany("pickUpAppointments")
                        .HasForeignKey("companyID");
                });

            modelBuilder.Entity("GetEquipment.Model.Equipment", b =>
                {
                    b.HasOne("GetEquipment.Model.Company", null)
                        .WithMany("equipmentInStock")
                        .HasForeignKey("companyID");
                });

            modelBuilder.Entity("GetEquipment.Model.Company", b =>
                {
                    b.Navigation("equipmentInStock");

                    b.Navigation("pickUpAppointments");
                });
#pragma warning restore 612, 618
        }
    }
}