// <copyright file="ICompanyService.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System.Collections.Generic;
using Rocco.Application.Models;

namespace Rocco.Application.Services.Contracts;
public interface ICompanyService
{
    IEnumerable<CompanyDto> FindAll();

    //Task AddCompanyAsync(CompanyDtoForInsert companyDto);

    //Task<CompanyDto> FindOneByCondition(Guid id);

    //Task UpdateCompany(CompanyDtoForUpdate companyDto, Guid id);

    //Task PartialUpdateCompany(JsonPatchDocument<CompanyDtoForUpdate> patchDocument, Guid id);

    //void DeleteCompany(Guid id);

    //Task<IEnumerable<EmployeeDto>> GetEmployeesByCompanyId(Guid companyId);

    //Task<EmployeeDto> GetEmployeeByCompanyId(Guid companyId, Guid employeeId);
}
