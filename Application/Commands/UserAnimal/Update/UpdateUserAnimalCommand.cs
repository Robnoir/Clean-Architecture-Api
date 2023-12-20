using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.Update
{
    public class UpdateUserAnimalCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }
        
    }
}
