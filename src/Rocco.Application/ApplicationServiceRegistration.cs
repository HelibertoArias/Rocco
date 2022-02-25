// <copyright file="ApplicationServiceRegistration.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Rocco.Application.Services;
using Rocco.Application.Services.Contracts;

namespace Rocco.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register Profile in Automapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Register services
        services.AddScoped<ICompanyService, CompanyService>();
        //services.AddScoped<IEmployeeService, EmployeeService>();
        
        return services;
    }
}
