using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetAll
{
    public class GetAllCatsQuery : IRequest<List<Cat>>
    {
    }
}
