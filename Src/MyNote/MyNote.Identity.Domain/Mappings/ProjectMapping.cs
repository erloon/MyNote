using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Mappings
{
    public class ProjectMapping: IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Description).HasMaxLength(1000);
            entityTypeBuilder.Property(x => x.Name).HasMaxLength(150);
            entityTypeBuilder.Property(x => x.Subject).HasMaxLength(150);

        }
    }
}