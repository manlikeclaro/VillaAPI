using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VillaAPI.Models;
using VillaAPI.Models.Dto;

namespace VillaAPI.Controllers;

[ApiController]
[Route("api/VillaApi")]
public class VillaApiController : ControllerBase
{
    private readonly ILogger<VillaApiController> _logger;
    private readonly ApplicationDbContext _db;

    public VillaApiController(ILogger<VillaApiController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    // GET: api/VillaApi
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<VillaDto> GetVillas()
    {
        // Return all villas
        var villas = _db.Villas.ToList();
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
        var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
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
        var nameExists = _db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDetails.Name.ToLower());
        if (nameExists != null)
        {
            _logger.LogWarning($"Villa with name '{villaDetails.Name}' already exists");
            ModelState.AddModelError("Validation Error", $"The name '{villaDetails.Name}' already exists!");
            return BadRequest(ModelState);
        }

        var villaModel = new Villa()
        {
            Id = villaDetails.Id,
            Name = villaDetails.Name,
            Details = villaDetails.Details,
            Rate = villaDetails.Rate,
            SquareFeet = villaDetails.SquareFeet,
            Occupancy = villaDetails.Occupancy,
            ImgUrl = villaDetails.ImgUrl,
            Amenity = villaDetails.Amenity,
            Created = DateTime.Now,
        };

        // Add the new villa to the store
        _db.Villas.Add(villaModel);
        _db.SaveChanges();

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
        var identifiedVilla = _db.Villas.FirstOrDefault(u => u.Id == id);
        if (identifiedVilla == null)
        {
            _logger.LogWarning($"Villa with ID {id} not found");
            return NotFound();
        }

        // Remove the villa from the store
        _db.Villas.Remove(identifiedVilla);
        _db.SaveChanges();

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
        var identifiedVilla = _db.Villas.FirstOrDefault(u => u.Id == id);
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
            Details = identifiedVilla.Details,
            Rate = identifiedVilla.Rate,
            SquareFeet = identifiedVilla.SquareFeet,
            Occupancy = identifiedVilla.Occupancy,
            ImgUrl = identifiedVilla.ImgUrl,
            Amenity = identifiedVilla.Amenity
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
        var nameExists = _db.Villas.FirstOrDefault(u => u.Name.ToLower() == originalVilla.Name.ToLower());
        if (nameExists != null && nameExists.Id != id)
        {
            _logger.LogWarning($"Villa with name '{originalVilla.Name}' already exists");
            ModelState.AddModelError("Validation Error", $"The name '{originalVilla.Name}' already exists!");
            return Conflict(ModelState);
        }

        // Map changes from DTO back to entity
        identifiedVilla.Name = originalVilla.Name;
        identifiedVilla.Details = originalVilla.Details;
        identifiedVilla.Rate = originalVilla.Rate;
        identifiedVilla.SquareFeet = originalVilla.SquareFeet;
        identifiedVilla.Occupancy = originalVilla.Occupancy;
        identifiedVilla.ImgUrl = originalVilla.ImgUrl;
        identifiedVilla.Amenity = originalVilla.Amenity;
        identifiedVilla.Updated = DateTime.Now;
        
        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid model state for updating villa");
            return BadRequest(ModelState);
        }
        _db.SaveChanges();

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
        var identifiedVilla = _db.Villas.FirstOrDefault(u => u.Id == id);
        if (identifiedVilla == null)
        {
            _logger.LogWarning($"Villa with ID {id} not found");
            return NotFound();
        }

        // Check if a villa with the same name already exists
        var nameExists = _db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDetails.Name.ToLower());
        if (nameExists != null && nameExists.Id != id)
        {
            _logger.LogWarning($"Villa with name '{villaDetails.Name}' already exists");
            ModelState.AddModelError("Validation Error", $"The name '{villaDetails.Name}' already exists!");
            return Conflict(ModelState);
        }

        // Update the villa details
        identifiedVilla.Name = villaDetails.Name;
        identifiedVilla.Details = villaDetails.Details;
        identifiedVilla.Rate = villaDetails.Rate;
        identifiedVilla.SquareFeet = villaDetails.SquareFeet;
        identifiedVilla.Occupancy = villaDetails.Occupancy;
        identifiedVilla.ImgUrl = villaDetails.ImgUrl;
        identifiedVilla.Amenity = villaDetails.Amenity;
        identifiedVilla.Updated = DateTime.Now;
        
        _db.Villas.Update(identifiedVilla);
        _db.SaveChanges();

        // Return the updated villa
        _logger.LogInformation($"Successfully updated villa with ID: {id}");
        return Ok(identifiedVilla);
    }
}