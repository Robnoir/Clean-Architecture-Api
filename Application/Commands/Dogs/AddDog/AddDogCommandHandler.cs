using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure;
using Infrastructure.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Commands.Dogs
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        private readonly ILogger<AddDogCommandHandler> _logger;

        public AddDogCommandHandler(IDogRepository dogRepository, ILogger<AddDogCommandHandler> logger)
        {
            _dogRepository = dogRepository;
            _logger = logger;
        }

        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Attempting to add a new dog with Name: {DogName}, DogBreed: {DogBreed}", request.NewDog.Name, request.NewDog.Breed);

                Dog dogToCreate = new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.NewDog.Name,
                    DogBreed = request.NewDog.Breed,
                    DogWeight = request.NewDog.Weight
                };

                await _dogRepository.AddAsync(dogToCreate);

                _logger.LogInformation("Dog successfully added with ID: {DogId}", dogToCreate.Id);

                return dogToCreate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new dog with Name: {DogName}, DogBreed: {DogBreed}", request.NewDog.Name, request.NewDog.Breed);
                throw;
            }
        }
    }
}
