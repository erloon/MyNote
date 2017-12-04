using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address> 
    {
        public void Configure(EntityTypeBuilder<Address> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Country).HasMaxLength(150);
            entityTypeBuilder.Property(x => x.City).HasMaxLength(150);
            entityTypeBuilder.Property(x => x.Number).HasMaxLength(20);
            entityTypeBuilder.Property(x => x.Street).HasMaxLength(150);
        }
    }
}