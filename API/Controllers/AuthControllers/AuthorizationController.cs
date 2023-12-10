using Application.Commands.User;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AuthControllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
    

        private readonly IMediator _mediator;

        public AuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<String>> Login(UserDto userLogin)
        {
            var token = await _mediator.Send(new UserCommand(userLogin));
            return Ok(token);
        }
    }
}
