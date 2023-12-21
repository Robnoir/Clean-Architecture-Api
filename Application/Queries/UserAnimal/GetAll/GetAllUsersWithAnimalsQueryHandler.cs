using Application.Dtos;
using Domain.Models;
using Infrastructure.Database.Repositories.AnimalRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UserAnimal.GetAll
{
    public class GetAllUsersWithAnimalsQueryHandler : IRequestHandler<GetAllUsersWithAnimalsQuery, IEnumerable<UserAnimalDto>>
    {
        private readonly IUserAnimalRepository _userAnimalRepository;

        public GetAllUsersWithAnimalsQueryHandler(IUserAnimalRepository userAnimalRepository)
        {
            _userAnimalRepository = userAnimalRepository;
        }

        public async Task<IEnumerable<UserAnimalDto>> Handle(GetAllUsersWithAnimalsQuery request, CancellationToken cancellationToken)
        {
            var users = await _userAnimalRepository.GetAllUsersWithAnimalsAsync();
            return users.Select(user => new UserAnimalDto
            {
                UserId = user.Id,



            });
        }


    }
}
