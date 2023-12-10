using Domain.Models;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly MockDatabase _mockDatabase;

        public UserRepository(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            // Simulate database access by searching the in-memory list
            var user = _mockDatabase.Users
                .FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(user);
        }


    }
}
