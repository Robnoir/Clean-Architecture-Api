using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.UpdateUseranimal
{
    public class UpdateUserAnimalCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid CurrentAnimalModelId { get; set; }
        public Guid NewAnimalModelId { get; set; }

        public UpdateUserAnimalCommand(Guid userId, Guid currentAnimalModelId, Guid newAnimalModelId)
        {
            UserId = userId;
            CurrentAnimalModelId = currentAnimalModelId;
            NewAnimalModelId = newAnimalModelId;
        }
    }

}
