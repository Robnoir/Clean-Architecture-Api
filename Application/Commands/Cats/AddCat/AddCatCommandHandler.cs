using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Cats.AddCat
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly RealDatabase _realDatabase;

        public AddCatCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;

        }

        public Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            Cat CatToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewCat.Name
            };
            _realDatabase.Cats.Add(CatToCreate);
            return Task.FromResult(CatToCreate);
        }

    }
}
