using Application.Commands.UserAnimal.AddUseranimal;
using Application.Commands.UserAnimal.RemoveUserAnimal;
using Application.Commands.UserAnimal.UpdateUseranimal;
using Application.Queries.UserAnimal.GetAll;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Validators.UserAnimal;

namespace API.Controllers.UserAnimalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnimalsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserAnimalValidator _UserAnimalValidator;

        public UserAnimalsController(IMediator mediator, UserAnimalValidator UserAnimalValidator)
        {
            _mediator = mediator;
            _UserAnimalValidator = UserAnimalValidator;
        }

        [HttpGet]
        [Route("GetAllUsersWithAnimals")]
        public async Task<IActionResult> GetAllUsersWithAnimals()
        {
            var query = new GetAllUsersWithAnimalsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPost]
        [Route("AddUserAnimal")]
        public async Task<IActionResult> AddUserAnimal([FromBody] UserAnimalDto userAnimalDto)
        {
            var validationResult = _UserAnimalValidator.Validate(userAnimalDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var command = new AddUserAnimalCommand(userAnimalDto.UserId, userAnimalDto.AnimalId);
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : BadRequest("Failed to add user animal relationship.");
        }


        [HttpDelete("DeleteRelationShip/{userId}/{animalModelId}")]
        public async Task<IActionResult> RemoveUserAnimal(Guid userId, Guid animalModelId)
        {
            var command = new RemoveUserAnimalCommand(userId, animalModelId);
            var result = await _mediator.Send(command);
            return result ? Ok("Relation removed successfully") : BadRequest("Failed to remove relation");
        }

        [HttpPut("{userId}/{currentAnimalModelId}/{newAnimalModelId}")]
        public async Task<IActionResult> UpdateUserAnimal(Guid userId, Guid currentAnimalModelId, Guid newAnimalModelId)
        {
            var command = new UpdateUserAnimalCommand(userId, currentAnimalModelId, newAnimalModelId);
            var result = await _mediator.Send(command);
            return result ? Ok("Relation updated successfully") : BadRequest("Failed to update relation");
        }
    }
}
