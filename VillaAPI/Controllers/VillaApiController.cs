using Microsoft.AspNetCore.Mvc;
using VillaAPI.Data;
using VillaAPI.Models.Dto;

namespace VillaAPI.Controllers;

[ApiController]
[Route("api/VillaApi")]
public class VillaApiController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<VillaDto> GetVillas()
    {
        return Ok(VillaStore.VillaList);
    }

    [HttpGet("{Id}", Name = "GetVilla")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDto> GetVilla(int Id)
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto? VillaDetails)
    {
        if (VillaDetails == null)
        {
            return BadRequest();
        }

        var lastVilla = VillaStore.VillaList.OrderByDescending(u => u.Id).FirstOrDefault();
        VillaDetails.Id = (lastVilla != null ? lastVilla.Id : 0) + 1;
        VillaStore.VillaList.Add(VillaDetails);

        // return Created("GetVilla", VillaDetails);
        return CreatedAtRoute("GetVilla", new { id = VillaDetails.Id }, VillaDetails);
    }
}