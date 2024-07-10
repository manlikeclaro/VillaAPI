using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateVillaNumberTableAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                });

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "VillaNo", "Created", "Details", "Updated" },
                values: new object[] { 101, new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(7121), "Disabled Access", null });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6777));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6806));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2024, 7, 10, 10, 38, 44, 575, DateTimeKind.Local).AddTicks(6810));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4874));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2024, 7, 8, 12, 56, 27, 825, DateTimeKind.Local).AddTicks(4961));
        }
    }
}
