﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WmBlazor.Server.Data;

#nullable disable

namespace WmBlazor.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220310235457_AddDevelopers")]
    partial class AddDevelopers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WmBlazor.Shared.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Colossal order are a game developer",
                            Name = "Colossal Order"
                        },
                        new
                        {
                            Id = 2,
                            Description = "System Era Softworks are an indie developer famous for Astroneer",
                            Name = "System Era Softworks"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A world famous games developer",
                            Name = "BANDAI NAMCO Studios Inc."
                        },
                        new
                        {
                            Id = 4,
                            Description = "A games studio famous for their racing simulators",
                            Name = "Kunos Simulazioni"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Ewwwwwww",
                            Name = "EA Sports"
                        });
                });

            modelBuilder.Entity("WmBlazor.Shared.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PriceGb")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A city-building game by Colossal Order.",
                            DeveloperId = 1,
                            Name = "Cities Skylines",
                            PriceGb = 22.99m
                        },
                        new
                        {
                            Id = 2,
                            Description = "A space exploration game by System Era Softworks",
                            DeveloperId = 2,
                            Name = "Astroneer",
                            PriceGb = 23.79m
                        },
                        new
                        {
                            Id = 3,
                            Description = "A combat flight simulator by BANDAI NAMCO Studios Inc.",
                            DeveloperId = 3,
                            Name = "Ace Combat 7: Skies Unknown",
                            PriceGb = 49.99m
                        },
                        new
                        {
                            Id = 4,
                            Description = "A racing simulator by Kunos Simulazoni",
                            DeveloperId = 4,
                            Name = "Assetto Corsa Competizione",
                            PriceGb = 34.99m
                        },
                        new
                        {
                            Id = 5,
                            Description = "A golf simulator by EA Sports. Eeeeewww",
                            DeveloperId = 5,
                            Name = "PGA Tour 2K21",
                            PriceGb = 49.99m
                        });
                });

            modelBuilder.Entity("WmBlazor.Shared.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Member"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("WmBlazor.Shared.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Username");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Username = "mtownsend",
                            PasswordHash = new byte[] { 80, 99, 109, 75, 122, 43, 101, 71, 108, 101, 112, 75, 99, 75, 48, 66, 50, 76, 115, 83, 99, 73, 110, 85, 71, 72, 52, 43, 90, 102, 47, 51, 48, 75, 117, 98, 108, 122, 51, 80, 67, 85, 48, 52, 114, 49, 104, 57, 49, 109, 43, 114, 112, 53, 75, 87, 71, 102, 74, 89, 43, 65, 113, 102, 102, 99, 113, 112, 90, 97, 85, 51, 70, 83, 98, 75, 82, 121, 70, 103, 107, 98, 49, 72, 106, 119, 61, 61 },
                            PasswordSalt = new byte[] { 97, 107, 87, 120, 109, 120, 85, 67, 48, 118, 114, 68, 100, 118, 66, 121, 120, 49, 76, 70, 68, 48, 114, 77, 99, 66, 73, 90, 98, 51, 54, 65, 53, 50, 75, 77, 78, 90, 57, 84, 70, 50, 50, 105, 89, 55, 103, 118, 73, 49, 65, 90, 112, 54, 82, 77, 116, 55, 71, 117, 104, 43, 83, 84, 83, 50, 47, 101, 68, 111, 120, 113, 74, 118, 109, 86, 79, 116, 83, 113, 115, 78, 54, 65, 74, 100, 54, 73, 114, 98, 120, 54, 49, 113, 106, 51, 111, 114, 76, 106, 122, 87, 110, 52, 53, 105, 90, 97, 81, 115, 53, 67, 113, 50, 118, 111, 113, 102, 122, 70, 90, 101, 87, 118, 72, 110, 68, 78, 120, 51, 52, 71, 87, 116, 104, 68, 99, 104, 84, 120, 99, 113, 113, 76, 114, 70, 69, 121, 122, 57, 76, 51, 52, 87, 83, 48, 121, 65, 54, 79, 120, 108, 52, 81, 100, 100, 56, 100, 66, 121, 89, 61 },
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("WmBlazor.Shared.Game", b =>
                {
                    b.HasOne("WmBlazor.Shared.Developer", "Developer")
                        .WithMany("Games")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("WmBlazor.Shared.User", b =>
                {
                    b.HasOne("WmBlazor.Shared.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WmBlazor.Shared.Developer", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}