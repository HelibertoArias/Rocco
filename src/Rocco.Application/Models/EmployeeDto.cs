// <copyright file="EmployeeDto.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System;

namespace Rocco.Application.Models;
public class EmployeeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Position { get; set; } = null!;
}
