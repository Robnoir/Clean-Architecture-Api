using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Dogs.GetDogByAttribute
{
    public class GetDogByAttributeQuery : IRequest<IEnumerable<Dog>>
    {
        public string Breed { get; set; }
        public int? Weight { get; set; }

        public GetDogByAttributeQuery(string breed, int? weight)
        {
            Breed = breed;
            Weight = weight;
        }
    }
}
