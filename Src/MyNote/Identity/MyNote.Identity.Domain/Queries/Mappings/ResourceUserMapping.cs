using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries.Mappings
{
    public class ResourceUserMapping : IEntityTypeConfiguration<ResourceUser>
    {
        public void Configure(EntityTypeBuilder<ResourceUser> builder)
        {
            builder.HasKey(x => new { x.ResourceId, x.UserId });
            //builder.HasOne(x => x.User).WithMany(x => x.ResourceUsers).HasForeignKey(x => x.UserId);
            //builder.HasOne(x => x.Resource).WithMany(x => x.ResourceUsers).HasForeignKey(x => x.ResourceId);
        }
    }
}