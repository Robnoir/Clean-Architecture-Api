using Domain.Models;
using Domain.Models.Animal;
using Infrastructure.Database.Repositories.BirdRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Birds.GetByAttribute
{
    public class GetBirdByAttributeQueryHandler : IRequestHandler<GetBirdByAttributeQuery, List<Bird>>
    {

        private readonly IBirdRepository _birdRepository;

        public GetBirdByAttributeQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<List<Bird>> Handle(GetBirdByAttributeQuery request, CancellationToken cancellationToken)
        {
            return await _birdRepository.GetBirdByColorAsync(request.Color);
        }
    }
}
