using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetById
{
    public class GetCatByIdQuery : IRequest<Cat>
    {
        public GetCatByIdQuery(Guid catId)
        {
            Id = catId;
        }
        public Guid Id { get; }

    }
}
