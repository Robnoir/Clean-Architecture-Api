using Domain.Models;
using FluentValidation;

namespace Application;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user)
        .NotEmpty().WithMessage("User Id can not be empty")
        .NotEmpty().WithMessage("Dog Id can not be Null");
        
    }


}
