using Domain.Models;
using Infrastructure.Database;
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

        private readonly RealDatabase _realDatabase;
        public DeleteBirdByIdCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            var birdToDelete = _realDatabase.Birds.FirstOrDefault(bird => bird.Id == request.Id);

            if (birdToDelete != null)
            {
                _realDatabase.Birds.Remove(birdToDelete);
            }
            else
            {
                // Throw an exception or handle the null case as needed for your application
                throw new InvalidOperationException("No bird with the given ID was found.");
            }


            return Task.FromResult(birdToDelete);
        }



    }
}
