// <copyright file="ICompanyRepository.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Rocco.Application.Contracts.Persistence.Common;
using Rocco.Domain.Entities;

namespace Rocco.Application.Contracts.Persistence;
public interface ICompanyRepository : IRepositoryBase<Company>
{

}
