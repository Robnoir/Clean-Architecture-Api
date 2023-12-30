using Domain.Models;

namespace Infrastructure;

public interface IDogRepository
{
    Task<Dog> GetByIdAsync(Guid dogId);
    Task<Dog> AddAsync(Dog dogToCreate);
    Task UpdateAsync(Dog dog);
    Task DeleteAsync(Guid dogId);
    Task<List<Dog>> GetDogByBreedAndWeight(string breed, int?  weight);
    Task<List<Dog>> GetAllDogsAsync();
}
