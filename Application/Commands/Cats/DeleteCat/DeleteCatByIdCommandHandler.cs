using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.CatRepo;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;
        private readonly Logger<DeleteCatByIdCommandHandler> _logger;

        public DeleteCatByIdCommandHandler(ICatRepository catRepository,Logger<DeleteCatByIdCommandHandler> logger)
        {
            _catRepository = catRepository;
            _logger = logger;
        }

        public async Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Attempting to delete cat with ID: {CatId}", request.Id);

                Cat catToDelete = await _catRepository.GetByIdAsync(request.Id);

                if (catToDelete == null)
                {
                    _logger.LogWarning("No cat found with ID: {CatId}", request.Id);
                    throw new InvalidOperationException("No cat with the given id was found");
                }

                await _catRepository.DeleteAsync(request.Id);

                _logger.LogInformation("Cat successfully deleted with ID: {CatId}", request.Id);

                return catToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting cat with ID: {CatId}", request.Id);
                throw;
            }
        }

    }
}
