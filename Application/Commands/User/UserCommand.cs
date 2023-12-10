using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public class UserCommand : IRequest<string>
    {
        public UserDto User { get; set; }

        public UserCommand(UserDto user) 
        {
            User = user;

        }

    }
}
