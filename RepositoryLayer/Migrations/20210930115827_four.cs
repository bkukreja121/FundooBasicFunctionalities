using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollaborationId",
                table: "Collaborations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 30, 17, 28, 26, 684, DateTimeKind.Local).AddTicks(2943), new DateTime(2021, 9, 30, 17, 28, 26, 684, DateTimeKind.Local).AddTicks(5946) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollaborationId",
                table: "Collaborations");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 28, 20, 980, DateTimeKind.Local).AddTicks(3594), new DateTime(2021, 9, 30, 12, 28, 20, 980, DateTimeKind.Local).AddTicks(7329) });
        }
    }
}
