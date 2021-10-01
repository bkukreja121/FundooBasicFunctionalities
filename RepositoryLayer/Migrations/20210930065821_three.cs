using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 28, 20, 980, DateTimeKind.Local).AddTicks(3594), new DateTime(2021, 9, 30, 12, 28, 20, 980, DateTimeKind.Local).AddTicks(7329) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 22, 52, 9, 344, DateTimeKind.Local).AddTicks(8365), new DateTime(2021, 9, 29, 22, 52, 9, 345, DateTimeKind.Local).AddTicks(1723) });
        }
    }
}
