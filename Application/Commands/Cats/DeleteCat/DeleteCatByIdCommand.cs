using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommand : IRequest<Cat>
    {
        public DeleteCatByIdCommand(Guid id)
        {
            Id = id;

        }
        public Guid Id { get; set; }
    }
}
