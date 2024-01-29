using Domain.Models;
using Infrastructure.Database.Repositories.CatRepo;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;
        private readonly ILogger<UpdateCatByIdCommandHandler> _logger;

        public UpdateCatByIdCommandHandler(ICatRepository catRepository, ILogger<UpdateCatByIdCommandHandler> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }

        public async Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Attempting to update cat with ID: {CatId}", request.Id);

                Cat catToUpdate = await _catRepository.GetByIdAsync(request.Id);

                if (catToUpdate == null)
                {
                    _logger.LogWarning("No cat found with ID: {CatId}", request.Id);
                    return null!;
                }

                // Logging the details of the cat before update
                _logger.LogInformation("Updating cat with ID: {CatId}. Current details: {CurrentDetails}", request.Id, catToUpdate);

                catToUpdate.Name = request.UpdateCat.Name;
                catToUpdate.LikesToPlay = request.UpdateCat.LikesToPlay;

                await _catRepository.UpdateAsync(catToUpdate);

                // Logging the successful update
                _logger.LogInformation("Cat successfully updated with ID: {CatId}. Updated details: {UpdatedDetails}", request.Id, catToUpdate);

                return catToUpdate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating cat with ID: {CatId}", request.Id);
                throw;
            }
        }
    }
}
