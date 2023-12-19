using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetByUsername
{
    public class GetByUsernameQuery : IRequest<User>
    {
        public string Username { get; set; }
        public GetByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
