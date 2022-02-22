// <copyright file="Company.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System.Collections.Generic;
using Rocco.Domain.Base;

namespace Rocco.Domain.Entities;

public class Company : AuditableEntity//, IEntity
{

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Country { get; set; } = null!;

    public ICollection<Employee> Employees { get; set; } = null!;
}
