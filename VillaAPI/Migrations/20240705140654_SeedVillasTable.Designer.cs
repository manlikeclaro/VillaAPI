﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VillaAPI.Models;

#nullable disable

namespace VillaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240705140654_SeedVillasTable")]
    partial class SeedVillasTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VillaAPI.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SquareFeet")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "Pool, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3304),
                            Details = "A beautiful villa by the sea.",
                            ImgUrl = "http://example.com/villa1.jpg",
                            Name = "Sea Breeze",
                            Occupancy = 4,
                            Rate = 2500m,
                            SquareFeet = 2000,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "Fireplace, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3329),
                            Details = "A serene mountain retreat.",
                            ImgUrl = "http://example.com/villa2.jpg",
                            Name = "Mountain Retreat",
                            Occupancy = 6,
                            Rate = 3000m,
                            SquareFeet = 2500,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "Gym, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3335),
                            Details = "A modern villa in the city.",
                            ImgUrl = "http://example.com/villa3.jpg",
                            Name = "Urban Oasis",
                            Occupancy = 3,
                            Rate = 4000m,
                            SquareFeet = 1500,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "Garden, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3341),
                            Details = "A cozy country cottage.",
                            ImgUrl = "http://example.com/villa4.jpg",
                            Name = "Country Cottage",
                            Occupancy = 5,
                            Rate = 1500m,
                            SquareFeet = 1800,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "Pool, Wi-Fi, BBQ",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3346),
                            Details = "A stunning house on the beach.",
                            ImgUrl = "http://example.com/villa5.jpg",
                            Name = "Beach House",
                            Occupancy = 8,
                            Rate = 3500m,
                            SquareFeet = 2200,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Amenity = "Hiking Trails, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3351),
                            Details = "A secluded hideaway in the forest.",
                            ImgUrl = "http://example.com/villa6.jpg",
                            Name = "Forest Hideaway",
                            Occupancy = 4,
                            Rate = 2800m,
                            SquareFeet = 2100,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Amenity = "Pool, Wi-Fi, Air Conditioning",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3356),
                            Details = "A luxurious villa in the desert.",
                            ImgUrl = "http://example.com/villa7.jpg",
                            Name = "Desert Villa",
                            Occupancy = 6,
                            Rate = 3200m,
                            SquareFeet = 2300,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Amenity = "Fishing, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3360),
                            Details = "A peaceful house by the lake.",
                            ImgUrl = "http://example.com/villa8.jpg",
                            Name = "Lake House",
                            Occupancy = 5,
                            Rate = 2700m,
                            SquareFeet = 2400,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Amenity = "Pool, Wi-Fi, BBQ",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3365),
                            Details = "A villa in a tropical paradise.",
                            ImgUrl = "http://example.com/villa9.jpg",
                            Name = "Tropical Paradise",
                            Occupancy = 10,
                            Rate = 4500m,
                            SquareFeet = 3000,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Amenity = "Library, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3370),
                            Details = "A historic manor with modern amenities.",
                            ImgUrl = "http://example.com/villa10.jpg",
                            Name = "Historic Manor",
                            Occupancy = 12,
                            Rate = 5000m,
                            SquareFeet = 3500,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            Amenity = "Ski-in/Ski-out, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3374),
                            Details = "A chalet near the ski slopes.",
                            ImgUrl = "http://example.com/villa11.jpg",
                            Name = "Ski Chalet",
                            Occupancy = 6,
                            Rate = 3800m,
                            SquareFeet = 2600,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            Amenity = "Gym, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3379),
                            Details = "A chic loft in the heart of the city.",
                            ImgUrl = "http://example.com/villa12.jpg",
                            Name = "City Loft",
                            Occupancy = 2,
                            Rate = 3400m,
                            SquareFeet = 1400,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 13,
                            Amenity = "Fireplace, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3384),
                            Details = "A rustic cabin in the woods.",
                            ImgUrl = "http://example.com/villa13.jpg",
                            Name = "Rustic Cabin",
                            Occupancy = 4,
                            Rate = 1600m,
                            SquareFeet = 1700,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 14,
                            Amenity = "Pool, Gym, Wi-Fi",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3389),
                            Details = "A modern mansion with luxurious amenities.",
                            ImgUrl = "http://example.com/villa14.jpg",
                            Name = "Modern Mansion",
                            Occupancy = 15,
                            Rate = 6000m,
                            SquareFeet = 4000,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 15,
                            Amenity = "Garden, Wi-Fi, BBQ",
                            Created = new DateTime(2024, 7, 5, 17, 6, 53, 195, DateTimeKind.Local).AddTicks(3393),
                            Details = "An estate in the countryside.",
                            ImgUrl = "http://example.com/villa15.jpg",
                            Name = "Countryside Estate",
                            Occupancy = 10,
                            Rate = 4500m,
                            SquareFeet = 3200,
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
