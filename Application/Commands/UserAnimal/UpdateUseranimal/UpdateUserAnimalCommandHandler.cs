using Infrastructure.Database.Repositories.UserAnimalRepo;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Commands.UserAnimal.UpdateUseranimal
{
    public class UpdateUserAnimalCommandHandler : IRequestHandler<UpdateUserAnimalCommand, bool>
    {
        private readonly IUserAnimalRepository _repository;
        private readonly ILogger<UpdateUserAnimalCommandHandler> _logger;

        public UpdateUserAnimalCommandHandler(IUserAnimalRepository repository, ILogger<UpdateUserAnimalCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateUserAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Attempting to update user-animal relationship for User ID: {UserId} from Current Animal Model ID: {CurrentAnimalModelId} to New Animal Model ID: {NewAnimalModelId}", request.UserId, request.CurrentAnimalModelId, request.NewAnimalModelId);

                // Logic to update user-animal relationship
                await _repository.UpdateUserAnimalAsync(request.UserId, request.CurrentAnimalModelId, request.NewAnimalModelId);

                _logger.LogInformation("Successfully updated user-animal relationship for User ID: {UserId}", request.UserId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating user-animal relationship for User ID: {UserId}", request.UserId);
                return false;
            }
        }
    }
}
