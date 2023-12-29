using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.BirdRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
       private readonly IBirdRepository _birdRepository;

        public AddBirdCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            // Create a new Bird object with the provided details including color
            Bird birdToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewBird.Name,
                CanFly = request.NewBird.CanFly, // Assuming CanFly is part of the BirdDto
                BirdColor = request.NewBird.BirdColor // Make sure BirdColor is part of the BirdDto
            };

            // Pass the birdToCreate object to the repository to add it to the database
            await _birdRepository.AddAsync(birdToCreate);

            // Return the created bird
            return birdToCreate;
        }
    }
}
