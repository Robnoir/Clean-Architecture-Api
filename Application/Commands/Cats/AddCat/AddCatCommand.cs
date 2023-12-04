using Application.Dtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Cats.AddCat

{ 
        public class AddCatCommand : IRequest<Cat>
        {
            public AddCatCommand(CatDto newCat)
            {
                NewCat = newCat;
            }

            public CatDto NewCat { get; }
        }

    
}
