using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly RealDatabase _realDatabase;

        public AddDogCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            Dog dogToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewDog.Name
            };

            _realDatabase.Dogs.Add(dogToCreate);

            return Task.FromResult(dogToCreate);
        }
    }
}
