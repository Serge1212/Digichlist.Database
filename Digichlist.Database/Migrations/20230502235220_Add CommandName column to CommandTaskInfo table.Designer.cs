﻿// <auto-generated />
using System;
using Digichlist.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Digichlist.Database.Migrations
{
    [DbContext(typeof(DigichlistContext))]
    [Migration("20230502235220_Add CommandName column to CommandTaskInfo table")]
    partial class AddCommandNamecolumntoCommandTaskInfotable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Digichlist.Database.Entities.CommandTaskInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ClosedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DefectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DefectId");

                    b.ToTable("CommandTasksInfo");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.Defect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ClosedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StatusChangedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Defects");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.DefectImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DefectId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("DefectId");

                    b.ToTable("DefectImages");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("CanAdd")
                        .HasColumnType("bit");

                    b.Property<bool>("CanBeAssigned")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.CommandTaskInfo", b =>
                {
                    b.HasOne("Digichlist.Database.Entities.Defect", "Defect")
                        .WithMany("CommandTasksInfo")
                        .HasForeignKey("DefectId");

                    b.Navigation("Defect");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.Defect", b =>
                {
                    b.HasOne("Digichlist.Database.Entities.User", "AssignedWorker")
                        .WithMany("Defects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("AssignedWorker");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.DefectImage", b =>
                {
                    b.HasOne("Digichlist.Database.Entities.Defect", "Defect")
                        .WithMany("DefectImages")
                        .HasForeignKey("DefectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Defect");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.User", b =>
                {
                    b.HasOne("Digichlist.Database.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.Defect", b =>
                {
                    b.Navigation("CommandTasksInfo");

                    b.Navigation("DefectImages");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Digichlist.Database.Entities.User", b =>
                {
                    b.Navigation("Defects");
                });
#pragma warning restore 612, 618
        }
    }
}
