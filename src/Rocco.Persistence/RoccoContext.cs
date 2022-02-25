// <copyright file="RoccoContext.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Rocco.Application.Contracts;
using Rocco.Domain.Base;
using Rocco.Domain.Entities;

namespace Rocco.Persistence;

// Working with DbContext - EF6 : https://bit.ly/3gUZK3k
public class RoccoContext : DbContext
{
    private readonly ILoggedInUserService _loggedInUserService;

    public RoccoContext(DbContextOptions<RoccoContext> options) : base(options) { }

    public RoccoContext(DbContextOptions<RoccoContext> options,
                          ILoggedInUserService loggedInUserService) : base(options)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }


        this._loggedInUserService = loggedInUserService ?? throw new ArgumentNullException(nameof(loggedInUserService));
    }

    public DbSet<Company> Companies { get; set; } = null!;

    public DbSet<Employee> Employees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Please put this in the Rocco.Persistence/Configuration folder
        // modelBuilder.Entity<Emploee>().HasKey(x => x.Id);

        // Add All entity configurations in a dynamic way 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Old style to add configuration
        // modelBuilder.ApplyConfiguration(new CompanyConfiguration());

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = _loggedInUserService.UserId;
                    entry.Entity.IsDeleted = false;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

