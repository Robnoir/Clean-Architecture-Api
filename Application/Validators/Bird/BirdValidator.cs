using Application.Dtos;
using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Bird
{
    public class BirdValidator : AbstractValidator<BirdDto>
    {

        public BirdValidator() 
        {
            RuleFor(bird => bird.Name)
                .NotEmpty().WithMessage("Bird name can not be empty")
                .NotNull().WithMessage("Bird name can not be null");
            RuleFor(color => color.BirdColor)
                .NotEmpty().WithMessage("The bird has to have a color")
                .NotNull().WithMessage("The color can not be null");



        }
        


    }
}
