using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.CatRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public DeleteCatByIdCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catTodelete = await _catRepository.GetByIdAsync(request.Id);

            if (catTodelete != null)
            {
                throw new InvalidOperationException("No cat with the given id was found");

            }

            await _catRepository.DeleteAsync(request.Id);

            return (catTodelete);
          
        }

    }
}
