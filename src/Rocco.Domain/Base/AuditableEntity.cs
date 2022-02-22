// <copyright file="AuditableEntity.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System;

namespace Rocco.Domain.Base;
public class AuditableEntity : IEntity
{
    public Guid Id { get; set; }
    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public bool IsDeleted { get; set; }
}
