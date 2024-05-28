using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestATOH1.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "Password", "RevokedBy", "RevokedOn" },
                values: new object[] { new Guid("4b9d4258-4f99-4264-b6c9-0a5d3202e37f"), true, new DateTime(2024, 5, 13, 21, 58, 43, 629, DateTimeKind.Local).AddTicks(9547), "admin", new DateTime(2024, 5, 13, 21, 58, 43, 629, DateTimeKind.Local).AddTicks(9570), 1, "Admin", "admin", new DateTime(2024, 5, 13, 21, 58, 43, 629, DateTimeKind.Local).AddTicks(9572), "Max", "admin", "admin", new DateTime(2024, 5, 13, 21, 58, 43, 629, DateTimeKind.Local).AddTicks(9574) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("4b9d4258-4f99-4264-b6c9-0a5d3202e37f"));
        }
    }
}
