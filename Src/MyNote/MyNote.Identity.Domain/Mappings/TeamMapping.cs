using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Mappings
{
    public class TeamMapping: IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).HasMaxLength(100);

        }
    }
}