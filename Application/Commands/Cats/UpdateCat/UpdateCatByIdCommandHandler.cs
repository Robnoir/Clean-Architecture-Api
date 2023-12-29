using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.CatRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public UpdateCatByIdCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public  async Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = await _catRepository.GetByIdAsync(request.Id);

            if (catToUpdate == null)
            {
                return null!;
            }

            catToUpdate.Name = request.UpdateCat.Name;
            catToUpdate.LikesToPlay = request.UpdateCat.LikesToPlay;
            await _catRepository.UpdateAsync(catToUpdate);
            return catToUpdate;
        }
    }
}
