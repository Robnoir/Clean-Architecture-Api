using Application.Commands.Dogs;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {

        internal readonly IMediator _mediator;
        internal readonly DogValidator _dogValidator;
        internal readonly GuidValidator _guidValidator;

        public DogsController(IMediator mediator, DogValidator dogValidator, GuidValidator guidvalidator)
        {
            _mediator = mediator;
            _dogValidator = dogValidator;
            _guidValidator = guidvalidator;
        }

        // Get all dogs from database
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            return Ok(await _mediator.Send(new GetAllDogsQuery()));
            // return Ok("GET ALL DOGS");
        }

        // Get a dog by Id
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            // Validate dog
            var validatedId = _guidValidator.Validate(dogId);
            // Error handling
            if (!validatedId.IsValid)
            {
                return BadRequest(validatedId.Errors.ConvertAll(error => error.ErrorMessage));
            }
            // Try Catch
            try
            {
                return Ok(await _mediator.Send(new GetDogByIdQuery(dogId)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        // Create a new dog 
        [HttpPost]
        [Route("addNewDog")]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            // Validate dog
            var validatedDog = _dogValidator.Validate(newDog);
            // Error Handling
            if (!validatedDog.IsValid)
            {
                return BadRequest(validatedDog.Errors.ConvertAll(error => error.ErrorMessage));
            }
            // Try catch
            try
            {
                return Ok(await _mediator.Send(new AddDogCommand(newDog)));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // Update a specific dog
        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            //Validate
            var validatedDogId = _guidValidator.Validate(updatedDogId);
            var dogValidator = _dogValidator.Validate(updatedDog);
            //Error Hadling
            if (!validatedDogId.IsValid)
            {

                return BadRequest(validatedDogId.Errors.ConvertAll(error => error.ErrorMessage));
            }

            if (!dogValidator.IsValid)
            {
                return BadRequest(dogValidator.Errors.ConvertAll(error => error.ErrorMessage));
            }
            // TryCatch
            try
            {
                return Ok(await _mediator.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId)));

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        // Delete specific dog
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogbyId(Guid id)
        {
            var dog = await _mediator.Send(new DeleteDogByIdCommand(id));

            if (dog != null)
            {
                return NoContent();
            }

            return NotFound();
        }



    }
}
