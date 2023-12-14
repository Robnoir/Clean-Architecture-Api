using Domain.Models;
using MediatR;

namespace Application;

public class GetAllUsersQuery : IRequest<List<User>>
{
}
