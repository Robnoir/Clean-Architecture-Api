using Domain.Models;
using MediatR;

namespace Application;

public class GetUserByIdQuery : IRequest<User>
{
    public GetUserByIdQuery(Guid userId)
    {
        Id = userId;
    }

    public Guid Id { get; }

}
