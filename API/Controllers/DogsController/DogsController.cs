using Application.Commands.Dogs;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using Application.Queries.Dogs.GetDogByAttribute;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.DogsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly DogValidator _validator; // Validator for DogDto
        private readonly GuidValidator _guidValidator; // Validator for Guid

        public DogsController(IMediator mediator, DogValidator validator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _validator = validator;
            _guidValidator = guidValidator;
        }

        // Get all dogs from the database
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            try
            {
                var query = new GetAllDogsQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                return StatusCode(500, ex.Message);
            }
        }

        // Get a dog by its ID
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            // Validate the GUID
            var guidValidationResult = _guidValidator.Validate(dogId);
            if (!guidValidationResult.IsValid)
            {
                return BadRequest("Invalid Dog ID.");
            }

            var query = new GetDogByIdQuery(dogId);
            var dog = await _mediator.Send(query);
            return dog != null ? Ok(dog) : NotFound($"No dog found with ID: {dogId}");
        }

        // Get dogs by breed and weight
        [HttpGet("byBreedAndWeight")]
        public async Task<IActionResult> GetDogByBreedAndWeight([FromQuery] string? breed, [FromQuery] int? weight)
        {
            var query = new GetDogByAttributeQuery(breed, weight);
            var dogs = await _mediator.Send(query);
            return dogs.Any() ? Ok(dogs) : NotFound("No dogs found matching the criteria.");
        }

        // Add a new dog
        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            // Validate the DogDto
            var validationResults = _validator.Validate(newDog);
            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors.Select(e => e.ErrorMessage));
            }

            var command = new AddDogCommand(newDog);
            var dog = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDogById), new { dogId = dog.Id }, dog);
        }

        // Update an existing dog
        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            // Validate DogDto and Guid
            var dogValidationResult = _validator.Validate(updatedDog);
            var guidValidationResult = _guidValidator.Validate(updatedDogId);

            if (!dogValidationResult.IsValid || !guidValidationResult.IsValid)
            {
                return BadRequest("Invalid data provided for update.");
            }

            var command = new UpdateDogByIdCommand(updatedDog, updatedDogId);
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound($"No dog found with ID: {updatedDogId}");
        }

        // Delete a dog by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogById(Guid id)
        {
            // Validate the GUID
            var guidValidationResult = _guidValidator.Validate(id);
            if (!guidValidationResult.IsValid)
            {
                return BadRequest("Invalid Dog ID.");
            }

            var command = new DeleteDogByIdCommand(id);
            var result = await _mediator.Send(command);
            return result != null ? NoContent() : NotFound(); // NoContent for success, NotFound if dog does not exist
        }
    }
}
