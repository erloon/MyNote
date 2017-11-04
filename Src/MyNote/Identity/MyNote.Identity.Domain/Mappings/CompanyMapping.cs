using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Mappings
{
    public class CompanyMapping: IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.HasOne(x => x.Address)
                .WithOne(x => x.Company)
                .HasForeignKey<Company>(x => x.AddressId);
            entityTypeBuilder.Property(x => x.Name)
                .HasMaxLength(200);
            entityTypeBuilder.Property(x => x.VatNumber)
                .HasMaxLength(15);
            entityTypeBuilder.Property(x => x.RegistrationNumber)
                .HasMaxLength(15);
        }
    }
}