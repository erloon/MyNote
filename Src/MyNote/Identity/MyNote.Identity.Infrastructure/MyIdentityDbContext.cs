using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Model;
using MyNote.Identity.Domain.Queries.Mappings;

namespace MyNote.Identity.Infrastructure
{
    public class MyIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options)
            : base((DbContextOptions) options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceTeam> ResourceTeams { get; set; }
        public DbSet<ResourceUser> ResourceUsers { get; set; }
        public DbSet<ResourceProject> ResourceProjects { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new CompanyMapping());
            builder.ApplyConfiguration(new OrganizationMapping());
            builder.ApplyConfiguration(new ProjectMapping());
            builder.ApplyConfiguration(new TeamMapping());
            builder.ApplyConfiguration(new UserProjrctMapping());
            builder.ApplyConfiguration(new UserTeamMapping());
            builder.ApplyConfiguration(new AddressMapping());
            builder.ApplyConfiguration(new ResourceTeamMapping());
            builder.ApplyConfiguration(new ResourceProjectMapping());
            builder.ApplyConfiguration(new ResourceUserMapping());

            base.OnModelCreating(builder);
        }
    }
}
