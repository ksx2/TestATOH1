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
    [Migration("20240528165634_Edit Types")]
    partial class EditTypes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestATOH1.Models.UserModels.UserModel", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Birthday")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RevokedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RevokedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("58830687-fe52-4098-a70a-12762c239e9d"),
                            Admin = true,
                            Birthday = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            CreatedBy = "admin",
                            CreatedOn = new DateTime(2024, 5, 28, 19, 56, 32, 775, DateTimeKind.Local).AddTicks(8101),
                            Gender = 1,
                            Login = "Admin",
                            ModifiedBy = "admin",
                            ModifiedOn = new DateTime(2024, 5, 28, 19, 56, 32, 775, DateTimeKind.Local).AddTicks(8134),
                            Name = "Max",
                            PasswordHash = "$2a$11$I8ZEzZ3XjHONN7eOFV70tOdwwGSxP/r22KO9H8UD/6zchW9x8yD4q",
                            RevokedBy = "admin",
                            RevokedOn = new DateTime(2024, 5, 28, 19, 56, 32, 775, DateTimeKind.Local).AddTicks(8136)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
