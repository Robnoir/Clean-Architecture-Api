using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application.Dtos;
using MediatR;
using Application;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Infrastructure.Database.Repositories.UserRepo;
using Application.Queries.Users.GetByUsername;
using Application.Validators.AuthValidations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly AuthValidation _authValidator;

        public AuthController(IMediator mediator, IUserRepository userRepository, IConfiguration configuration, AuthValidation authValidator)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mediator = mediator;
            _authValidator = authValidator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterAsync(UserDto request)
        {
            var validationResult = _authValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                return BadRequest("Username is already taken.");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            User newUser = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash
            };

            await _userRepository.AddUserAsync(newUser);
            return CreatedAtAction(nameof(Login), new { Username = newUser.Username });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto request)
        {
            var validationResult = _authValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var user = await _mediator.Send(new GetByUsernameQuery(request.Username));
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Unauthorized("Username or password is incorrect.");
            }

            var token = CreateToken(user);
            return Ok(new { Token = token });
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var secretKey = _configuration["JwtSettings:SecretKey"];
            if (secretKey == null)
            {
                throw new InvalidOperationException("Secret key must not be null.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}