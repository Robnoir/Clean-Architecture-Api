using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Dogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly IDogRepository _dogRepository;

        public GetAllDogsQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromDatabase = await _dogRepository.GetAllDogsAsync();
            if (allDogsFromDatabase == null)
            {
                throw new InvalidOperationException("No Dogs Was Found");
            }

            return allDogsFromDatabase;
        }
    }
}
