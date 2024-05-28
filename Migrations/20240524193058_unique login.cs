using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestATOH1.Migrations
{
    /// <inheritdoc />
    public partial class uniquelogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("fcf1e18d-5603-4055-b665-d9dbdf80edcf"));

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "PasswordHash", "RevokedBy", "RevokedOn" },
                values: new object[] { new Guid("236fe2fc-60dd-437c-9d03-0afdd780e271"), true, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "admin", new DateTime(2024, 5, 24, 22, 30, 57, 164, DateTimeKind.Local).AddTicks(9843), 1, "Admin", "admin", new DateTime(2024, 5, 24, 22, 30, 57, 164, DateTimeKind.Local).AddTicks(9872), "Max", "$2a$11$5JzOtMamY5cif8IiFTioAueZ6S.GxVXGgk6mml/nf0MgAGAiVg3sy", "admin", new DateTime(2024, 5, 24, 22, 30, 57, 164, DateTimeKind.Local).AddTicks(9880) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("236fe2fc-60dd-437c-9d03-0afdd780e271"));

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                values: new object[] { new Guid("fcf1e18d-5603-4055-b665-d9dbdf80edcf"), true, new DateOnly(9999, 12, 31), "admin", new DateTime(2024, 5, 18, 21, 28, 20, 968, DateTimeKind.Local).AddTicks(8741), 1, "Admin", "admin", new DateTime(2024, 5, 18, 21, 28, 20, 968, DateTimeKind.Local).AddTicks(8759), "Max", "$2a$11$b1F7dpcE7D1L6YGAbZlk.ub5gvtfqpahG5K66K9CiAxzO99nZoifS", "admin", new DateTime(2024, 5, 18, 21, 28, 20, 968, DateTimeKind.Local).AddTicks(8765) });
        }
    }
}
