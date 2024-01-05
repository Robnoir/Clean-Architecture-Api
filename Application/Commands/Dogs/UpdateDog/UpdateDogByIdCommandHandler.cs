using Domain.Models;
using Infrastructure;
using Infrastructure.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        private readonly ILogger<UpdateDogByIdCommandHandler> _logger;

        public UpdateDogByIdCommandHandler(IDogRepository dogRepository, ILogger<UpdateDogByIdCommandHandler> logger)
        {
            _dogRepository = dogRepository;
            _logger = logger;
        }

        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Attempting to update dog with ID: {DogId}", request.Id);

                Dog dogToUpdate = await _dogRepository.GetByIdAsync(request.Id);

                if (dogToUpdate == null)
                {
                    _logger.LogWarning("No dog found with ID: {DogId}", request.Id);
                    return null!;
                }

                // Log before updating details
                _logger.LogInformation("Updating dog with ID: {DogId}. Current details: {CurrentDetails}", request.Id, dogToUpdate);

                dogToUpdate.Name = request.UpdatedDog.Name;
                // Include other fields if they are part of the update

                await _dogRepository.UpdateAsync(dogToUpdate);

                // Log after successful update
                _logger.LogInformation("Dog successfully updated with ID: {DogId}. Updated details: {UpdatedDetails}", request.Id, dogToUpdate);

                return dogToUpdate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating dog with ID: {DogId}", request.Id);
                throw;
            }
        }
    }
}
