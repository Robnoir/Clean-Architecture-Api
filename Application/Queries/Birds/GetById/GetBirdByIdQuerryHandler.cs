using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.BirdRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Birds.GetById
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {

        private readonly IBirdRepository _birdRepository;
        public GetBirdByIdQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }


        public async Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = await _birdRepository.GetByIdAsync(request.Id);

            try
            {
                if(wantedBird == null)
                {
                    return null!;
                }
                return wantedBird;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
       

    }
}
