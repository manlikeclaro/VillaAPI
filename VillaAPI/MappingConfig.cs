using AutoMapper;
using VillaAPI.Models;
using VillaAPI.Models.Dto.Villa;
using VillaAPI.Models.Dto.VillaNumber;

namespace VillaAPI;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        // Mapping configurations for Villa and DTOs
        CreateMap<Villa, VillaDto>().ReverseMap();
        CreateMap<Villa, VillaCreateDto>().ReverseMap();
        CreateMap<Villa, VillaUpdateDto>().ReverseMap();

        // Mapping configurations for VillaNumber and DTOs
        CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();
        CreateMap<VillaNumber, VillaNumberCreateDto>().ReverseMap();
        CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();
    }
}