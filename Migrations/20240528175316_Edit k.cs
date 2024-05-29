using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestATOH1.Migrations
{
    /// <inheritdoc />
    public partial class Editk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("f0f0aee8-b928-4fa8-a4f2-c760e5171ed1"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "PasswordHash", "RevokedBy", "RevokedOn" },
                values: new object[] { new Guid("43b0dc01-04f2-4777-abc7-ade84bdd8613"), true, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "admin", new DateTime(2024, 5, 28, 20, 53, 15, 584, DateTimeKind.Local).AddTicks(1903), 1, "Admin", "", new DateTime(2024, 5, 28, 20, 53, 15, 584, DateTimeKind.Local).AddTicks(1919), "Max", "$2a$11$1iIM0FCYzNJhhY0zlvR8MOFKY4rFlZcxChc/1tOiKqxiHFVQhn6p.", "", new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("43b0dc01-04f2-4777-abc7-ade84bdd8613"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "PasswordHash", "RevokedBy", "RevokedOn" },
                values: new object[] { new Guid("f0f0aee8-b928-4fa8-a4f2-c760e5171ed1"), true, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "admin", new DateTime(2024, 5, 28, 20, 23, 54, 119, DateTimeKind.Local).AddTicks(1909), 1, "Admin", "admin", new DateTime(2024, 5, 28, 20, 23, 54, 119, DateTimeKind.Local).AddTicks(1929), "Max", "$2a$11$EFl0yT/Clx.S4Sj06OyNqukvslidcpRyt6dJZUfSI1HrmmsaukNu6", "admin", new DateTime(2024, 5, 28, 20, 23, 54, 119, DateTimeKind.Local).AddTicks(1932) });
        }
    }
}
