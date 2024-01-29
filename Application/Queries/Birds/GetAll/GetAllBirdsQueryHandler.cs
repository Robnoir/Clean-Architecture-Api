using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.BirdRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;


namespace Application.Queries.Birds.GetAll
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly IBirdRepository _birdRepository;

        public GetAllBirdsQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirdsFromDatabase = await _birdRepository.GetAllBirdsAsync();
            if (allBirdsFromDatabase == null)
            {
                throw new InvalidOperationException("No Birds Was Found");
            }
            return allBirdsFromDatabase;

        }
    }

}
