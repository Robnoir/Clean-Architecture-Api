using Application.Dtos;
using Application.Queries.UserAnimal.GetAll;
using Domain.Models;
using Infrastructure.Database.Repositories.UserAnimalRepo;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries.UserAnimal
{
    public class GetAllUsersWithAnimalsQueryHandler : IRequestHandler<GetAllUsersWithAnimalsQuery, IEnumerable<UserAnimalDto>>
    {
        private readonly IUserAnimalRepository _repository;
        private readonly ILogger<GetAllUsersWithAnimalsQueryHandler> _logger;

        public GetAllUsersWithAnimalsQueryHandler(IUserAnimalRepository repository, ILogger<GetAllUsersWithAnimalsQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<UserAnimalDto>> Handle(GetAllUsersWithAnimalsQuery request, CancellationToken cancellationToken)
        {


            try
            {
                _logger.LogInformation("Starting to process GetAllUsersWithAnimalsQuery.");

                var users = await _repository.GetAllUsersWithAnimalsAsync();

                var userAnimalDtos = users.Select(user => new UserAnimalDto
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Dogs = user.UserAnimals
                        .Where(ua => ua.AnimalModel is Dog)
                        .Select(ua => new DogDto
                        {
                            Name = ((Dog)ua.AnimalModel).Name,
                            Breed = ((Dog)ua.AnimalModel).DogBreed, // Exempel på hur man inkluderar ras
                            Weight = ((Dog)ua.AnimalModel).DogWeight // Exempel på hur man inkluderar vikt
                        }).ToList(),
                    Cats = user.UserAnimals
                        .Where(ua => ua.AnimalModel is Cat)
                        .Select(ua => new CatDto
                        {
                            Name = ((Cat)ua.AnimalModel).Name,
                            LikesToPlay = ((Cat)ua.AnimalModel).LikesToPlay,
                            Breed = ((Cat)ua.AnimalModel).CatBreed, // Lägg till fler attribut här
                            Weight = ((Cat)ua.AnimalModel).CatWeight
                        }).ToList(),
                    Birds = user.UserAnimals
                        .Where(ua => ua.AnimalModel is Bird)
                        .Select(ua => new BirdDto
                        {
                            Name = ((Bird)ua.AnimalModel).Name,
                            CanFly = ((Bird)ua.AnimalModel).CanFly,
                            BirdColor = ((Bird)ua.AnimalModel).BirdColor // Lägg till fler attribut här
                        }).ToList(),
                });

                _logger.LogInformation($"Retrieved {users.Count()} users with animals from the database.");
                return userAnimalDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all users with animals from the database");
                return new List<UserAnimalDto>();
            }




        }
    }
}