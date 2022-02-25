// <copyright file="PersistenceServiceRegistration.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rocco.Application.Contracts.Persistence;
using Rocco.Persistence.Repositories;

namespace Rocco.Persistence;
public static class PersistenceServiceRegistration
{
    // IConfiguration : https://bit.ly/3uXRpUJ

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                IConfiguration configuration)
    {
        // Connection String
        var stringConnection = "RoccoConnectionString";
        var connectionConfiguration = configuration.GetConnectionString(stringConnection);
        if (connectionConfiguration == null)
        {
            throw new ArgumentNullException(nameof(connectionConfiguration).ToString(),
                    message: $"{stringConnection} doesn't exist in your appsetings.json");
        }
        services.AddDbContext<RoccoContext>(options =>
          options.UseSqlServer(connectionConfiguration)
        );

        // Setting up repositories
        // Registering by one
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        // Registering dynamically
        //services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        return services;
    }
}
