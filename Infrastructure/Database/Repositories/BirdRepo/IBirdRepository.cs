using Domain.Models;
using Domain.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.BirdRepo
{
    public interface IBirdRepository
    {
        Task<Bird> GetByIdAsync(Guid birdId);
        Task<Bird> AddAsync(Bird birdToCreate);
        Task UpdateAsync(Bird bird);
        Task DeleteAsync(Guid birdId);
        Task<List<Bird>> GetBirdByColorAsync(string BirdColor);
        Task<List<Bird>> GetAllBirdsAsync();
    }
}
