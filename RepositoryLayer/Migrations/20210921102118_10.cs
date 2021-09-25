using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "LastName", "ModifiedAt", "Password" },
                values: new object[] { 1L, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "uncle.bob@gmail.com", "Uncle", "Bob", new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "LastName", "ModifiedAt", "Password" },
                values: new object[] { 2L, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "aunty.bob@gmail.com", "Aunty", "Bob", new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234" });
        }
    }
}
