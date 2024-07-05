using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VillaAPI.Data;
using VillaAPI.Models.Dto;

namespace VillaAPI.Controllers;

[ApiController]
[Route("api/VillaApi")]
public class VillaApiController : ControllerBase
{
    // GET: api/VillaApi
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<VillaDto> GetVillas()
    {
        // Return all villas
        return Ok(VillaStore.VillaList);
    }

    // GET: api/VillaApi/{id}
    [HttpGet("{id:int}", Name = "GetVilla")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDto> GetVilla(int id)
    {
        // Validate the Id
        if (id <= 0)
        {
            return BadRequest(@"{
                ""Error"": ""Invalid ID""
            }");
        }

        // Find the villa by Id
        var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
        if (villa == null)
        {
            return NotFound();
        }

        // Return the found villa
        return Ok(villa);
    }

    // POST: api/VillaApi
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDetails)
    {
        // Validate the request body
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Check if a villa with the same name already exists
        var nameExists = VillaStore.VillaList.FirstOrDefault(u => u.Name.ToLower() == villaDetails.Name.ToLower());
        if (nameExists != null)
        {
            ModelState.AddModelError("Validation Error", $"The name '{villaDetails.Name}' already exists!");
            return BadRequest(ModelState);
        }

        // Generate new Id for the villa
        var lastVilla = VillaStore.VillaList.OrderByDescending(u => u.Id).FirstOrDefault();
        villaDetails.Id = (lastVilla?.Id ?? 0) + 1;

        // Add the new villa to the store
        VillaStore.VillaList.Add(villaDetails);

        // Return the created villa
        return CreatedAtRoute("GetVilla", new { id = villaDetails.Id }, villaDetails);
    }

    // DELETE: api/VillaApi/{id}
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteVilla(int id)
    {
        // Validate the Id
        if (id <= 0)
        {
            return BadRequest(@"{
                ""Error"": ""Invalid ID""
            }");
        }

        // Find the villa by Id
        var identifiedVilla = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
        if (identifiedVilla == null)
        {
            return NotFound();
        }

        // Remove the villa from the store
        VillaStore.VillaList.Remove(identifiedVilla);

        // Return no content status
        return NoContent();
    }

    // PATCH: api/VillaApi/{id}
    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult<VillaDto> UpdateVilla(int id, JsonPatchDocument<VillaDto> updatedVilla)
    {
        // Validate the Id
        if (id <= 0)
        {
            return BadRequest(@"{
                ""Error"": ""Invalid ID""
            }");
        }

        // Find the villa by Id
        var identifiedVilla = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
        if (identifiedVilla == null)
        {
            return NotFound();
        }

        // Create a copy to apply the patch and check if the Id is being modified
        var originalVilla = new VillaDto
        {
            Id = identifiedVilla.Id,
            Name = identifiedVilla.Name,
            // Add other properties as needed
        };
        updatedVilla.ApplyTo(originalVilla, ModelState);

        // Check if Id is modified
        if (originalVilla.Id != id)
        {
            ModelState.AddModelError("Validation Error", "Id field cannot be modified.");
            return BadRequest(ModelState);
        }

        // Check for name conflicts
        var nameExists = VillaStore.VillaList.FirstOrDefault(u => u.Name.ToLower() == originalVilla.Name.ToLower());
        if (nameExists != null && nameExists.Id != id)
        {
            ModelState.AddModelError("Validation Error", $"The name '{originalVilla.Name}' already exists!");
            return Conflict(ModelState);
        }

        // Apply the patch to the identified villa
        updatedVilla.ApplyTo(identifiedVilla, ModelState);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Return the updated villa
        return Ok(identifiedVilla);
    }

    // PUT: api/VillaApi/{id}
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDto> PutVilla(int id, [FromBody] VillaDto villaDetails)
    {
        // Validate the Id
        if (id <= 0)
        {
            return BadRequest(@"{
                ""Error"": ""Invalid ID""
            }");
        }

        // Find the villa by Id
        var identifiedVilla = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
        if (identifiedVilla == null)
        {
            return NotFound();
        }

        // Check if a villa with the same name already exists
        var nameExists = VillaStore.VillaList.FirstOrDefault(u => u.Name.ToLower() == villaDetails.Name.ToLower());
        if (nameExists != null && nameExists.Id != id)
        {
            ModelState.AddModelError("Validation Error", $"The name '{villaDetails.Name}' already exists!");
            return Conflict(ModelState);
        }

        // Update the villa details
        identifiedVilla.Name = villaDetails.Name;
        identifiedVilla.Location = villaDetails.Location;
        identifiedVilla.Bedrooms = villaDetails.Bedrooms;
        identifiedVilla.Bathrooms = villaDetails.Bathrooms;
        identifiedVilla.PricePerNight = villaDetails.PricePerNight;

        // Return the updated villa
        return Ok(identifiedVilla);
    }
}