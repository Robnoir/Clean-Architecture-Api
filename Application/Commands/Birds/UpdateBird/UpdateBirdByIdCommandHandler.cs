using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.BirdRepo;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Birds.UpdateBird
{
    public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;
        private readonly ILogger<UpdateBirdByIdCommandHandler> _logger;

        public UpdateBirdByIdCommandHandler(IBirdRepository birdRepository, ILogger<UpdateBirdByIdCommandHandler> logger)
        {
            _birdRepository = birdRepository;
            _logger = logger;
        }
        public async Task<Bird> Handle(UpdateBirdByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Starting to handle UpdateBirdByIdcommand {BirdId}", request.Id);

                Bird birdToUpdate = await _birdRepository.GetByIdAsync(request.Id);

                if (birdToUpdate == null)
                {
                    return null;
                }
                // Log the details of the bird before update
                _logger.LogInformation("Updating bird with ID: {BirdId}. Current details: {CurrentDetails}", request.Id, birdToUpdate);

                // Updating the bird details
                birdToUpdate.Name = request.UpdatedBird.Name;


                await _birdRepository.UpdateAsync(birdToUpdate);


                return birdToUpdate;
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur
                _logger.LogError(ex, "Error occurred while handling UpdateBirdByIdCommand for bird ID: {BirdId}", request.Id);
                throw;
            }
        }
    }

}
