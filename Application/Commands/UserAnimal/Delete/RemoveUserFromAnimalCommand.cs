using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.Delete
{
   public class RemoveUserFromAnimalCommand :IRequest
{
    public Guid UserId { get; set; }
    public Guid AnimalId { get; set; }
}
}
