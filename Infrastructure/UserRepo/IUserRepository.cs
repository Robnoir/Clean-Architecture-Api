﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UserRepo
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);

    }
}
