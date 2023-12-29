﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.CatRepo
{
    public interface ICatRepository
    {
        Task<Cat> GetByIdAsync(Guid catId);
        Task<Cat> AddAsync(Cat catToCreate);
        Task UpdateAsync(Cat cat);
        Task DeleteAsync(Guid catId);
        Task<List<Cat>> GetAllCatsAsync();
    }
}