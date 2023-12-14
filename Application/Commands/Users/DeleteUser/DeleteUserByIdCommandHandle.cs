using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application;

public class DeleteUserByIdCommandHandle : IRequestHandler<DeleteUserByIdCommand, User>
{
    private readonly MockDatabase _mockDatabase;

    public DeleteUserByIdCommandHandle(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;

    }

    public Task<User> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        var userToDelete = _mockDatabase.Users.FirstOrDefault(user => user.Id == request.Id);

        if (userToDelete != null)
        {
            _mockDatabase.Users.Remove(userToDelete);
        }
        else
        {
            throw new InvalidOperationException("No user with given Id was found");
        }

        return Task.FromResult(userToDelete);
    }




}
