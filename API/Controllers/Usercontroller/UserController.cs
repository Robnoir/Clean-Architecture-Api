using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using MediatR;
using Application;
using FluentValidation;


namespace API.Controllers.Usercontroller
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        internal readonly IMediator _mediator;
        internal readonly UserValidator _userValidator;
        internal readonly GuidValidator _guidValidator;


        public UserController(IMediator mediator, UserValidator userValidator, GuidValidator guidValidator)
        {
            _mediator = mediator;
            _userValidator = userValidator;
            _guidValidator = guidValidator;
        }


        // ------------------------------------------------------------------------------------------------------
        // Get all users
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }
        // ------------------------------------------------------------------------------------------------------
        // Get User by Id
        [HttpGet]
        [Route("getUserById")]
        public async Task<IActionResult> GetUserById(Guid UserId)
        {
            var validatedId = _guidValidator.Validate(UserId);
            if (!validatedId.IsValid)
            {
                return BadRequest(validatedId.Errors.ConvertAll(error => error.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new GetUserByIdQuery(UserId)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // ------------------------------------------------------------------------------------------------------
        // Update Specific User
        [HttpPut]
        [Route("updateUser/{updatedUserId}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto updatedUserDto, Guid updatedUserId, string newPassword)
        {
            try
            {
                var command = new UpdateUserByIdCommand(updatedUserDto, updatedUserId,newPassword);
                var result = await _mediator.Send(command);
                

                if (result == null)
                {
                    return NotFound("User not found.");
                }

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                // Handle not found exception
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                // Handle validation exceptions
                return BadRequest(ex.Errors);
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        // ------------------------------------------------------------------------------------------------------
        // Delete user by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            var user = await _mediator.Send(new DeleteUserByIdCommand(id));

            if (user != null)
            {
                return NoContent();
            }
            return NotFound();
        }
        // ------------------------------------------------------------------------------------------------------




    }
}
