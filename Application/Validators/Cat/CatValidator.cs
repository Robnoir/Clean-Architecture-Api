using Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Cat
{
    public class CatValidator : AbstractValidator<CatDto>
    {
        public CatValidator() 
        { 
            RuleFor(cat  => cat.Name)
                .NotEmpty().WithMessage("Cat Name cant be empty")
                .NotNull().WithMessage("Cat name can not be null");
            RuleFor(cat => cat.Breed)
                .NotEmpty().WithMessage("Cat Breed can not be empty")
                .NotNull().WithMessage("Cat Breed can not be null ");
            RuleFor(cat => cat.Weight)
                .NotEmpty().WithMessage("Cat Weight can not be empty")
                .NotNull().WithMessage("Cat Weight can not be null ");
        }

    }
}
