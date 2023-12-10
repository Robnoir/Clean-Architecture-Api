using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public class AuthenticateUserCommand : IRequest<string>
    {
        public UserDto UserDto { get; }

        public AuthenticateUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}
