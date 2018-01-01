using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Domain.Queries.Mappings
{
    public class ResourceTeamMapping : IEntityTypeConfiguration<ResourceTeam>
    {
        public void Configure(EntityTypeBuilder<ResourceTeam> builder)
        {
            builder.HasKey(x => new { x.ResourceId, x.TeamId });
            //builder.HasOne(x => x.Resource).WithMany(x => x.ResourceTeams).HasForeignKey(x => x.ResourceId);
            //builder.HasOne(x => x.Team).WithMany(x => x.ResourceTeams).HasForeignKey(x => x.TeamId);
        }
    }
}