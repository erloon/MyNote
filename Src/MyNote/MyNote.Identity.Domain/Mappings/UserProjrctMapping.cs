using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Mappings
{
    public class UserProjrctMapping:IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new {x.ProjectId, x.UserId});
            entityTypeBuilder.HasOne(x => x.Project)
                .WithMany(x => x.UserProjects)
                .HasForeignKey(x => x.ProjectId);
            entityTypeBuilder.HasOne(x => x.User)
                .WithMany(x => x.UserProjects)
                .HasForeignKey(x => x.UserId);
        }
    }
}