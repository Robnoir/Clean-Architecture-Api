using Domain.Models;
using Infrastructure.Database;
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
        private readonly RealDatabase _realDatabase;

        public AddBirdCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewBird.Name

            };

            _realDatabase.Birds.Add(birdToCreate);

            return Task.FromResult(birdToCreate);
        }
    }
}
