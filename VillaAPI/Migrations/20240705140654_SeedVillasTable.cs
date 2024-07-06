using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "Created", "Details", "ImgUrl", "Name", "Occupancy", "Rate", "SquareFeet", "Updated" },
                values: new object[,]
                {
                    { 1, "Pool, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3304), "A beautiful villa by the sea.", "http://example.com/villa1.jpg", "Sea Breeze", 4, 2500m, 2000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Fireplace, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3329), "A serene mountain retreat.", "http://example.com/villa2.jpg", "Mountain Retreat", 6, 3000m, 2500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Gym, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3335), "A modern villa in the city.", "http://example.com/villa3.jpg", "Urban Oasis", 3, 4000m, 1500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Garden, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3341), "A cozy country cottage.", "http://example.com/villa4.jpg", "Country Cottage", 5, 1500m, 1800, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Pool, Wi-Fi, BBQ", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3346), "A stunning house on the beach.", "http://example.com/villa5.jpg", "Beach House", 8, 3500m, 2200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Hiking Trails, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3351), "A secluded hideaway in the forest.", "http://example.com/villa6.jpg", "Forest Hideaway", 4, 2800m, 2100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Pool, Wi-Fi, Air Conditioning", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3356), "A luxurious villa in the desert.", "http://example.com/villa7.jpg", "Desert Villa", 6, 3200m, 2300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Fishing, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3360), "A peaceful house by the lake.", "http://example.com/villa8.jpg", "Lake House", 5, 2700m, 2400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Pool, Wi-Fi, BBQ", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3365), "A villa in a tropical paradise.", "http://example.com/villa9.jpg", "Tropical Paradise", 10, 4500m, 3000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Library, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3370), "A historic manor with modern amenities.", "http://example.com/villa10.jpg", "Historic Manor", 12, 5000m, 3500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Ski-in/Ski-out, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3374), "A chalet near the ski slopes.", "http://example.com/villa11.jpg", "Ski Chalet", 6, 3800m, 2600, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Gym, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3379), "A chic loft in the heart of the city.", "http://example.com/villa12.jpg", "City Loft", 2, 3400m, 1400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Fireplace, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3384), "A rustic cabin in the woods.", "http://example.com/villa13.jpg", "Rustic Cabin", 4, 1600m, 1700, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Pool, Gym, Wi-Fi", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3389), "A modern mansion with luxurious amenities.", "http://example.com/villa14.jpg", "Modern Mansion", 15, 6000m, 4000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Garden, Wi-Fi, BBQ", new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3393), "An estate in the countryside.", "http://example.com/villa15.jpg", "Countryside Estate", 10, 4500m, 3200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
