using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;
using Infrastructure.Database.Repositories.UserRepo;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;



namespace Application;

public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserByIdCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UpdateUserByIdCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(command.UserId);
        if (user == null)
        {
            throw new InvalidOperationException($"Användare med ID {command.UserId} hittades inte.");
        }

        // Uppdatera lösenordet om det är nytt
        if (!string.IsNullOrWhiteSpace(command.NewPassword))
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.NewPassword);
        }

        // Uppdatera userName om det är nytt
        if (!string.IsNullOrWhiteSpace(command.UpdateUserDto.Username))
        {
            user.Username = command.UpdateUserDto.Username;
        }

        await _userRepository.UpdateUserAsync(user);
        return user;
    }
}
