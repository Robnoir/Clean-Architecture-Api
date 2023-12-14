using System.Diagnostics;
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application;

public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User>
{
    private readonly MockDatabase _mockdatabase;

    public UpdateUserByIdCommandHandler ( MockDatabase mockDatabase)
    {
        _mockdatabase = mockDatabase;
    }

    public Task<User> Handle (UpdateUserByIdCommand request, CancellationToken cancellationToken)
    {
        User userToUpdate = _mockdatabase.Users.FirstOrDefault(user => user.Id == request.Id )!;

        userToUpdate.Username = request.UpdateUser.Username;
        userToUpdate.PasswordHash = request.UpdateUser.Password;
        //userToUpdate.Email = request.UpdateUser.Email;

        return Task.FromResult(userToUpdate);

    }




}
