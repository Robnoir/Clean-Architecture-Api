using Infrastructure.Database.Repositories.UserAnimalRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.RemoveUserAnimal
{
    public class RemoveUserAnimalCommandHandler : IRequestHandler<RemoveUserAnimalCommand, bool>
    {
        private readonly IUserAnimalRepository _repository;

        public RemoveUserAnimalCommandHandler(IUserAnimalRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(RemoveUserAnimalCommand request, CancellationToken cancellationToken)
        {
            // Implementera logiken för att ta bort en användar-djur-relation
            await _repository.RemoveUserAnimalAsync(request.UserId, request.AnimalId);
            return true; // Eller hantera eventuella fel och returnera false
        }
    }
}
