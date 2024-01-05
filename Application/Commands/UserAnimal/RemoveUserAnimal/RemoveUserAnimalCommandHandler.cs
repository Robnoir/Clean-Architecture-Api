using Infrastructure.Database.Repositories.UserAnimalRepo;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Commands.UserAnimal.RemoveUserAnimal
{
    public class RemoveUserAnimalCommandHandler : IRequestHandler<RemoveUserAnimalCommand, bool>
    {
        private readonly IUserAnimalRepository _repository;
        private readonly ILogger<RemoveUserAnimalCommandHandler> _logger;

        public RemoveUserAnimalCommandHandler(IUserAnimalRepository repository, ILogger<RemoveUserAnimalCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(RemoveUserAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Attempting to remove user-animal relationship for User ID: {UserId} and Animal ID: {AnimalId}", request.UserId, request.AnimalId);

                // Logic to remove user-animal relationship
                await _repository.RemoveUserAnimalAsync(request.UserId, request.AnimalId);

                _logger.LogInformation("Successfully removed user-animal relationship for User ID: {UserId} and Animal ID: {AnimalId}", request.UserId, request.AnimalId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing user-animal relationship for User ID: {UserId} and Animal ID: {AnimalId}", request.UserId, request.AnimalId);
                return false;
            }
        }
    }
}
