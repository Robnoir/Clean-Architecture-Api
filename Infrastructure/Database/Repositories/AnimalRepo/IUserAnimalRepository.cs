// Infrastructure/Database/Repositories/AnimalRepo/IUserAnimalRepository.cs

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.AnimalRepo
{
    public interface IUserAnimalRepository
    {
        Task<UserAnimalModel> AssignAnimalToUserAsync(Guid userId, Guid animalId);
        Task<IEnumerable<User>> GetAllUsersWithAnimalsAsync();
        Task UpdateAnimalOrUserAsync(Guid userId, Guid animalId);
        Task RemoveAnimalFromUserAsync(Guid userId, Guid animalId);
    }
}
