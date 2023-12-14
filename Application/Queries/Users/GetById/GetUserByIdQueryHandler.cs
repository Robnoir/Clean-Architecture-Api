using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly MockDatabase _mockDatabase;

    public GetUserByIdQueryHandler(MockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }


    public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User wantedUser = _mockDatabase.Users.FirstOrDefault(user =>user.Id == request.Id)!;
        return Task.FromResult(wantedUser);
    }

}
