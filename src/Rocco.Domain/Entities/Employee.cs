// <copyright file="Employee.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System;
using Rocco.Domain.Base;

namespace Rocco.Domain.Entities;
public class Employee : AuditableEntity, IEntity
{
    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Position { get; set; } = null!;

    public Guid CompanyId { get; set; }

    public Company Company { get; set; } = null!;
}

