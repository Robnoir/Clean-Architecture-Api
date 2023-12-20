using MediatR;
using Domain.Models;
using System;

namespace Application.Commands.UserAnimal.Add
{
    public class AssignUserToAnimalCommand : IRequest<UserAnimalModel>
    {
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }
    }
}