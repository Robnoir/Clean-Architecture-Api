using Application.Dtos;
using Application.Validators.Bird;
using Application.Validators.Cat;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.UserAnimal
{
    public class UserAnimalValidator : AbstractValidator<UserAnimalDto>
    {

        public UserAnimalValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID cannot be empty.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 20).WithMessage("Username must be between 3 and 20 characters long.");

            RuleForEach(userAnimal => userAnimal.Dogs)
                .SetValidator(new DogValidator());

            RuleForEach(userAnimal => userAnimal.Cats)
                .SetValidator(new CatValidator());


            RuleForEach(userAnimal => userAnimal.Birds)
                .SetValidator(new BirdValidator());
        }

    }


}
