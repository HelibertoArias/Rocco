// <copyright file="MappingProfile.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using AutoMapper;
using Rocco.Application.Models;
using Rocco.Domain.Entities;

namespace Rocco.Application.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {

        // Automapper documentation https://bit.ly/3JKNYES
        // Sample mappings
        CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress, opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)))
            .ReverseMap();


        CreateMap<CompanyDtoForInsert, Company>().ReverseMap();
        CreateMap<CompanyDtoForUpdate, Company>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();

    }
}
