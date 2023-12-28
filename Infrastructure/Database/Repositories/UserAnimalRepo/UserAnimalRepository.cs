using Domain.Models.Animal;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Database.Repositories.UserAnimalRepo
{
    public class UserAnimalRepository : IUserAnimalRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserAnimalRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<UserAnimal> AddUserAnimalAsync(Guid userId, Guid animalId)
        {
            var user = await _realDatabase.Users.FindAsync(userId);
            var animal = await _realDatabase.Set<AnimalModel>().FindAsync(animalId);

            if (user == null || animal == null)
            {
                throw new ArgumentException("User or Animal not found");
            }

            var userAnimal = new UserAnimal { UserId = userId, AnimalId = animalId };
            _realDatabase.UserAnimals.Add(userAnimal);
            await _realDatabase.SaveChangesAsync();

            return userAnimal;
        }
        public async Task RemoveUserAnimalAsync(Guid userId, Guid animalId)
        {
            var userAnimal = await _realDatabase.UserAnimals
                                           .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AnimalId == animalId);
            if (userAnimal != null)
            {
                _realDatabase.UserAnimals.Remove(userAnimal);
                await _realDatabase.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<User>> GetAllUsersWithAnimalsAsync()
        {
            return await _realDatabase.Users
                                  .Include(u => u.UserAnimals)
                                  .ThenInclude(ua => ua.Animal)
                                  .ToListAsync();
        }
        public async Task UpdateUserAnimalAsync(Guid userId, Guid currentAnimalModelId, Guid newAnimalModelId)
        {
            // Ta bort den gamla relationen
            var existingRelation = await _realDatabase.UserAnimals
                .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AnimalId == currentAnimalModelId);

            if (existingRelation != null)
            {
                _realDatabase.UserAnimals.Remove(existingRelation);
            }

            // Lägg till den nya relationen
            var newRelation = new UserAnimal { UserId = userId, AnimalId = newAnimalModelId };
            _realDatabase.UserAnimals.Add(newRelation);

            await _realDatabase.SaveChangesAsync();
        }


    }
}
