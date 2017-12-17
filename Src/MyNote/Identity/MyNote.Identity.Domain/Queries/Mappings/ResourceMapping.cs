using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries.Mappings
{
    public class ResourceMapping :IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
        }
    }
}