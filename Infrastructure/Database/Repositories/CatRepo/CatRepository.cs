using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.CatRepo
{
    public class CatRepository : ICatRepository
    {
        private readonly RealDatabase _realDatabase;

        public CatRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<Cat> AddAsync(Cat catToCreate)
        {
            _realDatabase.Cats.Add(catToCreate);
            _realDatabase.SaveChanges();
            return await Task.FromResult(catToCreate);

        }

        public async Task DeleteAsync(Guid catId)
        {
            var DeleteCatId = await _realDatabase.Cats.FindAsync(catId);

            if (DeleteCatId != null)
            {
                _realDatabase.Cats.Remove(DeleteCatId);
                await _realDatabase.SaveChangesAsync();

            }
        }

        public async Task<List<Cat>> GetAllCatsAsync()
        {
            return await _realDatabase.Cats.ToListAsync();

        }

        public async Task<Cat> GetByIdAsync(Guid catId)
        {
            return await _realDatabase.Cats.FindAsync(catId);
        }

        public async Task<List<Cat>> GetCatByBreedAndWeight(string breed, int? weight)
        {
            var query = _realDatabase.Cats.AsQueryable();

            if (!string.IsNullOrEmpty(breed))
            {
                query = query.Where(c => c.Breed == breed);
            }

            if (weight.HasValue)
            {
                query = query.Where(c => c.Weight == weight);
            }

            return await query.ToListAsync();
        }


        public async Task UpdateAsync(Cat cat)
        {
            _realDatabase.Cats.Update(cat);
            await _realDatabase.SaveChangesAsync();
        }
    }
}
