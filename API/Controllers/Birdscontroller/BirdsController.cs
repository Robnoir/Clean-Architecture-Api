using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using MediatR;
using Application.Commands.Birds.DeleteBird;
using Application.Commands.Birds.UpdateBird;
using Application.Queries.Birds.GetAll;
using Application.Queries.Birds.GetById;
using Application.Commands.Birds.AddBird;
using Application.Queries.Birds.GetByAttribute;
using Application.Validators.Bird; // Assuming a BirdValidator exists

namespace API.Controllers.Birdscontroller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : Controller
    {
        internal readonly IMediator _mediator;
        internal readonly BirdValidator _validator; // Assuming a BirdValidator exists
        internal readonly GuidValidator _guidValidator; // Assuming a GuidValidator exists

        public BirdsController(IMediator mediator, BirdValidator validator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _validator = validator;
            _guidValidator = guidValidator;
        }

        // Get all Birds from Db
        [HttpGet]
        [Route("getAllBirds")]
        public async Task<IActionResult> GetAllBirds()
        {
            return Ok(await _mediator.Send(new GetAllBirdsQuery()));
        }

        // Get Bird by attribute (color)
        [HttpGet("color/{color}")]
        public async Task<IActionResult> GetBirdByAttribute(string color)
        {
            var query = new GetBirdByAttributeQuery(color);
            var birds = await _mediator.Send(query);
            return birds.Any() ? Ok(birds) : NotFound("No birds found with specified color.");
        }

        // Get Bird By Id
        [HttpGet]
        [Route("getBirdById/{birdId}")]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            // Validate the GUID
            var guidValidationResult = _guidValidator.Validate(birdId);
            if (!guidValidationResult.IsValid)
            {
                return BadRequest("Invalid Bird ID.");
            }

            var query = new GetBirdByIdQuery(birdId);
            var bird = await _mediator.Send(query);
            return bird != null ? Ok(bird) : NotFound($"No bird found with ID: {birdId}");
        }

        // Create a new Bird
        [HttpPost]
        [Route("addNewBird")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            // Validate the BirdDto
            var validationResults = _validator.Validate(newBird);
            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors.Select(e => e.ErrorMessage));
            }

            var command = new AddBirdCommand(newBird);
            var bird = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBirdById), new { birdId = bird.Id }, bird);
        }

        // Update a specific Bird
        [HttpPut]
        [Route("updateBird/{updateBirdId}")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updateBirdId)
        {
            // Validate BirdDto and Guid
            var birdValidationResult = _validator.Validate(updatedBird);
            var guidValidationResult = _guidValidator.Validate(updateBirdId);

            if (!birdValidationResult.IsValid || !guidValidationResult.IsValid)
            {
                return BadRequest("Invalid data provided for update.");
            }

            var command = new UpdateBirdByIdCommand(updatedBird, updateBirdId);
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound($"No bird found with ID: {updateBirdId}");
        }
        // Delete a specific Bird
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBirdById(Guid id)
        {
            // Validate the GUID
            var guidValidationResult = _guidValidator.Validate(id);
            if (!guidValidationResult.IsValid)
            {
                return BadRequest("Invalid Bird ID.");
            }

            var command = new DeleteBirdByIdCommand(id);
            var result = await _mediator.Send(command);
            return result != null ? NoContent() : NotFound(); // NoContent for success, NotFound if bird does not exist
        }

    }
}
