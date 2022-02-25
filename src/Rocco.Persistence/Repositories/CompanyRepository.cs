// <copyright file="CompanyRepository.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Rocco.Application.Contracts.Persistence;
using Rocco.Domain.Entities;
using Rocco.Persistence.Repositories.Common;

namespace Rocco.Persistence.Repositories;
public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(RoccoContext repositoryContext) : base(repositoryContext)
    {
    }
}
