using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Dogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly AppDbContext _appDbContext;

        public GetAllDogsQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            //List<Dog> allDogsFromMockDatabase = _appDbContext.Dogs;
            // return Task.FromResult(allDogsFromMockDatabase);

            var dogs = await _appDbContext.Dogs.Select(d => new Dog { Id = d.Id, Name = d.Name }).ToListAsync();
            return dogs;
        }
    }
}
