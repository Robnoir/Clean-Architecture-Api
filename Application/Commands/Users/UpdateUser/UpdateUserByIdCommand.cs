using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application;

public class UpdateUserByIdCommand : IRequest<User>
{
    public UserDto UpdateUserDto { get; }
    public Guid UserId { get; }
    public string NewPassword { get; set; }

    public UpdateUserByIdCommand(UserDto updateUserDto, Guid userId, string newPassword)
    {
        UpdateUserDto = updateUserDto;
        UserId = userId;
        NewPassword = newPassword;
       
    }
}
