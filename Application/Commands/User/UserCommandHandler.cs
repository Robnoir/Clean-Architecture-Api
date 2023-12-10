using Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public class UserCommandHandler : IRequestHandler<UserCommand, string>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly CreateTokenService _createTokenService;

        public UserCommandHandler(IAuthenticationService authenticationService, CreateTokenService createTokenService)
        {
            _authenticationService = authenticationService;
            _createTokenService = createTokenService;
        }

        public async Task<string> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.AuthenticateAsync(request.User.UserName, request.User.Password);
            if (user == null)
            {
                // Consider how you want to handle this case.
                // You might throw an exception or return a result indicating failure.
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            return _createTokenService.CreateToken(user);
        }
    }
}
