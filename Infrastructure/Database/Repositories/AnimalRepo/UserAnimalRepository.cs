using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Database.Repositories.AnimalRepo
{
    public class UserAnimalRepository : IUserAnimalRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserAnimalRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<UserAnimalModel> AssignAnimalToUserAsync(Guid userId, Guid animalId)
        {
            var userExists = await _realDatabase.Users.AnyAsync(u => u.Id == userId);
            var animalExists = await _realDatabase.UserAnimals.AnyAsync(a => a.AnimalId == animalId); // Assuming Animals is the correct table

            if (!userExists || !animalExists)
            {
                throw new InvalidOperationException("Användaren eller djuret finns inte.");
            }

            // Check if the relationship already exists
            var relationshipExists = await _realDatabase.UserAnimals.AnyAsync(ua => ua.UserId == userId && ua.AnimalId == animalId);
            if (relationshipExists)
            {
                // If the relationship already exists, you may want to handle this situation,
                // e.g., return the existing UserAnimalModel, or throw an exception.
            }

            // Create new relationship if it doesn't exist
            var userAnimal = new UserAnimalModel { UserId = userId, AnimalId = animalId };
            _realDatabase.UserAnimals.Add(userAnimal);
            await _realDatabase.SaveChangesAsync();

            return userAnimal;
        }


        public async Task<IEnumerable<User>> GetaAllUsersWithAnimalsAsync()
        {
            return await _realDatabase.Users
                .Include(u => u.UserAnimals)
                .ThenInclude(ua => ua.Animal)
                .ToListAsync();
        }

        public async Task UpdateAnimalOrUserAsync(Guid userId, Guid animalId)
        {
            // Antingen uppdatera användaren eller djuret baserat på id:n.
            // Exempel för att uppdatera ett djur:
            var animal = await _realDatabase.UserAnimals.FindAsync(animalId);
            if (animal != null)
            {
                // Ändra egenskaper på djuret
                _realDatabase.UserAnimals.Update(animal);
                await _realDatabase.SaveChangesAsync();
            }
            // Liknande logik kan tillämpas för att uppdatera en användare.
        }

        public async Task RemoveAnimalFromUserAsync(Guid userId, Guid animalId)
        {
            var userAnimal = await _realDatabase.UserAnimals
                .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AnimalId == animalId);
            if (userAnimal != null)
            {
                _realDatabase.UserAnimals.Remove(userAnimal);
                await _realDatabase.SaveChangesAsync();
            }
        }
    }

}
