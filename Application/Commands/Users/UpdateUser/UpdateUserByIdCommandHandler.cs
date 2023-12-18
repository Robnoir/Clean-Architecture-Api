using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;
using Infrastructure.Database.Repositories.UserRepo;



namespace Application;

public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserByIdCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
    {
        User userToUpdate = await _userRepository.GetUserByIdAsync(request.UserId);

        if (userToUpdate == null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        // Perform the mapping here
        if (!string.IsNullOrWhiteSpace(request.UpdateUserDto.Username))
        {
            userToUpdate.Username = request.UpdateUserDto.Username;
        }
        if (!string.IsNullOrWhiteSpace(request.UpdateUserDto.Email))
        {
            userToUpdate.Email = request.UpdateUserDto.Email;
        }
        if (!string.IsNullOrWhiteSpace(request.UpdateUserDto.Password))
        {
            userToUpdate.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.UpdateUserDto.Password);
        }
        userToUpdate.Username= request.UpdateUserDto.Username;
        userToUpdate.PasswordHash = request.UpdateUserDto.Password;
        userToUpdate.Email= request.UpdateUserDto.Email;
        await _userRepository.UpdateUserAsync(userToUpdate);
        return userToUpdate;
    }
}
