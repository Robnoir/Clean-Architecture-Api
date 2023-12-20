
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Database.Repositories.AnimalRepo;

namespace Application.Commands.UserAnimal.Add
{
    public class AssignAnimalToUserCommandHandler : IRequestHandler<AssignUserToAnimalCommand, UserAnimalModel>
    {
        private readonly IUserAnimalRepository _userAnimalRepository;

        public AssignAnimalToUserCommandHandler(IUserAnimalRepository userAnimalRepository)
        {
            _userAnimalRepository = userAnimalRepository;
        }

        public async Task<UserAnimalModel> Handle(AssignUserToAnimalCommand request, CancellationToken cancellationToken)
        {
            return await _userAnimalRepository.AssignAnimalToUserAsync(request.UserId, request.AnimalId);
        }
    }
}
