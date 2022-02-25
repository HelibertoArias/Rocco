// <copyright file="CompanyService.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System;
using System.Collections.Generic;
using AutoMapper;
using Rocco.Application.Contracts.Persistence;
using Rocco.Application.Models;
using Rocco.Application.Services.Contracts;

namespace Rocco.Application.Services;
public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public CompanyService(ICompanyRepository companyRepository,
                          IEmployeeRepository employeeRepository,
                            IMapper mapper)
    {
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        _mapper = mapper;
    }

    //public async Task AddCompanyAsync(CompanyDtoForInsert companyDto)
    //{
    //    var entity = _mapper.Map<Company>(companyDto);

    //    // TODO: Validate company create
    //    await _companyRepository.Add(entity);
    //    await _companyRepository.SaveChangesAsync();

    //}

    //public async void DeleteCompany(Guid id)
    //{
    //    var entityToDelete = await _companyRepository.FindOneByCondition(x => x.Id == id, true);

    //    if (entityToDelete == null)
    //    {
    //        throw new NotFoundException(nameof(Company), id);
    //    }

    //    entityToDelete.IsDeleted = true;

    //    _companyRepository.Delete(entityToDelete);
    //    await _companyRepository.SaveChangesAsync();
    //}

    public IEnumerable<CompanyDto> FindAll()
    {
        var entities = _companyRepository.FindAllByCondition(x => x.IsDeleted == false, false);
        return _mapper.Map<IEnumerable<CompanyDto>>(entities);
    }

    //public async Task<CompanyDto> FindOneByCondition(Guid id)
    //{
    //    var entity = await _companyRepository.FindOneByCondition(x => x.Id == id, false);
    //    if (entity == null)
    //    {
    //        throw new NotFoundException(nameof(Company), id);
    //    }


    //    return _mapper.Map<CompanyDto>(entity);
    //}


    //public async Task UpdateCompany(CompanyDtoForUpdate companyDto, Guid id)
    //{
    //    var entityToUpdate = await _companyRepository.FindOneByCondition(x => x.Id == id, false);

    //    if (entityToUpdate == null)
    //    {
    //        throw new NotFoundException(nameof(Company), id);
    //    }

    //    // TODO: This would be improved using PATCH
    //    entityToUpdate.Address = companyDto.Address;
    //    entityToUpdate.Country = companyDto.Country;
    //    entityToUpdate.Name = companyDto.Name;

    //    _companyRepository.Update(entityToUpdate);
    //    await _companyRepository.SaveChangesAsync();
    //}

    //public async Task PartialUpdateCompany(JsonPatchDocument<CompanyDtoForUpdate> patchDocument, Guid id)
    //{
    //    var entity = await _companyRepository.FindOneByCondition(x => x.Id == id, false);
    //    if (entity == null)
    //    {
    //        throw new NotFoundException(nameof(Company), id);
    //    }
    //    //TODO: Add validations here

    //    var companyDtoToPatch = _mapper.Map<CompanyDtoForUpdate>(entity);

    //    patchDocument.ApplyTo(companyDtoToPatch);
    //    var pat = companyDtoToPatch;
    //    _mapper.Map(companyDtoToPatch, entity);

    //    _companyRepository.Update(entity);
    //    await _companyRepository.SaveChangesAsync();

    //}

    //public async Task<IEnumerable<EmployeeDto>> GetEmployeesByCompanyId(Guid companyId)
    //{
    //    var company = await _companyRepository.FindOneByCondition(x => x.Id == companyId, false);
    //    if (company == null)

    //    {
    //        throw new NotFoundException(nameof(Company), companyId);
    //    }

    //    var employees = _employeeRepository.FindAllByCondition(x => x.CompanyId == companyId, false);

    //    return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    //}


    //public async Task<EmployeeDto> GetEmployeeByCompanyId(Guid companyId, Guid employeeId)
    //{
    //    var company = await _companyRepository.FindOneByCondition(x => x.Id == companyId, false);
    //    if (company == null)
    //    {
    //        throw new NotFoundException(nameof(Company), companyId);
    //    }

    //    var employee = await _employeeRepository
    //                        .FindOneByCondition(x => x.CompanyId == companyId
    //                                               && x.Id == employeeId, false);

    //    if (employee == null)
    //    {
    //        throw new NotFoundException(nameof(Employee), employeeId);
    //    }

    //    return _mapper.Map<EmployeeDto>(employee);
    //}

}
