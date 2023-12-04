using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }


        public Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            var dogToDelete = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id);

            if (dogToDelete != null)
            {
                _mockDatabase.Dogs.Remove(dogToDelete);
            }
            else
            {
                // Throw an exception or handle the null case as needed for your application
                throw new InvalidOperationException("No dog with the given ID was found.");
            }

            return Task.FromResult(dogToDelete);
        }

    }
}
