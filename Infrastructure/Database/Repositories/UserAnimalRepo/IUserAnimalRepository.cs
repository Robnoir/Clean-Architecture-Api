using Domain.Models;



namespace Infrastructure.Database.Repositories.UserAnimalRepo
{
    public interface IUserAnimalRepository
    {
        Task<IEnumerable<User>> GetAllUsersWithAnimalsAsync();
        Task<UserAnimal> AddUserAnimalAsync(Guid userId, Guid animalModelId);
        Task RemoveUserAnimalAsync(Guid userId, Guid animalId);
        Task UpdateUserAnimalAsync(Guid userId, Guid currentAnimalModelId, Guid newAnimalModelId);
    }
}
