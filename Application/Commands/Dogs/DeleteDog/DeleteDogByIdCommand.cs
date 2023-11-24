using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest <Dog>

    {
        public DeleteDogByIdCommand(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
