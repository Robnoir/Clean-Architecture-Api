using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;
using Infrastructure.Database.Repositories.UserRepo;
using Microsoft.Extensions.Logging;
using System;

namespace Application;

public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UpdateUserByIdCommandHandler> _logger;

    public UpdateUserByIdCommandHandler(IUserRepository userRepository, ILogger<UpdateUserByIdCommandHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<User> Handle(UpdateUserByIdCommand command, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Attempting to update user with ID: {UserId}", command.UserId);

            var user = await _userRepository.GetUserByIdAsync(command.UserId);
            if (user == null)
            {
                _logger.LogWarning("User not found with ID: {UserId}", command.UserId);
                throw new InvalidOperationException($"User with ID {command.UserId} was not found.");
            }

            // Update password if it's new
            if (!string.IsNullOrWhiteSpace(command.NewPassword))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.NewPassword);
            }

            // Update username if it's new
            if (!string.IsNullOrWhiteSpace(command.UpdateUserDto.Username))
            {
                user.Username = command.UpdateUserDto.Username;
            }

            await _userRepository.UpdateUserAsync(user);

            _logger.LogInformation("User successfully updated with ID: {UserId}", user.Id);
            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating user with ID: {UserId}", command.UserId);
            throw;
        }
    }
}
