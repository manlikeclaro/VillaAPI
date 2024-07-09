using System.Net;
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
    private APIResponse _apiResponse;

    public VillaApiController(ILogger<VillaApiController> logger, IVillaRepository dbVilla, IMapper mapper)
    {
        _logger = logger;
        _dbVilla = dbVilla;
        _mapper = mapper;
    }

    // GET: api/VillaApi
    [HttpGet]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetVillas()
    {
        try
        {
            // Fetch all villas asynchronously from the database.
            var villas = await _dbVilla.GetAllAsync();

            // Map the villas to the VillaDto objects using AutoMapper.
            var mappedVillas = _mapper.Map<List<VillaDto>>(villas);

            // Log the number of villas retrieved.
            _logger.LogInformation($"Successfully retrieved {mappedVillas.Count} villas");

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                data: mappedVillas
            );
            return Ok(_apiResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve villas: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve villas");
        }
    }

    // GET: api/VillaApi/{id}
    [HttpGet("{id:int}", Name = "GetVilla")]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVilla(int id)
    {
        try
        {
            // Validate the Id
            if (id <= 0)
            {
                _logger.LogError("Invalid ID provided");
                // return BadRequest(new { Error = "Invalid ID provided" });

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.BadRequest,
                    isSuccess: false,
                    errorMessages: ["Invalid ID provided"]
                );
                return BadRequest(_apiResponse);
            }

            // Find the villa by Id
            var villa = await _dbVilla.GetAsync(u => u.Id == id);
            if (villa == null)
            {
                _logger.LogWarning($"Villa with ID {id} not found");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.NotFound,
                    isSuccess: false,
                    errorMessages: [$"Villa with ID {id} not found"]
                );
                return NotFound(_apiResponse);
            }

            // Return the found villa
            var mappedVilla = _mapper.Map<VillaDto>(villa);
            _logger.LogInformation($"Successfully retrieved villa with ID: {id}");

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                data: mappedVilla
            );
            return Ok(_apiResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve villa with ID {id}: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to retrieve villa with ID {id}");
        }
    }

    // POST: api/VillaApi
    [HttpPost]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateVilla([FromBody] VillaCreateDto villaDetails)
    {
        try
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

            // Map changes from DTO to the entity
            var villaModel = _mapper.Map<Villa>(villaDetails);

            // Add the new villa to the store
            await _dbVilla.CreateAsync(villaModel);

            // Return the created villa
            _logger.LogInformation($"Successfully created villa with ID: {villaModel.Id}");

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                statusCode: HttpStatusCode.Created,
                data: villaDetails
            );
            return Ok(_apiResponse);
            // return CreatedAtRoute("GetVilla", new { id = villaModel.Id }, villaDetails);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to create villa: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create villa");
        }
    }

    // DELETE: api/VillaApi/{id}
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVilla(int id)
    {
        try
        {
            // Validate the Id
            if (id <= 0)
            {
                _logger.LogError("Invalid ID provided");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.BadRequest,
                    isSuccess: false,
                    errorMessages: ["Invalid ID provided"]
                );
                return BadRequest(_apiResponse);
            }

            // Find the villa by Id
            var identifiedVilla = await _dbVilla.GetAsync(u => u.Id == id);
            if (identifiedVilla == null)
            {
                _logger.LogWarning($"Villa with ID {id} not found");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.NotFound,
                    isSuccess: false,
                    errorMessages: [$"Villa with ID {id} not found"]
                );
                return NotFound(_apiResponse);
            }

            // Remove the villa from the store
            await _dbVilla.RemoveAsync(identifiedVilla);

            // Return no content status
            _logger.LogInformation($"Successfully deleted villa with ID: {id}");

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                statusCode: HttpStatusCode.NoContent
            );
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete villa with ID {id}: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to delete villa with ID {id}");
        }
    }

    // PATCH: api/VillaApi/{id}
    [HttpPatch("{id:int}")]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> UpdateVilla(int id, JsonPatchDocument<VillaUpdateDto> updatedVilla)
    {
        try
        {
            // Validate the Id
            if (id <= 0)
            {
                _logger.LogError("Invalid ID provided");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.BadRequest,
                    isSuccess: false,
                    errorMessages: ["Invalid ID provided"]
                );
                return BadRequest(_apiResponse);
            }

            // Find the villa by Id
            var existingVilla = await _dbVilla.GetAsync(u => u.Id == id);
            if (existingVilla == null)
            {
                _logger.LogWarning($"Villa with ID {id} not found");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.NotFound,
                    isSuccess: false,
                    errorMessages: [$"Villa with ID {id} not found"]
                );
                return NotFound(_apiResponse);
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

            // Manually validate the patched DTO
            if (!TryValidateModel(villaToUpdateDto))
            {
                _logger.LogError("Invalid model state after manual validation");
                return BadRequest(ModelState);
            }

            // Check for name conflicts
            var nameExists = await _dbVilla.GetAsync(u => u.Name.ToLower() == villaToUpdateDto.Name.ToLower());
            if (nameExists != null && nameExists.Id != id)
            {
                _logger.LogWarning($"Villa with name '{villaToUpdateDto.Name}' already exists");
                ModelState.AddModelError("Validation Error", $"The name '{villaToUpdateDto.Name}' already exists!");
                return Conflict(ModelState);
            }

            // Map changes from DTO back to the entity
            _mapper.Map(villaToUpdateDto, existingVilla);

            // Save changes to the database
            await _dbVilla.UpdateAsync(existingVilla);

            // Return the updated villa
            _logger.LogInformation($"Successfully updated villa with ID: {id}");
            var updatedVillaDto = _mapper.Map<VillaDto>(existingVilla);

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                data: updatedVillaDto
            );
            return Ok(_apiResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to partially update villa with ID {id}: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Failed to partially update villa with ID {id}");
        }
    }

    // PUT: api/VillaApi/{id}
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutVilla(int id, [FromBody] VillaUpdateDto villaDetails)
    {
        try
        {
            // Validate the Id
            if (id <= 0)
            {
                _logger.LogError("Invalid ID provided");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.BadRequest,
                    isSuccess: false,
                    errorMessages: ["Invalid ID provided"]
                );
                return BadRequest(_apiResponse);
            }

            // Find the villa by Id
            var existingVilla = await _dbVilla.GetAsync(u => u.Id == id);
            if (existingVilla == null)
            {
                _logger.LogWarning($"Villa with ID {id} not found");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.NotFound,
                    isSuccess: false,
                    errorMessages: [$"Villa with ID {id} not found"]
                );
                return NotFound(_apiResponse);
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

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                data: updatedVillaDto
            );
            return Ok(_apiResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update villa with ID {id}: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to update villa with ID {id}");
        }
    }
}