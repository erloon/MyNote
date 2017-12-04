using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Mappings;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.Infrastructure
{
    public class MyIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options)
            : base((DbContextOptions) options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<Resource> Resources { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new AddressMapping());
            builder.ApplyConfiguration(new CompanyMapping());
            builder.ApplyConfiguration(new OrganizationMapping());
            builder.ApplyConfiguration(new ProjectMapping());
            builder.ApplyConfiguration(new TeamMapping());
            builder.ApplyConfiguration(new UserProjrctMapping());
            builder.ApplyConfiguration(new UserTeamMapping());
            base.OnModelCreating(builder);
        }
    }
}
