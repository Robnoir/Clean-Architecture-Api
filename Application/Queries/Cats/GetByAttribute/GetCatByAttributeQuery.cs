using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cats.GetByAttribute
{
    public class GetCatByAttributeQuery : IRequest<IEnumerable<Cat>>
    {
        public string Breed { get; set; }
        public int? Weight { get; set; }

        public GetCatByAttributeQuery(string breed, int? weight)
        {
            Breed = breed;
            Weight = weight;



        }


    }
}
