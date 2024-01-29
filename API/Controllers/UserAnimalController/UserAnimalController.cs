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
using FluentValidation.Results; // Assuming you're using FluentValidation

namespace API.Controllers.UserAnimalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnimalsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserAnimalValidator _userAnimalValidator;
        private readonly GuidValidator _guidValidator; 

        public UserAnimalsController(IMediator mediator, UserAnimalValidator userAnimalValidator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _userAnimalValidator = userAnimalValidator;
            _guidValidator = guidValidator;
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
        public async Task<IActionResult> AddUserAnimal(AddUserAnimalCommand command)
        {
            try
            {
                var userValidationResult = _guidValidator.Validate(command.UserId);
                var animalValidationResult = _guidValidator.Validate(command.AnimalId);

                if (!userValidationResult.IsValid || !animalValidationResult.IsValid)
                {
                    return BadRequest("Invalid User ID or Animal Model ID.");
                }

                var result = await _mediator.Send(command);

                return result != null ? Ok(result) : BadRequest("Failed to add user animal relationship.");
            }
            catch (Exception ex)
            {
                // Logga felet här
                return StatusCode(500, "Ett fel inträffade vid tillägg av djurrelation: " + ex.Message);
            }



        }

        [HttpDelete("DeleteRelationShip/{userId}/{animalModelId}")]
        public async Task<IActionResult> RemoveUserAnimal(Guid userId, Guid animalModelId)
        {
            ValidationResult userValidationResult = _guidValidator.Validate(userId);
            ValidationResult animalValidationResult = _guidValidator.Validate(animalModelId);

            if (!userValidationResult.IsValid || !animalValidationResult.IsValid)
            {
                return BadRequest("Invalid User ID or Animal Model ID.");
            }

            var command = new RemoveUserAnimalCommand(userId, animalModelId);
            var result = await _mediator.Send(command);
            return result ? Ok("Relation removed successfully") : BadRequest("Failed to remove relation");
        }

        [HttpPut("{userId}/{currentAnimalModelId}/{newAnimalModelId}")]
        public async Task<IActionResult> UpdateUserAnimal(Guid userId, Guid currentAnimalModelId, Guid newAnimalModelId)
        {
            ValidationResult userValidationResult = _guidValidator.Validate(userId);
            ValidationResult currentAnimalValidationResult = _guidValidator.Validate(currentAnimalModelId);
            ValidationResult newAnimalValidationResult = _guidValidator.Validate(newAnimalModelId);

            if (!userValidationResult.IsValid || !currentAnimalValidationResult.IsValid || !newAnimalValidationResult.IsValid)
            {
                return BadRequest("Invalid data provided for update.");
            }

            var command = new UpdateUserAnimalCommand(userId, currentAnimalModelId, newAnimalModelId);
            var result = await _mediator.Send(command);
            return result ? Ok("Relation updated successfully") : BadRequest("Failed to update relation");
        }
    }
}
