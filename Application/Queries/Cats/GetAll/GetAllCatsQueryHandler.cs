using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.CatRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetAll
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private ICatRepository _catRepository;

        public GetAllCatsQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }
        public async Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsFromDatabase = await _catRepository.GetAllCatsAsync();
            if (allCatsFromDatabase == null)
            {
                throw new InvalidOperationException("No Cats Was Found");
            }

            return allCatsFromDatabase;

        }
    }
}
