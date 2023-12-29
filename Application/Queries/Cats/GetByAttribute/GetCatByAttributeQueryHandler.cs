using Domain.Models;
using Infrastructure.Database.Repositories.CatRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetByAttribute
{
    public class GetCatByAttributeQueryHandler : IRequestHandler<GetCatByAttributeQuery, List<Cat>>
    {
        private readonly ICatRepository _catRepository;

        public GetCatByAttributeQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;

        }


        public async Task<List<Cat>> Handle(GetCatByAttributeQuery request, CancellationToken cancellationToken)
        {
            return await _catRepository.GetCatByBreedAndWeight(request.Breed, request.Weight);
        }
    }
}
