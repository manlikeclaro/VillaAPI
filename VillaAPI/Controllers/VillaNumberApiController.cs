using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VillaAPI.Models;
using VillaAPI.Models.Dto.VillaNumber;
using VillaAPI.Repository.IRepository;

namespace VillaAPI.Controllers;

[ApiController]
[Route("api/VillaNumbers")]
public class VillaNumberApiController : ControllerBase
{
    private readonly IVillaNumberRepository _dbVillaNumber;
    private readonly IVillaRepository _dbVilla;
    private readonly IMapper _mapper;
    private readonly ILogger<VillaNumberApiController> _logger;
    private APIResponse? _apiResponse;

    public VillaNumberApiController(IVillaNumberRepository dbVillaNumber, IVillaRepository dbVilla,
        IMapper mapper, ILogger<VillaNumberApiController> logger)
    {
        _dbVillaNumber = dbVillaNumber;
        _dbVilla = dbVilla;
        _mapper = mapper;
        _logger = logger;
    }

    // GET: api/VillaNumbers
    [HttpGet]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetVillaNumbers()
    {
        try
        {
            // Fetch all villas asynchronously from the database.
            var villas = await _dbVillaNumber.GetAllAsync();

            // Map the villas to the VillaNumberDto objects using AutoMapper.
            var mappedVillas = _mapper.Map<List<VillaNumberDto>>(villas);

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

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                statusCode: HttpStatusCode.InternalServerError,
                isSuccess: false,
                errorMessages: [ex.Message]
            );
            return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
        }
    }

    // GET: api/VillaNumbers/{id}
    [HttpGet("{id}", Name = "GetVillaNumber")]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVillaNumber(int id)
    {
        try
        {
            // Validate the ID
            if (id <= 0)
            {
                _logger.LogError("Invalid ID provided");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.BadRequest,
                    isSuccess: false,
                    errorMessages: ["Invalid Id Provided!"]
                );
                return BadRequest(_apiResponse);
            }

            // Find the villa by ID
            var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);
            if (villa == null)
            {
                _logger.LogError($"Villa with id {id} not found!");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.NotFound,
                    isSuccess: false,
                    errorMessages: [$"Villa with id {id} not found!"]
                );
                return NotFound(_apiResponse);
            }

            // Return the found villa
            var mappedVilla = _mapper.Map<VillaNumberDto>(villa);
            _logger.LogInformation($"Successfully retrieved villa with ID: {id}");

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                data: mappedVilla
            );
            return Ok(_apiResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve villa: {ex.Message}");

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                statusCode: HttpStatusCode.InternalServerError,
                isSuccess: false,
                errorMessages: [ex.Message]
            );
            return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
        }
    }

    // POST: api/VillaNumbers
    [HttpPost]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateVillaNumber([FromBody] VillaNumberCreateDto villaNumberDetails)
    {
        try
        {
            // Validate villa exists
            var villaExists = await _dbVilla.GetAsync(u => u.Id == villaNumberDetails.VillaId);
            if (villaExists == null)
            {
                _logger.LogError($"The Villa with ID number {villaNumberDetails.VillaId} not found");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.NotFound,
                    isSuccess: false,
                    errorMessages: [$"The Villa with ID number {villaNumberDetails.VillaId} not found"]
                );
                return NotFound(_apiResponse);
            }

            // Validate the request body
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for creating villa");
                return BadRequest(ModelState);
            }

            // Check if the villa number already exists
            var identifiedVilla = await _dbVillaNumber.GetAsync(u => u.VillaNo == villaNumberDetails.VillaNo);
            if (identifiedVilla != null)
            {
                ModelState.AddModelError("Validation Error",
                    $"This Villa number {villaNumberDetails.VillaNo} is already in use");
                return Conflict(ModelState); // Return the response with status 409 Conflict
            }

            // Map the DTO to the villa number model & Create the new villa number
            var villaNumber = _mapper.Map<VillaNumber>(villaNumberDetails);
            await _dbVillaNumber.CreateAsync(villaNumber);
            _logger.LogInformation($"Successfully created villa number: {villaNumber.VillaNo}");

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                statusCode: HttpStatusCode.Created,
                data: villaNumber
            );
            return Ok(_apiResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to retrieve villa: {ex.Message}");

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                statusCode: HttpStatusCode.InternalServerError,
                isSuccess: false,
                errorMessages: [ex.Message]
            );
            return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
        }
    }

    // DELETE: api/VillaNumbers/{id}
    [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVillaNumber(int id)
    {
        try
        {
            // Validate the ID param
            if (id <= 0)
            {
                _logger.LogError("Invalid ID provided");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.BadRequest,
                    isSuccess: false,
                    errorMessages: ["Invalid Id Provided!"]
                );
                return BadRequest(_apiResponse);
            }

            // Fetch the villa number by ID
            var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);
            if (villa == null)
            {
                _logger.LogError($"Villa with id: {id} not found");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.NotFound,
                    isSuccess: false,
                    errorMessages: [$"Villa with id: {id} not found"]
                );
                return NotFound(_apiResponse);
            }

            // Delete the villa number
            await _dbVillaNumber.RemoveAsync(villa);
            _logger.LogInformation($"Successfully deleted villa with ID: {id}");

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                statusCode: HttpStatusCode.OK,
                data: new { Message = $"Successfully deleted villa with ID: {id}" }
            );
            return Ok(_apiResponse);
        }
        catch (Exception ex)
        {
            _apiResponse = new APIResponse(
                statusCode: HttpStatusCode.InternalServerError,
                isSuccess: false,
                errorMessages: [ex.Message]
            );
            return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
        }
    }

    // PUT: api/VillaNumbers/{id}
    [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDto villaNumberUpdateDto)
    {
        try
        {
            // Validate the ID param
            if (id <= 0)
            {
                _logger.LogError("Invalid ID provided");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.BadRequest,
                    isSuccess: false,
                    errorMessages: ["Invalid Id Provided!"]
                );
                return BadRequest(_apiResponse);
            }

            // Fetch the villa number by ID
            var villa = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);
            if (villa == null)
            {
                _logger.LogError($"Villa number {id} not found");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.NotFound,
                    isSuccess: false,
                    errorMessages: [$"Villa number {id} not found"]
                );
                return NotFound(_apiResponse);
            }

            // Validate villa exists
            var villaExists = await _dbVilla.GetAsync(u => u.Id == villaNumberUpdateDto.VillaId);
            if (villaExists == null)
            {
                _logger.LogError($"The Villa with ID number {villaNumberUpdateDto.VillaId} not found");

                // Create a new APIResponse object & return response
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.NotFound,
                    isSuccess: false,
                    errorMessages: [$"The Villa with ID number {villaNumberUpdateDto.VillaId} not found"]
                );
                return NotFound(_apiResponse);
            }

            // Map the DTO to the existing villa number & Update the villa number
            _mapper.Map(villaNumberUpdateDto, villa);
            await _dbVillaNumber.UpdateAsync(villa);
            _logger.LogInformation($"Successfully updated villa with ID: {id}");

            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(data: villa);
            return Ok(_apiResponse);
        }
        catch (Exception ex)
        {
            // Create a new APIResponse object & return response
            _apiResponse = new APIResponse(
                statusCode: HttpStatusCode.InternalServerError,
                isSuccess: false,
                errorMessages: [ex.Message]
            );
            return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
        }
    }
}