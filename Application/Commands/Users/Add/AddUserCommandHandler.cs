using BCrypt.Net;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.UserRepo;
using MediatR;

namespace Application;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
{

    private readonly IUserRepository _userRepository;

    public AddUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        User userToCreate = new()
        {
            Id = Guid.NewGuid(),
            Username = request.NewUser.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password),

        };

        await _userRepository.AddUserAsync(userToCreate);

        return userToCreate;




    }
}
