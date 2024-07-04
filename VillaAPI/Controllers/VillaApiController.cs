using Microsoft.AspNetCore.Mvc;
using VillaAPI.Data;
using VillaAPI.Models.Dto;

namespace VillaAPI.Controllers;

[ApiController]
[Route("api/VillaApi")]
public class VillaApiController : ControllerBase
{
    [HttpGet]
    public ActionResult<VillaDto> GetVillas()
    {
        return Ok(VillaStore.VillaList);
    }

    [HttpGet("{Id}")]
    public ActionResult<VillaDto> Get(int Id)
    {
        if (Id != 0)
        {
            var Villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == Id);
            if (Villa != null)
            {
                return Ok(Villa);
            }

            return NotFound();
        }

        return BadRequest();
    }
}