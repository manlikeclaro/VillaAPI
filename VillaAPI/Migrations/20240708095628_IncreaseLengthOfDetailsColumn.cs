using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseLengthOfDetailsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Villas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Villas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3341));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3389));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3393));
        }
    }
}
