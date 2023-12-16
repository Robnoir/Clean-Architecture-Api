using Domain.Models;
using Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Queries.Birds.GetAll
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly RealDatabase _realDatabase;

        public GetAllBirdsQueryHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            // List<Bird> allBirdsFromMockDatabase = _realDatabase.Birds;
            // return Task.FromResult(allBirdsFromMockDatabase);
            var birds = await _realDatabase.Birds.Select(d => new Bird { Id = d.Id, Name = d.Name }).ToListAsync();
            return birds;
        }
    }

}
