// <copyright file="NotFoundException.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System;

namespace Rocco.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key)
        : base($"{name} ({key}) is not found")
    {
    }
}
