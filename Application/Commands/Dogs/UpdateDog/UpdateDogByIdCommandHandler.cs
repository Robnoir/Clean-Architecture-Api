using Domain.Models;
using Infrastructure;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;

        public UpdateDogByIdCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToUpdate = await _dogRepository.GetByIdAsync(request.Id);

            if (dogToUpdate == null)
            {
                return null!;
            }

            dogToUpdate.Name = request.UpdatedDog.Name;
            await _dogRepository.UpdateAsync(dogToUpdate);
            return dogToUpdate;
        }
    }
}
