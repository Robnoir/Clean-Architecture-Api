using Domain.Models;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Dogs.GetDogByAttribute
{
    public class GetDogByAttributeQueryHandler : IRequestHandler<GetDogByAttributeQuery, IEnumerable<Dog>>
    {
        private readonly IDogRepository _dogRepository;

        public GetDogByAttributeQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<IEnumerable<Dog>> Handle(GetDogByAttributeQuery request, CancellationToken cancellationToken)
        {
            return await _dogRepository.GetDogByBreedAndWeight(request.Breed, request.Weight);
        }
    }
}
