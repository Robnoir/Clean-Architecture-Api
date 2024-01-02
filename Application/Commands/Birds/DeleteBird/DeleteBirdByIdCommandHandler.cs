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

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {

        private readonly IBirdRepository _birdRepository;
        private readonly ILogger<DeleteBirdByIdCommandHandler> _logger;
        public DeleteBirdByIdCommandHandler(IBirdRepository birdRepository, ILogger<DeleteBirdByIdCommandHandler> logger)
        {
            _logger = logger;
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {

                _logger.LogInformation("Starting to handle DeleteBirdByIdCommand for bird ID: {BirdId}", request.Id);
                Bird birdToDelete = await _birdRepository.GetByIdAsync(request.Id);
                if (birdToDelete == null)
                {
                    _logger.LogWarning("No bird with the given ID {BirdID} was found",request.Id);
                    throw new InvalidOperationException("No Bird with the given id was found");
                }

                await _birdRepository.DeleteAsync(request.Id);

                _logger.LogInformation("The bird was successfully deleted {BirdId}", request.Id);

                return birdToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while handling deletion for bird by id {BirdId}", request.Id);
                throw;
            }

          

        }




    }
}
