using System.ComponentModel;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.UserRepo;
using MediatR;

namespace Application;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
{
    private readonly IUserRepository _userRepository;
    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        List<User> allUsersFromDatabase = await _userRepository.GetAllUsersAsync();
        if (allUsersFromDatabase == null)
        {
            throw new InvalidOperationException("No User was found, user must be 404 MIA");
        }
        return allUsersFromDatabase;


    }



}
