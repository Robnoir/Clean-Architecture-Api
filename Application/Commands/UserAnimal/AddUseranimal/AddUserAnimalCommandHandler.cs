using Application.Dtos;
using Infrastructure.Database.Repositories.UserAnimalRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserAnimal.AddUseranimal
{
    public class AddUserAnimalCommandHandler : IRequestHandler<AddUserAnimalCommand, UserAnimalDto>
    {
        private readonly IUserAnimalRepository _repository;

        public AddUserAnimalCommandHandler(IUserAnimalRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserAnimalDto> Handle(AddUserAnimalCommand request, CancellationToken cancellationToken)
        {
            // Här implementerar du logiken för att lägga till en användar-djur-relation
            // och returnera informationen som ett UserAnimalDto-objekt.
            // Exempel:
            await _repository.AddUserAnimalAsync(request.UserId, request.AnimalModelId);
            return new UserAnimalDto
            {
                UserId = request.UserId,
                // Fyll i övriga fält beroende på dina behov
            };

        }
    }
}
