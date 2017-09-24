using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Domain.Mappings
{
    public class UserProjrctMapping:IEntityTypeConfiguration<UserProjrct>
    {
        public void Configure(EntityTypeBuilder<UserProjrct> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new {x.ProjectId, x.UserId});
            entityTypeBuilder.HasOne(x => x.Project)
                .WithMany(x => x.UserProjrcts)
                .HasForeignKey(x => x.ProjectId);
            entityTypeBuilder.HasOne(x => x.User)
                .WithMany(x => x.UserProjects)
                .HasForeignKey(x => x.UserId);
        }
    }
}