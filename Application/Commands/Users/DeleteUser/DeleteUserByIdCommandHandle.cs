using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application;

public class DeleteUserByIdCommandHandle : IRequestHandler<DeleteUserByIdCommand, User>
{
    private readonly RealDatabase _realDatabase;

    public DeleteUserByIdCommandHandle(RealDatabase realDatabase)
    {
        _realDatabase = realDatabase;

    }

    public Task<User> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        var userToDelete = _realDatabase.Users.FirstOrDefault(user => user.Id == request.Id);

        if (userToDelete != null)
        {
            _realDatabase.Users.Remove(userToDelete);
        }
        else
        {
            throw new InvalidOperationException("No user with given Id was found");
        }

        return Task.FromResult(userToDelete);
    }




}
