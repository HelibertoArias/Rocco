// <copyright file="EmploeeConfiguration.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rocco.Domain.Entities;

namespace Rocco.Persistence.Configurations;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(x => x.Age)
            .IsRequired();

        builder.Property(x => x.Position)
           .IsRequired()
           .HasColumnType("varchar(200)");

        // Navigation
        builder.HasOne(x => x.Company)
                .WithMany(x => x.Employees)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CompanyId);

        // Auditable Entity
        builder.Property(x => x.CreatedBy)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.LastModifiedBy)
          .HasColumnType("varchar(200)");

        builder.Property(x => x.LastModifiedDate);

        // TODO : Set only in DEBUG mode
        SeedData(builder);

    }

    private static void SeedData(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(new Employee
        {
            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
            Name = "Sam Raiden",
            Age = 26,
            Position = "Software developer",
            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            CreatedBy = "Dummy",
            CreatedDate = DateTime.Now

        }, new Employee
        {
            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
            Name = "Jana McLeaf",
            Age = 30,
            Position = "Software developer",
            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            CreatedBy = "Dummy",
            CreatedDate = DateTime.Now
        }, new Employee
        {
            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
            Name = "Kane Miller",
            Age = 35,
            Position = "Administrator",
            CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
            CreatedBy = "Dummy",
            CreatedDate = DateTime.Now
        });
    }
}
