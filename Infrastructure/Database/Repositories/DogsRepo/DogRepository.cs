using Domain.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure;

public class DogRepository : IDogRepository
{

    private readonly RealDatabase _realDatabase;

    public DogRepository(RealDatabase realDatabase)
    {
        _realDatabase = realDatabase;
    }
    public async Task<Dog> AddAsync(Dog dogToCreate)
    {
        _realDatabase.Dogs.Add(dogToCreate);
        _realDatabase.SaveChanges();
        return await Task.FromResult(dogToCreate);


    }
    public async Task DeleteAsync(Guid dogId)
    {
        var DeleteDogId = await _realDatabase.Dogs.FindAsync(dogId);

        if (DeleteDogId != null)
        {
            _realDatabase.Dogs.Remove(DeleteDogId);
            await _realDatabase.SaveChangesAsync();
        }

    }
    public async Task<List<Dog>> GetAllDogsAsync()
    {
        return await _realDatabase.Dogs.ToListAsync();
    }
    public async Task<Dog> GetByIdAsync(Guid dogId)
    {
        return await _realDatabase.Dogs.FindAsync(dogId);
    }
    public async Task UpdateAsync(Dog dog)
    {
        _realDatabase.Dogs.Update(dog);
        await _realDatabase.SaveChangesAsync();
    }
}
