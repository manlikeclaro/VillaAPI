using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using VillaAPI.Models;
using VillaAPI.Models.Dto;

namespace VillaAPI;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Villa, VillaDto>().ReverseMap();
        CreateMap<Villa, VillaCreateDto>().ReverseMap();
        CreateMap<Villa, VillaUpdateDto>().ReverseMap();
    }
}