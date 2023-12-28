using Application.Dtos;
using Application.Queries.UserAnimal.GetAll;
using Domain.Models;
using Infrastructure.Database.Repositories.UserAnimalRepo;
using MediatR;


namespace Application.Queries.UserAnimal
{
    public class GetAllUsersWithAnimalsQueryHandler : IRequestHandler<GetAllUsersWithAnimalsQuery, IEnumerable<UserAnimalDto>>
    {
        private readonly IUserAnimalRepository _repository;

        public GetAllUsersWithAnimalsQueryHandler(IUserAnimalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserAnimalDto>> Handle(GetAllUsersWithAnimalsQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllUsersWithAnimalsAsync();

            var userAnimalDtos = users.Select(user => new UserAnimalDto
            {
                UserId = user.Id,
                Username = user.Username,
                Dogs = user.UserAnimals
                    .Where(ua => ua.Animal is Dog)
                    .Select(ua => new DogDto { Name = ua.Animal.Name })
                    .ToList(),
                Cats = user.UserAnimals
                    .Where(ua => ua.Animal is Cat)
                    .Select(ua => new CatDto { Name = ua.Animal.Name, LikesToPlay = ((Cat)ua.Animal).LikesToPlay })
                    .ToList(),
                Birds = user.UserAnimals
                    .Where(ua => ua.Animal is Bird)
                    .Select(ua => new BirdDto { Name = ua.Animal.Name, CanFly = ((Bird)ua.Animal).CanFly })
                    .ToList(),
            });

            return userAnimalDtos;
        }
    }
}