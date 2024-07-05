using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VillaAPI.Data;
using VillaAPI.Models.Dto;

namespace VillaAPI.Controllers;

[ApiController]
[Route("api/VillaApi")]
public class VillaApiController : ControllerBase
{
    private readonly ILogger<VillaApiController> _logger;

    public VillaApiController(ILogger<VillaApiController> logger)
    {
        _logger = logger;
    }

    // GET: api/VillaApi
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<VillaDto> GetVillas()
    {
        // Return all villas
        var villas = VillaStore.VillaList.ToList();
        _logger.LogInformation($"Successfully retrieved {villas.Count} villas");
        return Ok(villas);
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
            _logger.LogError("Invalid ID provided");
            return BadRequest(new { Error = "Invalid ID provided" });
        }

        // Find the villa by Id
        var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
        if (villa == null)
        {
            _logger.LogWarning($"Villa with ID {id} not found");
            return NotFound();
        }

        // Return the found villa
        _logger.LogInformation($"Successfully retrieved villa with ID: {id}");
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
            _logger.LogError("Invalid model state for creating villa");
            return BadRequest(ModelState);
        }

        // Check if a villa with the same name already exists
        var nameExists = VillaStore.VillaList.FirstOrDefault(u => u.Name.ToLower() == villaDetails.Name.ToLower());
        if (nameExists != null)
        {
            _logger.LogWarning($"Villa with name '{villaDetails.Name}' already exists");
            ModelState.AddModelError("Validation Error", $"The name '{villaDetails.Name}' already exists!");
            return BadRequest(ModelState);
        }

        // Generate new Id for the villa
        var lastVilla = VillaStore.VillaList.OrderByDescending(u => u.Id).FirstOrDefault();
        villaDetails.Id = (lastVilla?.Id ?? 0) + 1;

        // Add the new villa to the store
        VillaStore.VillaList.Add(villaDetails);

        // Return the created villa
        _logger.LogInformation($"Successfully created villa with ID: {villaDetails.Id}");
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
            _logger.LogError("Invalid ID provided");
            return BadRequest(new { Error = "Invalid ID provided" });
        }

        // Find the villa by Id
        var identifiedVilla = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
        if (identifiedVilla == null)
        {
            _logger.LogWarning($"Villa with ID {id} not found");
            return NotFound();
        }

        // Remove the villa from the store
        VillaStore.VillaList.Remove(identifiedVilla);

        // Return no content status
        _logger.LogInformation($"Successfully deleted villa with ID: {id}");
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
            _logger.LogError("Invalid ID provided");
            return BadRequest(new { Error = "Invalid ID provided" });
        }

        // Find the villa by Id
        var identifiedVilla = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
        if (identifiedVilla == null)
        {
            _logger.LogWarning($"Villa with ID {id} not found");
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
            _logger.LogError("Id field cannot be modified");
            ModelState.AddModelError("Validation Error", "Id field cannot be modified.");
            return BadRequest(ModelState);
        }

        // Check for name conflicts
        var nameExists = VillaStore.VillaList.FirstOrDefault(u => u.Name.ToLower() == originalVilla.Name.ToLower());
        if (nameExists != null && nameExists.Id != id)
        {
            _logger.LogWarning($"Villa with name '{originalVilla.Name}' already exists");
            ModelState.AddModelError("Validation Error", $"The name '{originalVilla.Name}' already exists!");
            return Conflict(ModelState);
        }

        // Apply the patch to the identified villa
        updatedVilla.ApplyTo(identifiedVilla, ModelState);
        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid model state for updating villa");
            return BadRequest(ModelState);
        }

        // Return the updated villa
        _logger.LogInformation($"Successfully updated villa with ID: {id}");
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
            _logger.LogError("Invalid ID provided");
            return BadRequest(new { Error = "Invalid ID" });
        }

        // Find the villa by Id
        var identifiedVilla = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
        if (identifiedVilla == null)
        {
            _logger.LogWarning($"Villa with ID {id} not found");
            return NotFound();
        }

        // Check if a villa with the same name already exists
        var nameExists = VillaStore.VillaList.FirstOrDefault(u => u.Name.ToLower() == villaDetails.Name.ToLower());
        if (nameExists != null && nameExists.Id != id)
        {
            _logger.LogWarning($"Villa with name '{villaDetails.Name}' already exists");
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
        _logger.LogInformation($"Successfully updated villa with ID: {id}");
        return Ok(identifiedVilla);
    }
}