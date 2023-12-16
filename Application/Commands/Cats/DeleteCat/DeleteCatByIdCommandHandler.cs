using Domain.Models;
using Infrastructure.Database;
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
        private readonly RealDatabase _realDatabase;
        public DeleteCatByIdCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            var catToDelete = _realDatabase.Cats.FirstOrDefault(cat => cat.Id == request.Id);

            if (catToDelete != null)
            {
                _realDatabase.Cats.Remove(catToDelete);
            }
            else
            {
                // Throw an exception or handle the null case as needed for your application
                throw new InvalidOperationException("No cat with the given ID was found.");
            }

            return Task.FromResult(catToDelete);
        }

    }
}
