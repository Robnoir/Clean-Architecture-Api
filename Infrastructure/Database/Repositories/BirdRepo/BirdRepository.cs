using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.BirdRepo
{
    public class BirdRepository : IBirdRepository
    {

        private readonly RealDatabase _realDatabase;

        public BirdRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<Bird> AddAsync(Bird birdToCreate)
        {
            _realDatabase.Birds.Add(birdToCreate);
            await _realDatabase.SaveChangesAsync();

            return birdToCreate;
        }

        public async Task DeleteAsync(Guid birdId)
        {
            var DeleteBirdId = await _realDatabase.Birds.FindAsync(birdId);
            if (DeleteBirdId != null)
            {
                _realDatabase.Birds.Remove(DeleteBirdId);
                await _realDatabase.SaveChangesAsync();

            }
        }

        public async Task<List<Bird>> GetAllBirdsAsync()
        {
            return await _realDatabase.Birds.ToListAsync();
        }

        public async Task<Bird> GetBirdByColorAsync(string birdColor)
        {
            var bird = await _realDatabase.Birds.FirstOrDefaultAsync(b => b.BirdColor == birdColor);

            return bird;
        }

        public async Task<Bird> GetByIdAsync(Guid birdId)
        {
            return await _realDatabase.Birds.FindAsync(birdId);
        }

        public async Task UpdateAsync(Bird bird)
        {
            _realDatabase.Birds.Update(bird);
            await _realDatabase.SaveChangesAsync();
        }
    }
}
