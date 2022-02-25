// <copyright file="EmployeeRepository.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Rocco.Application.Contracts.Persistence;
using Rocco.Domain.Entities;
using Rocco.Persistence.Repositories.Common;

namespace Rocco.Persistence.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RoccoContext repositoryContext) : base(repositoryContext)
    {
    }
}
