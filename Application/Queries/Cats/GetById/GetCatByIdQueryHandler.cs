using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.Repositories.CatRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly ICatRepository _catRepository;

        public GetCatByIdQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = await _catRepository.GetByIdAsync(request.Id);

            try
            {
                if (wantedCat == null)
                {
                    return null!;
                }
                return wantedCat;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
