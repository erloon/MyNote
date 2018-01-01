using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries.Mappings
{
    public class ResourceProjectMapping : IEntityTypeConfiguration<ResourceProject>
    {
        public void Configure(EntityTypeBuilder<ResourceProject> builder)
        {
            builder.HasKey(x => new { x.ProjectId, x.ResourceId });
            //builder.HasOne(x => x.Resource).WithMany(x => x.ResourceProjects).HasForeignKey(x => x.ResourceId);
            //builder.HasOne(x => x.Project).WithMany(x => x.ResourceProjects).HasForeignKey(x => x.ProjectId);
        }
    }
}