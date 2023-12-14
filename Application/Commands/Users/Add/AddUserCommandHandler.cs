using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
{
    private readonly MockDatabase _mockdatabase;
 public AddUserCommandHandler(MockDatabase mockDatabase)
 {
    _mockdatabase = mockDatabase;
 }
    public Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        User userToCreate = new()
        {
            Id = Guid.NewGuid(),
            Username = request.NewUser.Username
        };

        _mockdatabase.Users.Add(userToCreate);

        return Task.FromResult(userToCreate);
    }

   



}
