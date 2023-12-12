using System.ComponentModel.DataAnnotations;
using System.Data;
using Application.Dtos;
using Application.Queries.Dogs.GetAll;
using Domain.Models;
using FluentValidation;

public class DogValidator : AbstractValidator<DogDto>
{
    public DogValidator()
    {
        RuleFor(dog => dog.Name)
        .NotEmpty().WithMessage("Dog Name can not be empty")
        .NotNull().WithMessage("Dog name can not be Null");

    }


}