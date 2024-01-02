using BCrypt.Net;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.UserRepo;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Application;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<AddUserCommandHandler> _logger;

    public AddUserCommandHandler(IUserRepository userRepository, ILogger<AddUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Attempting to add a new user with username: {Username}", request.NewUser.Username);

            User userToCreate = new()
            {
                Id = Guid.NewGuid(),
                Username = request.NewUser.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password),
            };

            await _userRepository.AddUserAsync(userToCreate);

            _logger.LogInformation("User successfully added with ID: {UserId}", userToCreate.Id);

            return userToCreate;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a new user with username: {Username}", request.NewUser.Username);
            throw;
        }
    }
}
