using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.RemoveUserAnimal
{
    public class RemoveUserAnimalCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }

        public RemoveUserAnimalCommand(Guid userId, Guid animalId)
        {
            UserId = userId;
            AnimalId = animalId;
        }
    }
}
