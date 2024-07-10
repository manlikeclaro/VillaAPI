using Microsoft.EntityFrameworkCore;
using VillaAPI.Models;

namespace VillaAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Villa> Villas { get; set; }
    public DbSet<VillaNumber> VillaNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Villa>().HasData(
            new Villa
            {
                Id = 1, Name = "Sea Breeze", Details = "A beautiful villa by the sea.", Rate = 2500, SquareFeet = 2000,
                Occupancy = 4, ImgUrl = "http://example.com/villa1.jpg", Amenity = "Pool, Wi-Fi", Created = DateTime.Now
            },
            new Villa
            {
                Id = 2, Name = "Mountain Retreat", Details = "A serene mountain retreat.", Rate = 3000,
                SquareFeet = 2500, Occupancy = 6, ImgUrl = "http://example.com/villa2.jpg",
                Amenity = "Fireplace, Wi-Fi", Created = DateTime.Now
            },
            new Villa
            {
                Id = 3, Name = "Urban Oasis", Details = "A modern villa in the city.", Rate = 4000, SquareFeet = 1500,
                Occupancy = 3, ImgUrl = "http://example.com/villa3.jpg", Amenity = "Gym, Wi-Fi", Created = DateTime.Now
            },
            new Villa
            {
                Id = 4, Name = "Country Cottage", Details = "A cozy country cottage.", Rate = 1500, SquareFeet = 1800,
                Occupancy = 5, ImgUrl = "http://example.com/villa4.jpg", Amenity = "Garden, Wi-Fi",
                Created = DateTime.Now
            },
            new Villa
            {
                Id = 5, Name = "Beach House", Details = "A stunning house on the beach.", Rate = 3500,
                SquareFeet = 2200,
                Occupancy = 8, ImgUrl = "http://example.com/villa5.jpg", Amenity = "Pool, Wi-Fi, BBQ",
                Created = DateTime.Now
            },
            new Villa
            {
                Id = 6, Name = "Forest Hideaway", Details = "A secluded hideaway in the forest.", Rate = 2800,
                SquareFeet = 2100, Occupancy = 4, ImgUrl = "http://example.com/villa6.jpg",
                Amenity = "Hiking Trails, Wi-Fi", Created = DateTime.Now
            },
            new Villa
            {
                Id = 7, Name = "Desert Villa", Details = "A luxurious villa in the desert.", Rate = 3200,
                SquareFeet = 2300,
                Occupancy = 6, ImgUrl = "http://example.com/villa7.jpg", Amenity = "Pool, Wi-Fi, Air Conditioning",
                Created = DateTime.Now
            },
            new Villa
            {
                Id = 8, Name = "Lake House", Details = "A peaceful house by the lake.", Rate = 2700, SquareFeet = 2400,
                Occupancy = 5, ImgUrl = "http://example.com/villa8.jpg", Amenity = "Fishing, Wi-Fi",
                Created = DateTime.Now
            },
            new Villa
            {
                Id = 9, Name = "Tropical Paradise", Details = "A villa in a tropical paradise.", Rate = 4500,
                SquareFeet = 3000, Occupancy = 10, ImgUrl = "http://example.com/villa9.jpg",
                Amenity = "Pool, Wi-Fi, BBQ", Created = DateTime.Now
            },
            new Villa
            {
                Id = 10, Name = "Historic Manor", Details = "A historic manor with modern amenities.", Rate = 5000,
                SquareFeet = 3500, Occupancy = 12, ImgUrl = "http://example.com/villa10.jpg",
                Amenity = "Library, Wi-Fi", Created = DateTime.Now
            },
            new Villa
            {
                Id = 11, Name = "Ski Chalet", Details = "A chalet near the ski slopes.", Rate = 3800, SquareFeet = 2600,
                Occupancy = 6, ImgUrl = "http://example.com/villa11.jpg", Amenity = "Ski-in/Ski-out, Wi-Fi",
                Created = DateTime.Now
            },
            new Villa
            {
                Id = 12, Name = "City Loft", Details = "A chic loft in the heart of the city.", Rate = 3400,
                SquareFeet = 1400, Occupancy = 2, ImgUrl = "http://example.com/villa12.jpg", Amenity = "Gym, Wi-Fi",
                Created = DateTime.Now
            },
            new Villa
            {
                Id = 13, Name = "Rustic Cabin", Details = "A rustic cabin in the woods.", Rate = 1600,
                SquareFeet = 1700,
                Occupancy = 4, ImgUrl = "http://example.com/villa13.jpg", Amenity = "Fireplace, Wi-Fi",
                Created = DateTime.Now
            },
            new Villa
            {
                Id = 14, Name = "Modern Mansion", Details = "A modern mansion with luxurious amenities.", Rate = 6000,
                SquareFeet = 4000, Occupancy = 15, ImgUrl = "http://example.com/villa14.jpg",
                Amenity = "Pool, Gym, Wi-Fi", Created = DateTime.Now
            },
            new Villa
            {
                Id = 15, Name = "Countryside Estate", Details = "An estate in the countryside.", Rate = 4500,
                SquareFeet = 3200, Occupancy = 10, ImgUrl = "http://example.com/villa15.jpg",
                Amenity = "Garden, Wi-Fi, BBQ", Created = DateTime.Now
            }
        );
        
        modelBuilder.Entity<VillaNumber>().HasData(
            new VillaNumber()
            {
                VillaNo = 101, Details = "Disabled Access", Created = DateTime.Now, Updated = null
            }
        );
    }
}