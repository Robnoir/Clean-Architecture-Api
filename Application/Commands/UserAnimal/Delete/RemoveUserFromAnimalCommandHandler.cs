using Infrastructure.Database.Repositories.AnimalRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.Delete
{
    internal class RemoveUserFromAnimalCommandHandler
    {
        private readonly IUserAnimalRepository _repository;

        public RemoveUserFromAnimalCommandHandler(IUserAnimalRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemoveUserFromAnimalCommand command)
        {
            await _repository.RemoveAnimalFromUserAsync(command.UserId, command.AnimalId);
        }
    }
}
