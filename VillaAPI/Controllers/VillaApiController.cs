using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaAPI.Data;
using VillaAPI.Models;
using VillaAPI.Models.Dto;
using IVillaRepository = VillaAPI.Repository.IRepository.IVillaRepository;

namespace VillaAPI.Controllers;

[ApiController]
[Route("api/VillaApi")]
public class VillaApiController : ControllerBase
{
    private readonly ILogger<VillaApiController> _logger;
    private readonly IVillaRepository _dbVilla;
    private readonly IMapper _mapper;

    public VillaApiController(ILogger<VillaApiController> logger, IVillaRepository dbVilla, IMapper mapper)
    {
        _logger = logger;
        _dbVilla = dbVilla;
        _mapper = mapper;
    }

    // GET: api/VillaApi
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<VillaDto>> GetVillas()
    {
        // Return all villas
        var villas = await _dbVilla.GetAllAsync();
        var mappedVillas = _mapper.Map<List<VillaDto>>(villas);
        _logger.LogInformation($"Successfully retrieved {mappedVillas.Count} villas");
        return Ok(mappedVillas);
    }

    // GET: api/VillaApi/{id}
    [HttpGet("{id:int}", Name = "GetVilla")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VillaDto>> GetVilla(int id)
    {
        // Validate the Id
        if (id <= 0)
        {
            _logger.LogError("Invalid ID provided");
            return BadRequest(new { Error = "Invalid ID provided" });
        }

        // Find the villa by Id
        var villa = await _dbVilla.GetAsync(u => u.Id == id);
        if (villa == null)
        {
            _logger.LogWarning($"Villa with ID {id} not found");
            return NotFound();
        }

        // Return the found villa
        _logger.LogInformation($"Successfully retrieved villa with ID: {id}");
        var mappedVilla = _mapper.Map<VillaDto>(villa);
        return Ok(mappedVilla);
    }

    // POST: api/VillaApi
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VillaDto>> CreateVilla([FromBody] VillaCreateDto villaDetails)
    {
        // Validate the request body
        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid model state for creating villa");
            return BadRequest(ModelState);
        }

        // Check if a villa with the same name already exists
        var nameExists = await _dbVilla.GetAsync(u => u.Name.ToLower() == villaDetails.Name.ToLower());
        if (nameExists != null)
        {
            _logger.LogWarning($"Villa with name '{villaDetails.Name}' already exists");
            ModelState.AddModelError("Validation Error", $"The name '{villaDetails.Name}' already exists!");
            return BadRequest(ModelState);
        }

        var villaModel = _mapper.Map<Villa>(villaDetails);

        // Add the new villa to the store
        await _dbVilla.CreateAsync(villaModel);

        // Return the created villa
        _logger.LogInformation($"Successfully created villa with ID: {villaModel.Id}");
        return CreatedAtRoute("GetVilla", new { id = villaModel.Id }, villaDetails);
    }

    // DELETE: api/VillaApi/{id}
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVilla(int id)
    {
        // Validate the Id
        if (id <= 0)
        {
            _logger.LogError("Invalid ID provided");
            return BadRequest(new { Error = "Invalid ID provided" });
        }

        // Find the villa by Id
        var identifiedVilla = await _dbVilla.GetAsync(u => u.Id == id);
        if (identifiedVilla == null)
        {
            _logger.LogWarning($"Villa with ID {id} not found");
            return NotFound();
        }

        // Remove the villa from the store
        await _dbVilla.RemoveAsync(identifiedVilla);

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
    public async Task<ActionResult<VillaDto>> UpdateVilla(int id, JsonPatchDocument<VillaUpdateDto> updatedVilla)
    {
        // Validate the Id
        if (id <= 0)
        {
            _logger.LogError("Invalid ID provided");
            return BadRequest(new { Error = "Invalid ID provided" });
        }

        // Find the villa by Id
        var existingVilla = await _dbVilla.GetAsync(u => u.Id == id);
        if (existingVilla == null)
        {
            _logger.LogWarning($"Villa with ID {id} not found");
            return NotFound();
        }
        
        // Use AutoMapper to map the existing Villa entity to VillaUpdateDto
        var villaToUpdateDto = _mapper.Map<VillaUpdateDto>(existingVilla);

        // Apply patch document to the DTO
        updatedVilla.ApplyTo(villaToUpdateDto, ModelState);
        
        // Check for ModelState errors after applying patch
        if (!ModelState.IsValid)
        {
            _logger.LogError("Invalid model state for updating villa");
            return BadRequest(ModelState);
        }
        
        // Map changes from DTO back to the entity
        _mapper.Map(villaToUpdateDto, existingVilla);

        // Check for name conflicts
        var nameExists = await _dbVilla.GetAsync(u => u.Name.ToLower() == existingVilla.Name.ToLower());
        if (nameExists != null && nameExists.Id != id)
        {
            _logger.LogWarning($"Villa with name '{existingVilla.Name}' already exists");
            ModelState.AddModelError("Validation Error", $"The name '{existingVilla.Name}' already exists!");
            return Conflict(ModelState);
        }

        // Save changes to the database
        await _dbVilla.UpdateAsync(existingVilla);
        
        // Return the updated villa
        _logger.LogInformation($"Successfully updated villa with ID: {id}");
        var updatedVillaDto = _mapper.Map<VillaDto>(existingVilla);
        return Ok(updatedVillaDto);
    }

    // PUT: api/VillaApi/{id}
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VillaDto>> PutVilla(int id, [FromBody] VillaUpdateDto villaDetails)
    {
        // Validate the Id
        if (id <= 0)
        {
            _logger.LogError("Invalid ID provided");
            return BadRequest(new { Error = "Invalid ID" });
        }

        // Find the villa by Id
        var existingVilla = await _dbVilla.GetAsync(u => u.Id == id);
        if (existingVilla == null)
        {
            _logger.LogWarning($"Villa with ID {id} not found");
            return NotFound();
        }

        // Check if a villa with the same name already exists
        var nameExists = await _dbVilla.GetAsync(u => u.Name.ToLower() == villaDetails.Name.ToLower());
        if (nameExists != null && nameExists.Id != id)
        {
            _logger.LogWarning($"Villa with name '{villaDetails.Name}' already exists");
            ModelState.AddModelError("Validation Error", $"The name '{villaDetails.Name}' already exists!");
            return Conflict(ModelState);
        }
        
        // Use AutoMapper to map VillaUpdateDto to existing Villa entity
        _mapper.Map(villaDetails, existingVilla);
        
        // Save changes to the database
        await _dbVilla.UpdateAsync(existingVilla);

        // Return the updated villa
        _logger.LogInformation($"Successfully updated villa with ID: {id}");
        var updatedVillaDto = _mapper.Map<VillaDto>(existingVilla);
        return Ok(updatedVillaDto);
    }
}