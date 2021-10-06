using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 10, 6, 22, 41, 44, 567, DateTimeKind.Local).AddTicks(2719), new DateTime(2021, 10, 6, 22, 41, 44, 567, DateTimeKind.Local).AddTicks(6034) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 10, 6, 22, 40, 53, 319, DateTimeKind.Local).AddTicks(5622), new DateTime(2021, 10, 6, 22, 40, 53, 319, DateTimeKind.Local).AddTicks(8656) });
        }
    }
}
