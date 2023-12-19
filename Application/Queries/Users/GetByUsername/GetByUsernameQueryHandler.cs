using Domain.Models;
using Infrastructure.Database.Repositories.UserRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetByUsername
{
    public class GetByUsernameQueryHandler : IRequestHandler<GetByUsernameQuery, User>
    {
        private readonly IUserRepository _userRepository;
        public GetByUsernameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(GetByUsernameQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Username))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(request.Username));
            }

            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user == null)
            {
                // Hantera fallet där användaren inte hittas. Du kan kasta ett undantag eller returnera null.
                // Detta beror på hur du vill att din applikation ska hantera sådana situationer.
                throw new KeyNotFoundException($"Användare med användarnamnet '{request.Username}' hittades inte.");
            }

            return user;
        }


    }
}

