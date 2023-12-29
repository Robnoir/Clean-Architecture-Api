using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.BirdRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {

        private readonly IBirdRepository _birdRepository;
        public DeleteBirdByIdCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = await _birdRepository.GetByIdAsync(request.Id);
            if (birdToDelete == null)
            {
                throw new InvalidOperationException("No Bird with the given id was found");

            }
            await _birdRepository.DeleteAsync(request.Id);

            return birdToDelete;

        }




    }
}
