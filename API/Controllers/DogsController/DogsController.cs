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

        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            var query = new GetAllDogsQuery();
            var dogs = await _mediator.Send(query);
            return Ok(dogs);
        }

        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            var query = new GetDogByIdQuery(dogId);
            var dog = await _mediator.Send(query);
            if (dog != null)
            {
                return Ok(dog);
            }
            return NotFound($"No dog found with ID: {dogId}");
        }

        [HttpGet("byBreedAndWeight")]
        public async Task<IActionResult> GetDogByBreedAndWeight([FromQuery] string? breed, [FromQuery] int? weight)
        {
            var query = new GetDogByAttributeQuery(breed, weight);
            var dogs = await _mediator.Send(query);
            return dogs.Any() ? Ok(dogs) : NotFound("No dogs found matching the criteria.");
        }

        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new AddDogCommand(newDog);
            var dog = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDogById), new { dogId = dog.Id }, dog);
        }

        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdateDogByIdCommand(updatedDog, updatedDogId);
            var result = await _mediator.Send(command);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound($"No dog found with ID: {updatedDogId}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogbyId(Guid id)
        {
            var command = new DeleteDogByIdCommand(id);
            var result = await _mediator.Send(command);
            if (result)
            {
                return NoContent();
            }

            return NotFound($"No dog found with ID: {id}");
        }
    }
}
