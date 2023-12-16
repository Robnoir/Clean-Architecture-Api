using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application;

public class UpdateUserByIdCommand : IRequest<User>
{
    public UserDto UpdateUserDto { get; }
    public Guid UserId { get; }

    public UpdateUserByIdCommand(UserDto updateUserDto, Guid userId)
    {
        UpdateUserDto = updateUserDto;
        UserId = userId;
    }
}
