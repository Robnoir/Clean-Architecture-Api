using Domain.Models;
using Infrastructure;
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
        private readonly IDogRepository _dogRepository;

        public DeleteDogByIdCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }


        public async Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogTodelete = await _dogRepository.GetByIdAsync(request.Id);
            if (dogTodelete == null)
            {
                throw new InvalidOperationException("No dog with the given Id was found");
            }

            await _dogRepository.DeleteAsync(request.Id);

            return (dogTodelete);

        }

    }
}
