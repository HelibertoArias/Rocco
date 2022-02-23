// <copyright file="RoccoContext.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Rocco.Domain.Base;
using Rocco.Domain.Entities;


namespace Rocco.Persistence;

// Working with DbContext - EF6 : https://bit.ly/3gUZK3k
public class RoccoContext : DbContext
{
    public RoccoContext(DbContextOptions options) : base(options) { }

    public DbSet<Company> Companies { get; set; } = null!;

    public DbSet<Employee> Employees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Please put this in the Rocco.Persistence/Configuration folder
        //modelBuilder.Entity<Employee>().HasKey(x => x.Id);

        // Add All entity configurations in a dynamic way 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Old style to add configuration
        //modelBuilder.ApplyConfiguration(new CompanyConfiguration());

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    // TODO : Set user in session
                    entry.Entity.CreatedBy = "Dummy";
                    entry.Entity.IsDeleted = false;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    // TODO : Set user in session
                    entry.Entity.LastModifiedBy = "Dummy";
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

