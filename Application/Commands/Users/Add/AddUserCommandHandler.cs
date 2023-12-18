using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
{

    private readonly RealDatabase _realdatabase;
    public AddUserCommandHandler(RealDatabase realDatabase)
    {
        _realdatabase = realDatabase;
    }
    public Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        User userToCreate = new()
        {
            Id = Guid.NewGuid(),
            Username = request.NewUser.Username
        };

        _realdatabase.Users.Add(userToCreate);

        return Task.FromResult(userToCreate);
    }





}
