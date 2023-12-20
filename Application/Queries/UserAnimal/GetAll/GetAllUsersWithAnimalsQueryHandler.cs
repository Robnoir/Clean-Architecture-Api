using Domain.Models;
using Infrastructure.Database.Repositories.AnimalRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UserAnimal.GetAll
{
    public class GetAllUsersWithAnimalsQueryHandler
    {
        private readonly IUserAnimalRepository _repository;

        public GetAllUsersWithAnimalsQueryHandler(IUserAnimalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> HandleAsync(GetAllUsersWithAnimalsQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetaAllUsersWithAnimalsAsync();
        }
    }
}
