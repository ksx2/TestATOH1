using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestATOH1.Migrations
{
    /// <inheritdoc />
    public partial class PasswordEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("4b9d4258-4f99-4264-b6c9-0a5d3202e37f"));

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Birthday",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "PasswordHash", "RevokedBy", "RevokedOn" },
                values: new object[] { new Guid("5d380b28-1249-4261-a0cf-b7933b1dc5ee"), true, new DateOnly(9999, 12, 31), "admin", new DateTime(2024, 5, 15, 17, 0, 17, 424, DateTimeKind.Local).AddTicks(2160), 1, "Admin", "admin", new DateTime(2024, 5, 15, 17, 0, 17, 424, DateTimeKind.Local).AddTicks(2191), "Max", "$2a$11$YgBuH4AJawbggNxpUPXCuOMjIIOHIlICxdWjQM1LdkAy8C97h4J6m", "admin", new DateTime(2024, 5, 15, 17, 0, 17, 424, DateTimeKind.Local).AddTicks(2193) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("5d380b28-1249-4261-a0cf-b7933b1dc5ee"));

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "Password", "RevokedBy", "RevokedOn" },
                values: new object[] { new Guid("4b9d4258-4f99-4264-b6c9-0a5d3202e37f"), true, new DateTime(2024, 5, 13, 21, 58, 43, 629, DateTimeKind.Local).AddTicks(9547), "admin", new DateTime(2024, 5, 13, 21, 58, 43, 629, DateTimeKind.Local).AddTicks(9570), 1, "Admin", "admin", new DateTime(2024, 5, 13, 21, 58, 43, 629, DateTimeKind.Local).AddTicks(9572), "Max", "admin", "admin", new DateTime(2024, 5, 13, 21, 58, 43, 629, DateTimeKind.Local).AddTicks(9574) });
        }
    }
}
