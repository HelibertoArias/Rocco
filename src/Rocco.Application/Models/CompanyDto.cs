// <copyright file="CompanyDto.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System;

namespace Rocco.Application.Models;
public class CompanyDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string FullAddress { get; set; } = null!;
}
