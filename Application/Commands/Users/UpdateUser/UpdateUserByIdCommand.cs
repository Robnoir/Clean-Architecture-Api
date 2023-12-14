using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application;

public class UpdateUserByIdCommand : IRequest<User>
{
    public UpdateUserByIdCommand(UserDto updateUser, Guid id)
    {
        UpdateUser = updateUser;
        Id = id;

    }

    public UserDto UpdateUser {get;}
    public Guid Id {get;}
    

}
