using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Birds.GetById
{
    public class GetBirdByIdQuerryHandler
    {
        public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
        {
            private readonly MockDatabase _mockDatabase;

            public GetBirdByIdQueryHandler(MockDatabase mockDatabase)
            {
                _mockDatabase = mockDatabase;
            }

            public Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
            {
                Bird wantedBird = _mockDatabase.Birds.FirstOrDefault(bird => bird.Id == request.Id)!;
                return Task.FromResult(wantedBird);
            }
        }

    }
}
