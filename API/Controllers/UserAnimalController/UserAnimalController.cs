using Application.Commands.UserAnimal.AddUseranimal;
using Application.Commands.UserAnimal.RemoveUserAnimal;
using Application.Commands.UserAnimal.UpdateUseranimal;
using Application.Queries.UserAnimal.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UserAnimalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnimalsController : Controller
    {
        private readonly IMediator _mediator;

        public UserAnimalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/UserAnimals
        [HttpGet]
        [Route("GetAllUsersWithAnimal")]
        public async Task<IActionResult> GetAllUsersWithAnimals()
        {
            var query = new GetAllUsersWithAnimalsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST: api/UserAnimals
        [HttpPost]
        [Route("AddUserAnimal")]
        public async Task<IActionResult> AddUserAnimal(AddUserAnimalCommand command)
        {
            var result = await _mediator.Send(command);

            if (result != null)
                return Ok(result);  // Antag att result Ã¤r ett UserAnimalDto-objekt
            else
                return BadRequest("Failed to add user animal relationship.");
        }

        // DELETE: api/UserAnimals/{userId}/{animalModelId}
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