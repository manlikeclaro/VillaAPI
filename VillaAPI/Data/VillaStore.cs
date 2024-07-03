using VillaAPI.Models.Dto;

namespace VillaAPI.Data;

public static class VillaStore
{
    public static List<VillaDto> VillaList = new List<VillaDto>()
    {
        new VillaDto { Id = 1, Name = "Amara Retreat" },
        new VillaDto { Id = 2, Name = "Ocean Breeze" },
        new VillaDto { Id = 3, Name = "Sunset Serenity" },
        new VillaDto { Id = 4, Name = "Paradise Cove" },
        new VillaDto { Id = 5, Name = "Tranquil Waters" }
    };

}