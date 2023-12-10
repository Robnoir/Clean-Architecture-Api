using Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly CreateTokenService _createTokenService;

        public AuthenticateUserCommandHandler(
            IAuthenticationService authenticationService,
            CreateTokenService createTokenService)
        {
            _authenticationService = authenticationService;
            _createTokenService = createTokenService;
        }

        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.AuthenticateAsync(request.UserDto.UserName, request.UserDto.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            return _createTokenService.CreateToken(user);
        }
    }
}
