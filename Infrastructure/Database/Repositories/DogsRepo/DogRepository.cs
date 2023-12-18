using Domain.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure;

public class DogRepository : IDogRepository
{

    private readonly RealDatabase _realDatabase;

    public Task<Dog> AddAsync(Dog dogToCreate)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid dogId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Dog>> GetAllDogsAsync()
    {
        return await _realDatabase.Dogs.ToListAsync();
    }

    public Task<Dog> GetByIdAsync(Guid dogId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Dog dog)
    {
        throw new NotImplementedException();
    }
}
