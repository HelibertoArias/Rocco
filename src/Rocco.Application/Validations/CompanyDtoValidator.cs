// <copyright file="CompanyDtoValidator.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using FluentValidation;
using Rocco.Application.Models;

namespace Rocco.Application.Validations;
public class AddCompanyDtoValidator : AbstractValidator<CompanyDtoForInsert>
{
    // TODO: To implement validation with Fluent Validations
    public AddCompanyDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(1).WithMessage("{PropertyName} must have at least one character.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(x => x.Country).NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(1).WithMessage("{PropertyName} must have at least one character.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(x => x.Address).NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(1).WithMessage("{PropertyName} must have at least one character.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 200 characters.");
    }
}
