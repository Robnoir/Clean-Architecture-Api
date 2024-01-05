using Domain.Models;
using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Birds.GetByAttribute
{
    public class GetBirdByAttributeQuery : IRequest<List<Bird>>
    {
        public string Color { get;}
        public GetBirdByAttributeQuery(string color)
        {
            Color = color;
        }
       
    }
}
