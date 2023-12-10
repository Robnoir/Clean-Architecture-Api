using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Services
{
    public interface IAuthenticationService
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
