﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Mappings
{
    public class OrganizationMapping : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.HasMany(x => x.Projects)
                .WithOne(x => x.Organization)
                .HasForeignKey(x => x.OrganizationId);
            entityTypeBuilder.HasOne(x => x.Company)
                .WithOne(x => x.Organization)
                .HasForeignKey<Organization>(k => k.CompanyId);
            entityTypeBuilder.HasOne(x => x.Address)
                .WithOne(x => x.Organization)
                .HasForeignKey<Organization>(x => x.AddressId);
            entityTypeBuilder.Property(x => x.Name)
                .HasMaxLength(200);
            entityTypeBuilder.HasMany(x => x.Resources)
                .WithOne(x => x.Organization)
                .HasForeignKey(x=>x.OrganizationId);

        }
    }
}