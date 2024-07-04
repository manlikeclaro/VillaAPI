using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        var nameExists = VillaStore.VillaList.FirstOrDefault(u => u.Name.ToLower() == VillaDetails.Name.ToLower());
        if (nameExists != null)
        {
            ModelState.AddModelError("Validation Error", $"The name '{VillaDetails.Name}' already exists!");
            return BadRequest(ModelState);
        }

        var lastVilla = VillaStore.VillaList.OrderByDescending(u => u.Id).FirstOrDefault();
        VillaDetails.Id = (lastVilla != null ? lastVilla.Id : 0) + 1;
        VillaStore.VillaList.Add(VillaDetails);

        // return Created("GetVilla", VillaDetails);
        return CreatedAtRoute("GetVilla", new { id = VillaDetails.Id }, VillaDetails);
    }

    [HttpDelete("{Id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDto> DeleteVilla(int Id)
    {
        if (Id <= 0)
        {
            var identifiedVilla = VillaStore.VillaList.FirstOrDefault(u => u.Id == Id);

            if (identifiedVilla == null)
            {
                return NotFound();
            }

            VillaStore.VillaList.Remove(identifiedVilla);
            return NoContent();
        }

        return BadRequest();
    }

    [HttpPatch("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
    public ActionResult<VillaDto> UpdateVilla(int Id, [FromBody] VillaDto? updatedVilla)
    {
        if (Id != 0 && Id > 0 && updatedVilla != null)
        {
            // var identifiedVilla = VillaStore.VillaList.FirstOrDefault(u => u.Id == Id);
            var identifiedVilla = VillaStore.VillaList.Find(u => u.Id == Id);

            if (identifiedVilla == null)
            {
                return NotFound();
            }

            var nameExists = VillaStore.VillaList.FirstOrDefault(u => u.Name.ToLower() == updatedVilla.Name.ToLower());
            if (nameExists != null)
            {
                ModelState.AddModelError("Validation Error", $"The name '{updatedVilla.Name}' already exists!");
                return Conflict(ModelState);
            }

            identifiedVilla.Name = updatedVilla.Name;
            identifiedVilla.Bedrooms = updatedVilla.Bedrooms;
            identifiedVilla.Bathrooms = updatedVilla.Bathrooms;
            identifiedVilla.PricePerNight = updatedVilla.PricePerNight;
            return Ok(identifiedVilla);
        }

        return BadRequest();
    }

    [HttpPut("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDto> PutVilla(int? Id, VillaDto? villaDetails)
    {
        if (Id > 0 && Id != 0)
        {
            var identifiedVilla = VillaStore.VillaList.FirstOrDefault(u => u.Id == Id);

            if (identifiedVilla == null)
            {
                return NotFound();
            }

            identifiedVilla.Name = villaDetails.Name;
            identifiedVilla.Location = villaDetails.Location;
            identifiedVilla.Bedrooms = villaDetails.Bedrooms;
            identifiedVilla.Bathrooms = villaDetails.Bathrooms;
            identifiedVilla.PricePerNight = villaDetails.PricePerNight;
            
            // // Copy properties from villaDetails to identifiedVilla
            // foreach (var property in typeof(VillaDto).GetProperties())
            // {
            //     var value = property.GetValue(villaDetails);
            //     property.SetValue(identifiedVilla, value);
            // }
            
            return Ok(identifiedVilla);
        }

        return BadRequest();
    }
}