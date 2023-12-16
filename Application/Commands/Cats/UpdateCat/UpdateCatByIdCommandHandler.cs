using Domain.Models;
using Infrastructure.Database;
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
        private readonly RealDatabase _realDatabase;

        public UpdateCatByIdCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = _realDatabase.Cats.FirstOrDefault(Cat => Cat.Id == request.Id)!;

            catToUpdate.Name = request.UpdateCat.Name;
            catToUpdate.LikesToPlay = request.UpdateCat.LikesToPlay;

            return Task.FromResult(catToUpdate);
        }
    }
}
