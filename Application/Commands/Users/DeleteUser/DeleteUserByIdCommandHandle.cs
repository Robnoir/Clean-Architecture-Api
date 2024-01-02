using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.UserRepo;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Application;

public class DeleteUserByIdCommandHandle : IRequestHandler<DeleteUserByIdCommand, User>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<DeleteUserByIdCommandHandle> _logger;

    public DeleteUserByIdCommandHandle(IUserRepository userRepository, ILogger<DeleteUserByIdCommandHandle> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<User> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Attempting to delete user with ID: {UserId}", request.Id);

            User userToDelete = await _userRepository.GetUserByIdAsync(request.Id);

            if (userToDelete == null)
            {
                _logger.LogWarning("No user found with ID: {UserId}", request.Id);
                throw new InvalidOperationException("No user with the given id was found");
            }

            await _userRepository.DeleteUserAsync(request.Id);

            _logger.LogInformation("User successfully deleted with ID: {UserId}", userToDelete.Id);

            return userToDelete;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting user with ID: {UserId}", request.Id);
            throw;
        }
    }
}

