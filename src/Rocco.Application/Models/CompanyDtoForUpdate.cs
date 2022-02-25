// <copyright file="CompanyDtoForUpdate.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

namespace Rocco.Application.Models;

public class CompanyDtoForUpdate
{
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Country { get; set; } = null!;

}
