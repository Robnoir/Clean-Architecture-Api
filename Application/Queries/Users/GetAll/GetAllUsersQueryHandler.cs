using System.ComponentModel;
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
{
private readonly MockDatabase _mockdatabase;
public GetAllUsersQueryHandler(MockDatabase mockDatabase)
{
    _mockdatabase = mockDatabase;
}

public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
{
    List<User> allUsersFromMockdatabase = _mockdatabase.Users;
    return Task.FromResult(allUsersFromMockdatabase);
    
}



}
