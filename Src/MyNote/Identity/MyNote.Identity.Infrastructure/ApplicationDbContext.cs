using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyNote.Identity.Domain.Mappings;
using MyNote.Identity.Domain.Model;
using MyNote.Infrastructure.Model;
using MyNote.Infrastructure.Model.Entity;

namespace MyNote.Identity.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

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