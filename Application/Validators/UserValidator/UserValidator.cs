using System.Data;
using Domain.Models;
using FluentValidation;
using FluentValidation.Validators;

namespace Application;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Id)
            .NotEmpty().WithMessage("User Id cannot be empty");
            
            

        RuleFor(user => user.Username)
            .NotEmpty().WithMessage("Username cannot be empty")
            .MaximumLength(10).WithMessage("Username cant be longer than 10 letters")
            .MinimumLength(5).WithMessage("Username minimum lenth 5 letters")
            .Matches("^[a-zA-Z0-9_-]+$").WithMessage("Username can only contain letters, numbers, underscores, and hyphens.");

       RuleFor(user => user.Email)
          .NotEmpty().WithMessage("Email can not be empty")
          .MaximumLength(20).WithMessage("Email can not be more than 20 letters long")
          .MinimumLength(5).WithMessage("Email Minimum length is 5 letters");
          

        RuleFor(user => user.PasswordHash)
            .NotEmpty().WithMessage("Password can not be empty")
            .MinimumLength(5).WithMessage("Minimum password length is 5 letters long")
            .MaximumLength(15).WithMessage("Maximum password length is 15 letters")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[^a-zA-Z0-9]]").WithMessage("Password must contain atleast one special character")
            .NotEqual("password", StringComparer.OrdinalIgnoreCase)
            .WithMessage("password cannot be password.");
    }
}

