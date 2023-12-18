﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<User> AddUserAsync(User UserToCreate)
        {
            _realDatabase.Users.Add(UserToCreate);
            _realDatabase.SaveChanges();
            return await Task.FromResult(UserToCreate);

        }

        public async Task DeleteUserAsync(Guid id)
        {
            var DeleteUserId = await _realDatabase.Users.FindAsync(id);
            if (DeleteUserId != null)
            {
                _realDatabase.Users.Remove(DeleteUserId);
                await _realDatabase.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _realDatabase.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _realDatabase.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            _realDatabase.Users.Update(user);
            await _realDatabase.SaveChangesAsync();
        }
    }
}
