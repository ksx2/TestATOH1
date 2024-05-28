using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestATOH1.Migrations
{
    /// <inheritdoc />
    public partial class Nullabletypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("5d380b28-1249-4261-a0cf-b7933b1dc5ee"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RevokedOn",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "RevokedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "PasswordHash", "RevokedBy", "RevokedOn" },
                values: new object[] { new Guid("fcf1e18d-5603-4055-b665-d9dbdf80edcf"), true, new DateOnly(9999, 12, 31), "admin", new DateTime(2024, 5, 18, 21, 28, 20, 968, DateTimeKind.Local).AddTicks(8741), 1, "Admin", "admin", new DateTime(2024, 5, 18, 21, 28, 20, 968, DateTimeKind.Local).AddTicks(8759), "Max", "$2a$11$b1F7dpcE7D1L6YGAbZlk.ub5gvtfqpahG5K66K9CiAxzO99nZoifS", "admin", new DateTime(2024, 5, 18, 21, 28, 20, 968, DateTimeKind.Local).AddTicks(8765) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("fcf1e18d-5603-4055-b665-d9dbdf80edcf"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RevokedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RevokedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "PasswordHash", "RevokedBy", "RevokedOn" },
                values: new object[] { new Guid("5d380b28-1249-4261-a0cf-b7933b1dc5ee"), true, new DateOnly(9999, 12, 31), "admin", new DateTime(2024, 5, 15, 17, 0, 17, 424, DateTimeKind.Local).AddTicks(2160), 1, "Admin", "admin", new DateTime(2024, 5, 15, 17, 0, 17, 424, DateTimeKind.Local).AddTicks(2191), "Max", "$2a$11$YgBuH4AJawbggNxpUPXCuOMjIIOHIlICxdWjQM1LdkAy8C97h4J6m", "admin", new DateTime(2024, 5, 15, 17, 0, 17, 424, DateTimeKind.Local).AddTicks(2193) });
        }
    }
}
