using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;



namespace Application;

public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User>
{
    private readonly RealDatabase _realDatabase;

    public UpdateUserByIdCommandHandler(RealDatabase realDatabase)
    {
        _realDatabase = realDatabase;
    }

    public Task<User> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = _realDatabase.Users.FirstOrDefault(user => user.Id == request.UserId);
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



        return Task.FromResult(userToUpdate);
    }
}
