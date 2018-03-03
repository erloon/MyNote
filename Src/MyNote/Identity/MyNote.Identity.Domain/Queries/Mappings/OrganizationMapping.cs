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

            entityTypeBuilder.HasOne(x => x.Company)
                .WithOne(x => x.Organization)
                .HasForeignKey<Organization>(k => k.CompanyId);

            entityTypeBuilder.Property(x => x.Name)
                .HasMaxLength(200);

            entityTypeBuilder.Property(x => x.Timestamp).IsRowVersion();
        }
    }
}