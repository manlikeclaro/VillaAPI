using VillaAPI.Models.Dto;

namespace VillaAPI.Data;

public static class VillaStore
{
    public static List<VillaDto> VillaList = new List<VillaDto>()
    {
        new VillaDto
        {
            Id = 1,
            Name = "Phoenix Nest",
            Location = "Santorini, Greece",
            Bedrooms = 4,
            Bathrooms = 3,
            PricePerNight = 850
        },

        new VillaDto
        {
            Id = 2,
            Name = "Azure Serenity",
            Location = "Bali, Indonesia",
            Bedrooms = 5,
            Bathrooms = 4,
            PricePerNight = 900
        },

        new VillaDto
        {
            Id = 3,
            Name = "Starlight Haven",
            Location = "Malibu, California",
            Bedrooms = 6,
            Bathrooms = 5,
            PricePerNight = 1200
        },

        new VillaDto
        {
            Id = 4,
            Name = "Emerald Oasis",
            Location = "Phuket, Thailand",
            Bedrooms = 3,
            Bathrooms = 3,
            PricePerNight = 700
        },

        new VillaDto
        {
            Id = 5,
            Name = "Golden Horizon",
            Location = "Tuscany, Italy",
            Bedrooms = 4,
            Bathrooms = 4,
            PricePerNight = 1100
        },

        new VillaDto
        {
            Id = 6,
            Name = "Moonlit Mirage",
            Location = "Marrakech, Morocco",
            Bedrooms = 5,
            Bathrooms = 5,
            PricePerNight = 950
        },

        new VillaDto
        {
            Id = 7,
            Name = "Celestial Bay",
            Location = "Bahamas",
            Bedrooms = 6,
            Bathrooms = 6,
            PricePerNight = 1300
        },

        new VillaDto
        {
            Id = 8,
            Name = "Coral Haven",
            Location = "Maui, Hawaii",
            Bedrooms = 5,
            Bathrooms = 4,
            PricePerNight = 1050
        },

        new VillaDto
        {
            Id = 9,
            Name = "Radiant Peak",
            Location = "Aspen, Colorado",
            Bedrooms = 4,
            Bathrooms = 4,
            PricePerNight = 1150
        },

        new VillaDto
        {
            Id = 10,
            Name = "Seraphic Shores",
            Location = "Fiji",
            Bedrooms = 6,
            Bathrooms = 5,
            PricePerNight = 1400
        }
    };
}