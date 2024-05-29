using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestATOH1.Migrations
{
    /// <inheritdoc />
    public partial class Editt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("6577bef8-c3ac-4aad-ac79-2feba0bb411f"));

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
                values: new object[] { new Guid("f0f0aee8-b928-4fa8-a4f2-c760e5171ed1"), true, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "admin", new DateTime(2024, 5, 28, 20, 23, 54, 119, DateTimeKind.Local).AddTicks(1909), 1, "Admin", "admin", new DateTime(2024, 5, 28, 20, 23, 54, 119, DateTimeKind.Local).AddTicks(1929), "Max", "$2a$11$EFl0yT/Clx.S4Sj06OyNqukvslidcpRyt6dJZUfSI1HrmmsaukNu6", "admin", new DateTime(2024, 5, 28, 20, 23, 54, 119, DateTimeKind.Local).AddTicks(1932) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("f0f0aee8-b928-4fa8-a4f2-c760e5171ed1"));

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
                values: new object[] { new Guid("6577bef8-c3ac-4aad-ac79-2feba0bb411f"), true, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "admin", new DateTime(2024, 5, 28, 20, 12, 21, 248, DateTimeKind.Local).AddTicks(6646), 1, "Admin", "admin", new DateTime(2024, 5, 28, 20, 12, 21, 248, DateTimeKind.Local).AddTicks(6682), "Max", "$2a$11$sBEcnHq4SEDY/wNe66iH2OU9PXze0hLTueafE4qLv5M2oZ41lfMue", "admin", new DateTime(2024, 5, 28, 20, 12, 21, 248, DateTimeKind.Local).AddTicks(6685) });
        }
    }
}
