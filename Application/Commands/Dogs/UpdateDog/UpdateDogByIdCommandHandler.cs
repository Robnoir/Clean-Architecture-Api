using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly RealDatabase _realDatabase;

        public UpdateDogByIdCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }
        public Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToUpdate = _realDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id)!;

            dogToUpdate.Name = request.UpdatedDog.Name;

            return Task.FromResult(dogToUpdate);
        }
    }
}
