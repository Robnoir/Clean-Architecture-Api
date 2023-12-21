using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UserAnimal.GetAll
{
    public class GetAllUsersWithAnimalsQuery : IRequest<IEnumerable<UserAnimalDto>>
    {
    }
}
