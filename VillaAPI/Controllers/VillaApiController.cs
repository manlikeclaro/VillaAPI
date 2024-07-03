using Microsoft.AspNetCore.Mvc;
using VillaAPI.Data;
using VillaAPI.Models.Dto;

namespace VillaAPI.Controllers;

[ApiController]
[Route("api/VillaApi")]
public class VillaApiController : ControllerBase
{
    [HttpGet]
    public IEnumerable<VillaDto> GetVillas()
    {
        return VillaStore.VillaList;
    }

    [HttpGet("{Id}")]
    public VillaDto? Get(int? Id)
    {
        return VillaStore.VillaList.FirstOrDefault(u => u.Id == Id);
    }
}