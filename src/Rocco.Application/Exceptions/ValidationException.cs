// <copyright file="ValidationException.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Rocco.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> ValdationErrors { get; set; }

    public ValidationException(ValidationResult validationResult)
    {
        ValdationErrors = new List<string>();

        foreach (var validationError in validationResult.Errors)
        {
            ValdationErrors.Add(validationError.ErrorMessage);
        }
    }
}
