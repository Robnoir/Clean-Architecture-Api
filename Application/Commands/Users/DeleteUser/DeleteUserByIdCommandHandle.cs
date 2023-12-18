using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.UserRepo;
using MediatR;

namespace Application;

public class DeleteUserByIdCommandHandle : IRequestHandler<DeleteUserByIdCommand, User>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserByIdCommandHandle(IUserRepository userRepository)
    {
        _userRepository = userRepository;

    }

    public async Task<User> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        User userToDelete = await _userRepository.GetUserByIdAsync(request.Id);

        if (userToDelete == null)
        {
            throw new InvalidOperationException("No user with the given id was found");

        }

        await _userRepository.DeleteUserAsync(request.Id);

        return (userToDelete);



    }
}
