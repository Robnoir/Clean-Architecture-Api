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

        public async Task<IEnumerable<User>> GetAllUsersWithAnimalsAsync()
        {
            return await _realDatabase.Users
               .Include(u => u.UserAnimals)
               .ThenInclude(ua => ua.Animal)
               .ToListAsync();
        }


        public async Task<UserAnimalModel> AssignAnimalToUserAsync(Guid userId, Guid animalId)
        {
            // Check if the user exists
            var userExists = await _realDatabase.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
            {
                throw new InvalidOperationException("User does not exist.");
            }

            // Check if the animal exists
            var animalExists = await _realDatabase.UserAnimals.AnyAsync(a => a.AnimalId == animalId); // Adjusted for Animals DbSet
            if (!animalExists)
            {
                throw new InvalidOperationException("Animal does not exist.");
            }

            // Check if the relationship already exists
            var existingUserAnimal = await _realDatabase.UserAnimals
                .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AnimalId == animalId);

            if (existingUserAnimal != null)
            {
                // Map to UserAnimalModel if needed
                return new UserAnimalModel
                {
                    // Assuming UserAnimalModel has UserId and AnimalId properties
                    UserId = existingUserAnimal.UserId,
                    AnimalId = existingUserAnimal.AnimalId
                    // Map other properties if they exist
                };
            }

            // If the relationship doesn't exist, create a new UserAnimal entity
            var newUserAnimal = new UserAnimalModel { UserId = userId, AnimalId = animalId };
            _realDatabase.UserAnimals.Add(newUserAnimal);
            await _realDatabase.SaveChangesAsync();

            // Map the new UserAnimal entity to UserAnimalModel
            return new UserAnimalModel
            {
                UserId = newUserAnimal.UserId,
                AnimalId = newUserAnimal.AnimalId
                // Map other properties if they exist
            };
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
