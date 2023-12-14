using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application.Dtos;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Application;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    // Defines the route as "api/[controller]" and sets this class as an API controller.
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {



        internal readonly IMediator _mediator;
        internal readonly UserValidator _userValidator;
        internal readonly GuidValidator _guidValidator;


        public AuthController(IMediator mediator, UserValidator userValidator, GuidValidator guidValidator, IConfiguration configuration)
        {
            _mediator = mediator;
            _userValidator = userValidator;
            _guidValidator = guidValidator;
            _configuration = configuration;

        }


        // A static user instance for demonstration. In a real application, you'd use a database.
        public static User user = new User();

        // Configuration object to access settings like JWT parameters.
        private readonly IConfiguration _configuration;


        // ------------------------------------------------------------------------------------------------------
        // Endpoint for registering a new user.
        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            // Hashes the password using BCrypt for security.
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Sets the username and password hash for the user.
            user.Username = request.Username;
            user.PasswordHash = passwordHash;

            // Returns the registered user. (Note: In real apps, don't return sensitive data.)
            return Ok(user);
        }
        // ------------------------------------------------------------------------------------------------------
        // Endpoint for logging in a user.
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<string> Login(LoginDto request)
        {
            // Checks if the username exists. Returns an error if not found.
            if (user.Username != request.Username)
            {
                return BadRequest("User not found");
            }

            // Verifies the password. If incorrect, returns an error.
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password");
            }

            // Creates a JWT token for the authenticated user.
            string token = CreateToken(user);

            // Returns the generated token.
            return Ok(token);
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
        public async Task<IActionResult> UpdateUser([FromBody] UserDto updatedUserDto, Guid updatedUserId)
        {
            try
            {
                var command = new UpdateUserByIdCommand(updatedUserDto, updatedUserId);
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
        // Helper method to create a JWT token.
        private string CreateToken(User user)
        {
            // Just the username is used as a claim.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Fetches the secret key from configuration. Secret key can't be null.
            var secretKey = _configuration["JwtSettings:SecretKey"];
            if (secretKey == null)
            {
                throw new InvalidOperationException("Secret key must not be null.");
            }

            // Creates security key using the fetched secret key.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Creates signing credentials using the security key.
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Creates the JWT token with the specified issuer, audience, claims, expiration date, and credentials.
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            // Serializes the token to a JWT string and returns it.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
