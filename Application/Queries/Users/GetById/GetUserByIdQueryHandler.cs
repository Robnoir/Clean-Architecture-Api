using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.UserRepo;
using MediatR;

namespace Application;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User wantedUser = await _userRepository.GetUserByIdAsync(request.Id);
        try
        {
            if (wantedUser == null)
            {
                return null!;

            }
            return wantedUser;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

}
