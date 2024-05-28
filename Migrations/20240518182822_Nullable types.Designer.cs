﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestATOH1.Models.DataBaseContext;

#nullable disable

namespace TestATOH1.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    [Migration("20240518182822_Nullable types")]
    partial class Nullabletypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestATOH1.Models.UserModel", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RevokedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RevokedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("fcf1e18d-5603-4055-b665-d9dbdf80edcf"),
                            Admin = true,
                            Birthday = new DateOnly(9999, 12, 31),
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2024, 5, 18, 21, 28, 20, 968, DateTimeKind.Local).AddTicks(8741),
                            Gender = 1,
                            Login = "Admin",
                            ModifiedBy = "admin",
                            ModifiedOn = new DateTime(2024, 5, 18, 21, 28, 20, 968, DateTimeKind.Local).AddTicks(8759),
                            Name = "Max",
                            PasswordHash = "$2a$11$b1F7dpcE7D1L6YGAbZlk.ub5gvtfqpahG5K66K9CiAxzO99nZoifS",
                            RevokedBy = "admin",
                            RevokedOn = new DateTime(2024, 5, 18, 21, 28, 20, 968, DateTimeKind.Local).AddTicks(8765)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}