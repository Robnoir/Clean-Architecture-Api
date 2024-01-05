using Application.Commands.Cats.AddCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Application.Queries.Cats.GetAll;
using Application.Queries.Cats.GetByAttribute;
using Application.Queries.Cats.GetById;
using Application.Validators.Cat;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly CatValidator _validator;
        internal readonly GuidValidator _guidValidator;

        public CatsController(IMediator mediator, CatValidator validator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _validator = validator;
            _guidValidator = guidValidator;
        }

        // Get all cats from the database
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            return Ok(await _mediator.Send(new GetAllCatsQuery()));
        }

        // Get cats by breed and weight
        [HttpGet("byBreedAndWeight")]
        public async Task<IActionResult> GetCatsByBreedAndWeight([FromQuery] string? breed, [FromQuery] int? weight)
        {
            var query = new GetCatByAttributeQuery(breed, weight);
            var cats = await _mediator.Send(query);
            return cats.Any() ? Ok(cats) : NotFound("No cats found matching the criteria.");
        }

        // Get a cat by its ID
        [HttpGet]
        [Route("getCatById/{catId}")]
        public async Task<IActionResult> GetCatById(Guid catId)
        {
            // Validate the GUID
            var guidValidationResult = _guidValidator.Validate(catId);
            if (!guidValidationResult.IsValid)
            {
                return BadRequest("Invalid Cat ID.");
            }

            var query = new GetCatByIdQuery(catId);
            var cat = await _mediator.Send(query);
            return cat != null ? Ok(cat) : NotFound($"No cat found with ID: {catId}");
        }

        // Create a new cat
        [HttpPost]
        [Route("addNewCat")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            // Validate the CatDto
            var validationResults = _validator.Validate(newCat);
            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors.Select(e => e.ErrorMessage));
            }

            var command = new AddCatCommand(newCat);
            var cat = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCatById), new { catId = cat.Id }, cat);
        }

        // Update an existing cat
        [HttpPut]
        [Route("updateCat/{updatedCatId}")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            // Validate CatDto and Guid
            var catValidationResult = _validator.Validate(updatedCat);
            var guidValidationResult = _guidValidator.Validate(updatedCatId);

            if (!catValidationResult.IsValid || !guidValidationResult.IsValid)
            {
                return BadRequest("Invalid data provided for update.");
            }

            var command = new UpdateCatByIdCommand(updatedCat, updatedCatId);
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound($"No cat found with ID: {updatedCatId}");
        }

        // Delete a cat by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatById(Guid id)
        {
            // Validate the GUID
            var guidValidationResult = _guidValidator.Validate(id);
            if (!guidValidationResult.IsValid)
            {
                return BadRequest("Invalid Cat ID.");
            }

            var command = new DeleteCatByIdCommand(id);
            var result = await _mediator.Send(command);
            return result != null ? NoContent() : NotFound(); // NoContent for success, NotFound if cat does not exist
        }
    }
}
