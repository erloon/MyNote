using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries.Mappings
{
    public class OrganizationMapping : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);

            //entityTypeBuilder.HasMany(x => x.Projects)
            //    .WithOne(x => x.Organization)
            //    .HasForeignKey(x => x.OrganizationId);

            entityTypeBuilder.HasOne(x => x.Company)
                .WithOne(x => x.Organization)
                .HasForeignKey<Organization>(k => k.CompanyId);

            entityTypeBuilder.Property(x => x.Name)
                .HasMaxLength(200);

            //entityTypeBuilder.HasMany(x => x.Resources)
            //    .WithOne(x => x.Organization)
            //    .HasForeignKey(x => x.OrganizationId);

            //entityTypeBuilder.HasMany(x => x.Users)
            //    .WithOne(x => x.Organization)
            //    .HasForeignKey(x => x.OrganizationId);

            entityTypeBuilder.Property(x => x.Timestamp).IsRowVersion();
        }
    }
}