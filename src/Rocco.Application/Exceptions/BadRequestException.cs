// <copyright file="BadRequestException.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System;

namespace Rocco.Application.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message)
    {

    }
}
