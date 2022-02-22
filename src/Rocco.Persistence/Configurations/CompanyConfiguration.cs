// <copyright file="CompanyConfiguration.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rocco.Domain.Entities;

namespace Rocco.Persistence.Configurations;
public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Company");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(x => x.Address)
            .IsRequired()
            .HasColumnType("varchar(200)"); ;

        builder.Property(x => x.Country)
           .IsRequired()
           .HasColumnType("varchar(200)");

        // Navigation
        builder.HasMany(x => x.Employees)
                .WithOne(x => x.Company)
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

        // Use the Task List: https://bit.ly/3GXzyPX
        // TODO : Set only in DEBUG mode
        SeedData(builder);

    }

    private static void SeedData(EntityTypeBuilder<Company> builder)
    {
        builder.HasData(
          new Company
          {
              Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
              Name = "IT_Solutions Ltd",
              Address = "583 Wall Dr. Gwynn Oak, MD 21207",
              Country = "USA",
              CreatedBy = "Dummy",
              CreatedDate = DateTime.Now
          },
          new Company
          {
              Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
              Name = "Admin_Solutions Ltd",
              Address = "312 Forest Avenue, BF 923",
              Country = "USA",
              CreatedBy = "Dummy",
              CreatedDate = DateTime.Now
          });
    }
}
