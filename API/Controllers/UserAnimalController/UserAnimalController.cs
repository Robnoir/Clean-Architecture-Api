using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.UserAnimal.Add; // Anpassa efter ditt projekts namnrymd
using Application.Commands.UserAnimal.Update;
using Application.Commands.UserAnimal.Delete;
using Application.Queries.UserAnimal;
using Application.Queries.UserAnimal.GetAll;

namespace API.Controllers.UserAnimalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnimalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserAnimalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Assign")]
        public async Task<IActionResult> AssignAnimalToUser([FromBody] UserAnimalDto userAnimalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userAnimal = await _mediator.Send(new AssignUserToAnimalCommand
                {
                    UserId = userAnimalDto.UserId,
                    AnimalId = userAnimalDto.AnimalId
                });

                return Ok(userAnimal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/UserAnimals
        [HttpGet]
        public async Task<IActionResult> GetAllUsersWithAnimals()
        {
            var usersWithAnimals = await _mediator.Send(new GetAllUsersWithAnimalsQuery());
            return Ok(usersWithAnimals);
        }

        // PUT: api/UserAnimals/Update
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAnimalOrUser([FromBody] UserAnimalDto userAnimalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mediator.Send(new UpdateUserAnimalCommand { UserId = userAnimalDto.UserId, AnimalId = userAnimalDto.AnimalId });
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/UserAnimals/Unassign
        [HttpDelete("Unassign")]
        public async Task<IActionResult> RemoveAnimalFromUser([FromBody] UserAnimalDto userAnimalDto)
        {
            try
            {
                await _mediator.Send(new RemoveUserFromAnimalCommand { UserId = userAnimalDto.UserId, AnimalId = userAnimalDto.AnimalId });
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
