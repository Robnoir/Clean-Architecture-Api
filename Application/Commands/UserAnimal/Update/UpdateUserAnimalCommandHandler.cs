using Infrastructure.Database.Repositories.AnimalRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.Update
{
    public class UpdateUserAnimalCommandHandler
    {
        private readonly IUserAnimalRepository _repository;

        public UpdateUserAnimalCommandHandler(IUserAnimalRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(UpdateUserAnimalCommand command)
        {
            // Logic to update user or animal based on the command properties
        }
    }
}
