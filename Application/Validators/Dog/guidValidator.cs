using System.Data;
using Domain.Models;
using FluentValidation;

public class GuidValidator : AbstractValidator<Guid>
{
    public GuidValidator()
    {
        RuleFor(guid => guid)
        .NotEmpty().WithMessage("Dog Id can not be empty")
        .NotNull().WithMessage("Dog Id can not be Null");

        

    }
  

}