// <copyright file="IEntity.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System;

namespace Rocco.Domain.Base;
public interface IEntity
{
    Guid Id { get; set; }
}
