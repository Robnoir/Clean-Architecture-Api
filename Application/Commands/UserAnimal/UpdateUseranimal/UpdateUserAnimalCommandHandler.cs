using Infrastructure.Database.Repositories.UserAnimalRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.UpdateUseranimal
{
    public class UpdateUserAnimalCommandHandler : IRequestHandler<UpdateUserAnimalCommand, bool>
    {
        private readonly IUserAnimalRepository _repository;

        public UpdateUserAnimalCommandHandler(IUserAnimalRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateUserAnimalCommand request, CancellationToken cancellationToken)
        {
            // Implementera logiken för att uppdatera en användar-djur-relation
            await _repository.UpdateUserAnimalAsync(request.UserId, request.CurrentAnimalModelId, request.NewAnimalModelId);
            return true; // Eller hantera eventuella fel och returnera false
        }
    }
}
